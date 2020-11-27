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

namespace WpfCyberPunk.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlPlaying.xaml
    /// </summary>
    public partial class UserControlPlaying : UserControl
    {
        public UserControlPlaying()
        {
            InitializeComponent();
        }


        private void Construct()
        {
            StackPanel stack = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            for (int row = 1; row <= 2; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    TextBox textBox = new TextBox()
                    {
                        Name = "tb_Launch_r"+row.ToString()+"_c_" + column.ToString(),
                        Height = 24,
                        //Visibility = Visibility.Hidden,
                        IsReadOnly = true
                    };
                    stack.Children.Add(textBox);
                }

                PlayingGrid.Children.Add(stack);
                Grid.SetRow(stack,row+1);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnOk_MouseOver(object sender, RoutedEventArgs e)
        {
            Button btnOK = sender as Button;

            //ToolTip tool = new ToolTip() { Content = contains };
            ToolTip tool = new ToolTip() { Content = "OK", IsOpen = true, StaysOpen = true };
            if (btnOK != null) btnOK.ToolTip = tool;
        }

        private void BtnDice_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnDice_MouseOver(object sender, RoutedEventArgs e)
        {
            Button btnDice = sender as Button;

            //ToolTip tool = new ToolTip() { Content = contains };
            ToolTip tool = new ToolTip() { Content = "Lancement du dé 10 ou 20 selon valeur compétence", IsOpen = true, StaysOpen = true };
            if (btnDice != null) btnDice.ToolTip = tool;
        }
    }
}
