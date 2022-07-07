using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.PowerShell.PowerShellTasks;
using static Nuke.Common.Tools.Docker.DockerTasks;
using Serilog;
using Nuke.Common.Tools.PowerShell;
using System.ComponentModel;
using static Nuke.Common.Tooling.Enumeration;

#pragma warning disable IDE0051 // Remove unused private members
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main() => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution(GenerateProjects = true)] readonly Solution Solution;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
        });

    Target Restore => _ => _
        .Executes(() =>
        {
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
        });

    [Parameter] readonly Foo Action = Foo.Start;

    Target Docker => _ => _
        .Requires(() => Action)
        .Executes(()=>
        {
            var script = (string)Action switch
            {
                nameof(Foo.Start) => Solution.Directory / "scripts" / "docker" / "start-docker-desktop.ps1",
                nameof(Foo.Stop) => Solution.Directory / "scripts" / "docker" / "stop-docker-desktop.ps1",
                _ => throw new Exception()
            };

            PowerShell(_ => _
                .SetFile(script)
                .SetNoLogo(true)
                .SetNoProfile(true));
        });
}
#pragma warning restore IDE0051 // Remove unused private members

public enum Bar
{
    Start,
    Stop
}


[TypeConverter(typeof(TypeConverter<Foo>))]
public class Foo : Enumeration
{
    public static readonly Foo Start = new() { Value = nameof(Start) };
    public static readonly Foo Stop = new() { Value = nameof(Stop) };

    public static explicit operator string(Foo configuration) => configuration.Value;
}
