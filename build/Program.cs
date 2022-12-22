using System.Collections.Generic;
using Cake.AzurePipelines.Module;
using Cake.Core;
using Cake.DotNetLocalTools.Module;
using Cake.Frosting;
using Grynwald.SharedBuild;

return new CakeHost()
    // Usage of AzurePipelinesModule temporarily commented out since it does not yet support Cake 3.0
    //.UseModule<AzurePipelinesModule>()
    .UseModule<LocalToolsModule>()
    .InstallToolsFromManifest(".config/dotnet-tools.json")
    .UseSharedBuild<BuildContext>()
    .Run(args);


public class BuildContext : DefaultBuildContext
{
    public override IReadOnlyCollection<IPushTarget> PushTargets { get; } = new[]
    {
        new PushTarget(
            PushTargetType.MyGet,
            "https://www.myget.org/F/ap0llo-markdown-generator/api/v3/index.json",
            context => context.Git.IsMasterBranch || context.Git.IsReleaseBranch
        ),
        KnownPushTargets.NuGetOrg(isActive: context => context.Git.IsReleaseBranch)
    };

    public BuildContext(ICakeContext context) : base(context)
    { }
}
