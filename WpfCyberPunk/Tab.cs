using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfCyberPunk
{
    public abstract class Tab : ITab
    {
        public string Name { get; set; }

        public ICommand CloseCommand { get; }

        public event EventHandler CloseRequested;


        public Tab()
        {
            CloseCommand = new ActionCommand(c => CloseRequested?.Invoke(this, EventArgs.Empty));
        }
    }
}
