using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace ModernReactive.Intro
{
    public class IntroViewModel : ReactiveObject
    {
        public IntroViewModel()
        {
            _theText = "I have altered the text.";
            TheTextCommand = ReactiveCommand
                .CreateFromObservable(ExecuteTextCommand);
        }

        private string _theText;
        public string TheText
        {
            get => _theText;
            set => this.RaiseAndSetIfChanged(ref _theText, value);
        }
    
        public ReactiveCommand<Unit,Unit> TheTextCommand { get; set; }

        private IObservable<Unit> ExecuteTextCommand()
        {
            TheText = "Pray I do not alter it any further";
            return Observable.Return(Unit.Default);
        }

        public Uri NavigateTarget => new Uri($"/Configs/ConfigsView.xaml", UriKind.Relative);
    }
}