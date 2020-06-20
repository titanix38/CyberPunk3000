using System;
using System.Windows.Input;

namespace WpfCyberPunk
{
    public interface ITab
    {
        string Name { get; set; }

        ICommand CloseCommand { get; }

        event EventHandler CloseRequested;
    }
}
