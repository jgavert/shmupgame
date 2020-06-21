using Sharpmake;

[module: Sharpmake.Include("common_project.sharpmake.cs")]
[module: Sharpmake.Include("../ext/externals.sharpmake.cs")]

namespace ShmupGame
{
    [Sharpmake.Generate]
    class Game : CommonProject
    {
        public string BasePath = @"[project.ProjectBasePath]/src";
        public Game()
        {
            Name = "Game";
            SourceRootPath = "[project.BasePath]";

            IsFileNameToLower = false;
        }

        [Configure()]
        public void Configure(Configuration conf, Target target)
        {
            base.ConfigureAll(conf, target);
            //conf.AddPublicDependency<SchedulerDevVersions>(target);
            //conf.AddPublicDependency<Scheduler>(target);
            conf.Output = Project.Configuration.OutputType.Exe;
        }
    }

    [Sharpmake.Generate]
    public class ExeLibSolution : Sharpmake.Solution
    {
        public ExeLibSolution()
        {
            Name = "ShmupGame";

            IsFileNameToLower = false;
            AddTargets(new Target(
                Platform.win64,
                DevEnv.vs2019,
                Optimization.Debug | Optimization.Release));
        }

        [Configure()]
        public void ConfigureAll(Configuration conf, Target target)
        {
            conf.SolutionFileName = "[solution.Name]_[target.DevEnv]_[target.Platform]";
            conf.SolutionPath = @"[solution.SharpmakeCsPath]/projects";
            conf.AddProject<Game>(target);
        }
    }

    public static class main
    {
        [Sharpmake.Main]
        public static void SharpmakeMain(Sharpmake.Arguments arguments)
        {
            arguments.Generate<ExeLibSolution>();
        }
    }
}