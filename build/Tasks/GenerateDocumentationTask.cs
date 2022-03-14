using Cake.Common.Tools.DotNet;
using Cake.Common.Tools.DotNet.Run;
using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;
using Grynwald.SharedBuild.Tasks;

namespace Build
{
    [TaskName("GenerateDocumentation")]
    [TaskDescription("Updates auto-generated documentation files")]
    [IsDependentOn(typeof(BuildTask))]
    [IsDependeeOf(typeof(GenerateTask))]
    public class GenerateDocumentationTask : FrostingTask<BuildContext>
    {
        public override void Run(BuildContext context)
        {
            context.DotNetRun(
                "./utilities/docs/docs.csproj",
                new ProcessArgumentBuilder()
                    .Append("generate")
                    .Append("--apiReferencePath")
                    .Append("./docs/apireference2"),
                new DotNetRunSettings()
                {
                    Configuration = context.BuildSettings.Configuration,
                    NoBuild = true,
                    NoRestore = true,
                }
            );
        }
    }
}
