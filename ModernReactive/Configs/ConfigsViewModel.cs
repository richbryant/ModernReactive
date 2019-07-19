using System;
using ReactiveUI;

namespace ModernReactive.Configs
{
    public class ConfigsViewModel : ReactiveObject
    {
        private string _configText;

        public ConfigsViewModel()
        {
            _configText = "Pray I do not alter it any further";
            Console.WriteLine("New ConfigsViewModel");
        }

        public string ConfigText
        {
            get => _configText;
            set => this.RaiseAndSetIfChanged(ref _configText, value);
        }
    }
}