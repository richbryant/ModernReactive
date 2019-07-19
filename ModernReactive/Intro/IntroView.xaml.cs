using System;
using System.Reactive.Disposables;
using System.Windows;
using ReactiveUI;
using Splat;

namespace ModernReactive.Intro
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class IntroView : IViewFor<IntroViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty
            .Register(nameof(ViewModel), typeof(IntroViewModel), typeof(IntroView));

        public IntroView()
        {
            var viewModel = Locator.Current.GetService<IntroViewModel>();
            ViewModel = viewModel;
            this.WhenActivated(disposable =>
            {
                this.Bind(ViewModel, x => x.TheText, x => x.TheTextBox.Text)
                    .DisposeWith(disposable);
                this.OneWayBind(ViewModel, x => x.TheText, x => x.TheTextBlock.Text)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, x => x.TheTextCommand, x => x.TheTextButton)
                    .DisposeWith(disposable);
            });
        }


        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (IntroViewModel)value;
        }

        public IntroViewModel ViewModel
        {
            get => (IntroViewModel) GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}
