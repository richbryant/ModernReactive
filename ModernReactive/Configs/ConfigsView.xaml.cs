using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using Splat;

namespace ModernReactive.Configs
{
    /// <summary>
    /// Interaction logic for Configs.xaml
    /// </summary>
    public partial class ConfigsView : IViewFor<ConfigsViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(ConfigsViewModel), typeof(ConfigsView));

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

            this.WhenActivated(d => { this.OneWayBind(ViewModel, vm => vm.ConfigText, v => v.ConfigText.Text).DisposeWith(d); });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ConfigsViewModel)value;
        }

        public ConfigsViewModel ViewModel
        {
            get => (ConfigsViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
