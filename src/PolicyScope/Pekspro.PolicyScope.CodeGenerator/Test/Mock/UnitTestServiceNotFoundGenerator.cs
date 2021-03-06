﻿using Pekspro.PolicyScope.CodeGenerator.Common;
using Pekspro.PolicyScope.CodeGenerator.LogicTest.Workers;
using System;
using System.Linq;
using System.Text;

namespace Pekspro.PolicyScope.CodeGenerator.Test.Mock
{
    public class UnitTestServiceNotFoundGenerator : CodeGeneratorBase
    {
        public UnitTestServiceNotFoundGenerator()
            : base()
        {

        }

        public override string GetClassName(CodeNames codeNames)
        {
            return "UnitTestServiceNotFound";
        }

        public override bool WriteClassFileContent(int maxServiceCount)
        {
            string fileContent = CreateClassFileContent(maxServiceCount);

            return WriteFileContent("Pekspro.PolicyScope.Test/Mock/UnitTestServiceNotFound.cs", fileContent);
        }

        public string CreateClassFileContent(int maxServiceCount)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"using Moq;
using Pekspro.PolicyScope.LogicTest;
using Pekspro.PolicyScope.LogicTest.Services;
using Pekspro.PolicyScope.LogicTest.Workers;
using Pekspro.PolicyScope.Mock;
using System.Threading.Tasks;
using Xunit;

namespace Pekspro.PolicyScope.Test.Mock
{{
    public class {GetClassName(new CodeNames(0, false, false))}
    {{");

            for (int asyncMode = 0; asyncMode < (GenerateSync ? 2 : 1); asyncMode++)
            {
                for (int resultMode = 0; resultMode < 2; resultMode++)
                {
                    for (int serviceCount = 0; serviceCount <= maxServiceCount; serviceCount++)
                    {
                        sb.AppendLine(CreateFunctionCode(new CodeNames(serviceCount, resultMode != 0, asyncMode == 0)));
                    }
                }
            }

            sb.AppendLine(@"    }
}");

            return sb.ToString();
        }

        public string CreateFunctionDeclaration(CodeNames codeNames)
        {
            var dummyLogicGenerator = new LogicGenerator();

            string s = string.Empty;

            if (codeNames.IsAsync)
            {
                s += "async Task ";
            }
            else
            {
                s += "void ";
            }

            return s + "Test" + dummyLogicGenerator.CreateFunctionName(codeNames);
        }

        public string CreateFunctionCode(CodeNames codeNames)
        {
            LogicGenerator logicGenerator = new LogicGenerator();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($@"        [Fact]");
            sb.AppendLine($@"        public {CreateFunctionDeclaration(codeNames)}()");

            sb.AppendLine(
$@"        {{
             // Arrange");

            var serviceRange = Enumerable
                .Range(1, codeNames.ServiceCount);

            CodeNames codeNamesSetup = new CodeNames(codeNames.ServiceCount == 0 ? 1 : 0, codeNames.HasReturnType, codeNames.IsAsync);
            var serviceRangeMocks = Enumerable
                .Range(1, Math.Max(1, codeNames.ServiceCount));
            var serviceRangeSetup = Enumerable
                .Range(1, codeNamesSetup.ServiceCount);

            if (codeNamesSetup.IsAsync)
            {
                var mockDeclarations = serviceRangeMocks
                    .Select(r =>
$@"            Mock<IDummyService{r}> dummyServiceMock{r} = new Mock<IDummyService{r}>();
            dummyServiceMock{r}
                .Setup(d => d.CalculateAsync())
                .Returns(Task.FromResult(1 << {r - 1}));"
                );

                sb.Append(string.Join(Environment.NewLine + Environment.NewLine, mockDeclarations));
            }
            else
            {
                var mockDeclarations = serviceRangeMocks
    .Select(r =>
$@"            Mock<IDummyService{r}> dummyServiceMock{r} = new Mock<IDummyService{r}>();
            dummyServiceMock{r}
                .Setup(d => d.Calculate())
                .Returns(1 << {r - 1});"
);

                sb.Append(string.Join(Environment.NewLine + Environment.NewLine, mockDeclarations));
            }

            sb.AppendLine();
            sb.AppendLine();

            if (codeNames.IsAsync)
            {
                sb.AppendLine(@"            var policyScopeMock = PolicyScopeMock
                            .AsyncPolicy(PolicyNames.AsyncPolicyName)");
            }
            else
            {
                sb.AppendLine(@"            var policyScopeMock = PolicyScopeMock
                            .SyncPolicy(PolicyNames.SyncPolicyName)");
            }

            if (codeNamesSetup.HasServices)
            {
                sb.Append("                            .WithService(");

                var mockNames = serviceRangeSetup
                    .Select(r =>
    $@"dummyServiceMock{r}.Object"
                    );

                sb.Append(string.Join(", ", mockNames));
                sb.AppendLine(")");
            }
            else
            {
                sb.AppendLine("                            .WithNoService()");
            }

            if (codeNames.HasReturnType)
            {
                sb.AppendLine("                            .WithResultType<int>()");
            }
            else
            {
                sb.AppendLine("                            .WithNoResult()");
            }

            sb.AppendLine("                            .Build();");


            sb.AppendLine();
            sb.AppendLine($"            {logicGenerator.GetClassName(codeNames)} logic = new {logicGenerator.GetClassName(codeNames)}(policyScopeMock.Object);");
            sb.AppendLine();
            sb.AppendLine("            // Act and assert");

            LogicGenerator dummyLogicGenerator = new LogicGenerator();

            if (codeNames.IsAsync)
            {
                sb.AppendLine(
@"            await Assert.ThrowsAsync<PolicyScopeMockException>(async () =>
            {");

                if (codeNames.HasReturnType)
                {
                    sb.AppendLine($"                int result = await logic.{dummyLogicGenerator.CreateFunctionName(codeNames)}();");
                }
                else
                {
                    sb.AppendLine($"                await logic.{dummyLogicGenerator.CreateFunctionName(codeNames)}();");
                }

                sb.AppendLine(
@"            });");
            }
            else
            {
                sb.AppendLine(
@"            Assert.Throws<PolicyScopeMockException>(() =>
            {");

                if (codeNames.HasReturnType)
                {
                    sb.AppendLine($"                int result = logic.{dummyLogicGenerator.CreateFunctionName(codeNames)}();");
                }
                else
                {
                    sb.AppendLine($"                logic.{dummyLogicGenerator.CreateFunctionName(codeNames)}();");
                }

                sb.AppendLine(
@"            });");
            }

            sb.AppendLine(
@"        }");

            return sb.ToString();
        }
    }
}
