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
    public partial class IntroView
    {
        public IntroView()
        {
            Console.WriteLine("Constructing");
            var viewModel = Locator.Current.GetService<IntroViewModel>();
            ViewModel = viewModel;
            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.NavigateTarget, v => v.ClickButton.CommandParameter)
                    .DisposeWith(d);
            });

        }
    }
}
