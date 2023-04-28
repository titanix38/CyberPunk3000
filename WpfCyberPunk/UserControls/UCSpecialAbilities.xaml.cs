using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace WpfCyberPunk.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSpecialAbilities.xaml
    /// </summary>
    public partial class UCSpecialAbilities : UserControl
    {
        /****************************************************************************************************************/
        /*                                    CONSTANTES                                                                */

        /****************************************************************************************************************/
        /****************************************************************************************************************/
        /*                                    ATTRIBUTES                                                                */
        /****************************************************************************************************************/
        /****************************************************************************************************************/
        /*                                      PROPERTIES                                                              */
        protected bool IsDisposed { get; }
        /****************************************************************************************************************/

        public UCSpecialAbilities()
        {
            InitializeComponent();
            this.DataContext = new SpecialAbilitiesViewModel();

        }

    }
}
