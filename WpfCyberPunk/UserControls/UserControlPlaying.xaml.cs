using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        private TextBox _textBox;
        public string Score
        {
            get => (string)GetValue(ScoreProperty);
            set => SetValue(ScoreProperty, value);
        }

        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register(
                nameof(Score),
                typeof(string),
                typeof(UserControlPlaying));

        public UserControlPlaying()
        {
            this.DataContext = this;

            InitializeComponent();
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

        private void TBx_StartPt_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var newScore = Score;
        }

    }

    internal class TextBoxPoint : TextBox
    {

    }
}
