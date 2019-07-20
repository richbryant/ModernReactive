using System;
using ReactiveUI;

namespace ModernReactive.Configs
{
    public class ConfigsViewModel : ReactiveObject
    {
        private string _configText;

        public ConfigsViewModel()
        {
            Console.WriteLine("Constructing");
            _configText = "Pray I do not alter it any further";
        }

        public string ConfigText
        {
            get => _configText;
            set => this.RaiseAndSetIfChanged(ref _configText, value);
        }
    }
}