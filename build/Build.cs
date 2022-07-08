using Nuke.Common;
using Nuke.Common.ProjectModel;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.IO;


#pragma warning disable CA1822, IDE0051
partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution(GenerateProjects = true)] readonly Solution Solution;

    private AbsolutePath PublishDirectory => Solution.JenkinsTestApp.Directory / "bin" / "publish";

    Target Clean => _ => _
        .Description("Clean the project")
        .Executes(() => DotNetClean(_ => _
            .SetProject(Solution.JenkinsTestApp)
            .SetConfiguration(Configuration)
            .SetNoLogo(true)
            .SetVerbosity(DotNetVerbosity.Quiet)
        ));

    Target Restore => _ => _
        .Description("Restore the project")
        .Executes(() => DotNetRestore(_ => _
            .SetVerbosity(DotNetVerbosity.Quiet)
        ));

    Target Compile => _ => _
        .Description("Compile the project")
        .Executes(() => DotNetBuild(_ => _
            .SetVerbosity(DotNetVerbosity.Quiet)
            .SetConfiguration(Configuration)
            .SetNoLogo(true)
            .SetProjectFile(Solution.JenkinsTestApp)
        ));

    Target Publish => _ => _
        .Description("Publish the project")
        .Executes(() => DotNetPublish(_ => _
            .SetConfiguration(Configuration)
            .SetNoLogo(true)
            .SetNoBuild(true)
            .SetNoRestore(true)
            .SetVerbosity(DotNetVerbosity.Quiet)
            .SetProject(Solution.JenkinsTestApp)
            .SetOutput(PublishDirectory)
        ));

    Target Test => _ => _
        .Description("Test the project")
        .Executes(() => DotNetTest(_ => _
            .SetConfiguration(Configuration)
            .SetNoRestore(true)
            .SetNoBuild(true)
            .SetVerbosity(DotNetVerbosity.Quiet)
            .SetLoggers("trx")
        ));

}
#pragma warning restore IDE0051, CA1822 // Remove unused private members

