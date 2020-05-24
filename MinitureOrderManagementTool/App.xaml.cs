using MinitureOrderManagementTool.ViewModels;
using MinitureOrderManagementTool.Views;
using NLog;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinitureOrderManagementTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public App()
        {
            //Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
            Locator.CurrentMutable.RegisterLazySingleton(() => new MainWindow(), typeof(IViewFor<MainWindowViewModel>));
            Locator.CurrentMutable.Register(() => new OrderListView(), typeof(IViewFor<OrderListViewModel>));
            Locator.CurrentMutable.Register(() => new NewOrderView(), typeof(IViewFor<NewOrderViewModel>));
            Locator.CurrentMutable.Register(() => new CommonOrderEditorView(), typeof(IViewFor<CommonOrderEditorViewModel>));
            Locator.CurrentMutable.Register(() => new OrderEditorView(), typeof(IViewFor<OrderEditorViewModel>));

            //var asm = Assembly.GetCallingAssembly();

            //foreach (var ti in asm.DefinedTypes
            //    .Where(ti => ti.ImplementedInterfaces.Contains(typeof(IViewFor)) && !ti.IsAbstract))
            //{
            //    Trace.WriteLine(ti.ToString() + ": " + ti.GetCustomAttribute<SingleInstanceViewAttribute>()?.ToString());
            //}
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.SetupExceptionHandling();
        }

        private void SetupExceptionHandling()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile")
            {
                FileName = "${basedir}/logs/logfile.txt",
                ArchiveAboveSize = 10240,
                ArchiveFileName = "${basedir}/archives/log.{#####}.txt",
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
                e.Handled = true;
            };

            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                this.LogUnhandledException(e.Exception, "TaskScheduler.UnobservedTaskException");
                e.SetObserved();
            };
        }

        private void LogUnhandledException(Exception exception, string source)
        {
            string message = $"Unhandled exception ({source})";
            try
            {
                System.Reflection.AssemblyName assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
                message = string.Format("Unhandled exception in {0} v{1}", assemblyName.Name, assemblyName.Version);
            }
            catch (Exception ex)
            {
                App.logger.Error(ex, "Exception in LogUnhandledException");
            }
            finally
            {
                App.logger.Error(exception, message);
            }
        }
    }
}
