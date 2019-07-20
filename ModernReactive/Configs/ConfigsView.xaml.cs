using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using Splat;

namespace ModernReactive.Configs
{
    /// <summary>
    /// Interaction logic for Configs.xaml
    /// </summary>
    public partial class ConfigsView : ReactiveUserControl<ConfigsViewModel>
    {
        public ConfigsView()
        {
            var viewModel = Locator.Current.GetService<ConfigsViewModel>();
            ViewModel = viewModel;

            this.WhenActivated(d => { this.OneWayBind(ViewModel, vm => vm.ConfigText, v => v.ConfigText.Text).DisposeWith(d); });
        }

        public ConfigsView(ConfigsViewModel viewModel = null)
        {
            InitializeComponent();
            if (viewModel == null) viewModel = Locator.Current.GetService<ConfigsViewModel>();
            ViewModel = viewModel;

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.ConfigText, v => v.ConfigText.Text).DisposeWith(d);
            });
        }
    }
}
