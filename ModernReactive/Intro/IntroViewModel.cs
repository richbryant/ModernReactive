using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace ModernReactive.Intro
{
    public class IntroViewModel : ReactiveObject
    {
        private string _introText;

        public IntroViewModel()
        {
            _theText = "I have altered the text.";
            Console.WriteLine("New IntroViewModel");
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
            Console.WriteLine("Clicked");
            return Observable.Return(Unit.Default);
        }

        public string IntroText
        {
            get => _introText;
            set => this.RaiseAndSetIfChanged(ref _introText, value);
        }

    }
}