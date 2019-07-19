using System;
using System.Windows;
using ModernReactive.Configs;
using ModernReactive.Intro;
using ModernReactive.Shell;
using ReactiveUI;
using Splat;

namespace ModernReactive
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigureService();
            base.OnStartup(e);
            var window = new ShellView(new ShellViewModel());
            MainWindow = window;
            window.Show();
        }

        public void ConfigureService()
        {
            Locator.CurrentMutable.Register(()=> new ShellView(), typeof(IViewFor<ShellViewModel>));
            Locator.CurrentMutable.Register(()=> new IntroView(), typeof(IViewFor<IntroViewModel>));
            Locator.CurrentMutable.Register(()=> new ConfigsView(), typeof(IViewFor<ConfigsViewModel>));
        }
    }
}
