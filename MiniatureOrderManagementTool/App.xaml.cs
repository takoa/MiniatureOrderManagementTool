using MiniatureOrderManagementTool.Models;
using NLog;
using ReactiveUI;
using Splat;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace MiniatureOrderManagementTool
{
    public partial class App : Application
    {
        private const string configPath = "./config.json";

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public Config Config { get; private set; }

        public App()
        {
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());

            this.InitializeConfig();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.SetupExceptionHandling();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            this.WriteConfig();
        }

        private void SetupExceptionHandling()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = "${currentdir}/logs/logfile.txt",
                ArchiveAboveSize = 1048576,
                ArchiveFileName = "${currentdir}/logs/archives/log.{#####}.txt",
                ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Sequence,
                ConcurrentWrites = true,
                KeepFileOpen = false,
                Encoding = Encoding.UTF8
            };

            config.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logfile);

            LogManager.Configuration = config;

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                this.LogUnhandledException((Exception)e.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, e) =>
            {
                this.LogUnhandledException(e.Exception, "Application.Current.DispatcherUnhandledException");
                //e.Handled = true;
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                this.LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
                //e.SetObserved();
            };
        }

        private void LogUnhandledException(Exception exception, string source)
        {
            string message = null;

            try
            {
                AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

                message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
            }
            catch (Exception ex)
            {
                App.logger.Error(ex, "Exception in LogUnhandledException");
            }
            finally
            {
                App.logger.Error(exception, message);
                App.logger.Error(exception.StackTrace);
            }
        }

        private void InitializeConfig()
        {
            try
            {
                using StreamReader reader = new StreamReader(App.configPath, Encoding.UTF8);
                string json = reader.ReadToEnd();

                this.Config = new Config(JsonSerializer.Deserialize<Models.Dtos.Config>(json));
            }
            catch (FileNotFoundException)
            {
                this.Config = new Config()
                {
                    MainWindowPosition = new Point(200d, 200d),
                    MainWindowSize = new Size(800, 600),
                    OrderEditorWindowDelta = new Point(100d, 100d),
                    OrderEditorWindowSize = new Size(400, 600)
                };
            }
        }

        private void WriteConfig()
        {
            string json = JsonSerializer.Serialize(this.Config);
            using StreamWriter writer = new StreamWriter(App.configPath, false, Encoding.UTF8);

            writer.Write(json);
        }
    }
}
