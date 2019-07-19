using ReactiveUI;

namespace ModernReactive.Shell
{
    public class ShellViewModel : ReactiveObject
    {
        private string _titleText;

        public ShellViewModel()
        {
            _titleText = "A ReactiveUI app styled with ModernUI";
        }

        public string TitleTest
        {
            get => _titleText;
            set => this.RaiseAndSetIfChanged(ref _titleText, value);
        }
    }
}