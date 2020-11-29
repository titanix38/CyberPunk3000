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
        private string _score;
        private int _point;

        //public event DependencyProperty PropertyChanged;

        public string ScoreText
        {
            get => _score;
            set
            {
                _score = value;
                //_point = int.Parse(value);
                //_score = _point.ToString();

                //ValueProperty("ScoreText");
                SetValue(ValueProperty, _score);
            }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("ScoreText", typeof(string), ownerType: typeof(UserControlPlaying), new PropertyMetadata(""));
        //private static readonly DependencyProperty ScoreTextProperty =
        //    DependencyProperty.Register("ScoreText", typeof(int), typeof(TextBox), new PropertyMetadata(0));

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public int Score { get; set; }

        public UserControlPlaying()
        {
            //_score = "0";
            //_point = 0;
            this.DataContext = this;
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
                        Name = "tb_Launch_r" + row.ToString() + "_c_" + column.ToString(),
                        Height = 24,
                        //Visibility = Visibility.Hidden,
                        IsReadOnly = true
                    };
                    stack.Children.Add(textBox);
                }

                PlayingGrid.Children.Add(stack);
                Grid.SetRow(stack, row + 1);
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

        private void TBx_StartPt_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var toto = tBx_StartPt.Text;
        }
    }
}
