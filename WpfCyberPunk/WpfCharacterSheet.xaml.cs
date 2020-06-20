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
namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour WpfCharacterSheet.xaml
    /// </summary>
    public partial class WpfCharacterSheet : Page
    {
        public WpfCharacterSheet() => InitializeComponent();

        public void GenerateControls()
        {
            Grid grid = new Grid();

            TextBox txtNumber = new TextBox();
            txtNumber.Name = "txtNumber";
            txtNumber.Text = "1776";



            Button btnClickMe = new Button();
            btnClickMe.Content = "Click Me";
            btnClickMe.Name = "btnClickMe";
            grid.RegisterName(txtNumber.Name, txtNumber);
            grid.Children.Add(btnClickMe);


            grid.Children.Add(txtNumber);
            TextBox textBox = new TextBox();
        }


    }
}
