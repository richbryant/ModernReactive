using System.Windows;
using ReactiveUI;
using Splat;

namespace ModernReactive.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ShellView : IViewFor<ShellViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(ShellViewModel), typeof(ShellView));

        public ShellView(ShellViewModel viewModel = null)
        {
            InitializeComponent();
            if (viewModel == null) viewModel = Locator.Current.GetService<ShellViewModel>();
            ViewModel = viewModel;

            this.WhenActivated(d => { this.OneWayBind(ViewModel, vm => vm.TitleTest, v => v.Title); });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ShellViewModel)value;
        }

        public ShellViewModel ViewModel
        {
            get => (ShellViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
