using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using Data.Entities.Characterize;
using Data.Factory;

namespace WpfCyberPunk.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSkills.xaml
    /// </summary>
    public partial class UserControlSkills : UserControl
    {
        private const int BOTTOM = 5;

        private string _point;

        private readonly List<TextBox> _textBoxes;

        private readonly UserControlPlaying _ucPlaying;

        private readonly Factory _factory;
        

        public Feature Feature { get; set; }

        //public FeatureIHM FeatureIHM { get; private set; }

        public UserControlSkills()
        {
            _factory = new Factory();
            _textBoxes = new List<TextBox>();
            _ucPlaying = new UserControlPlaying();
            InitializeComponent();
            Construct();
            //SetHeader();
        }

        private void Construct()
        {
            Grid mGrid = new Grid()
            {
                VerticalAlignment = VerticalAlignment.Center,
            };

            for (int i = 0; i < GetPositions().Count/2; i++)
            {
                mGrid.ColumnDefinitions.Add(new ColumnDefinition());
                mGrid.RowDefinitions.Add(new RowDefinition());
            }

            foreach (Feature feature in _factory.GetFeatures())
            {

                if (GetPositions().ContainsKey(feature.Alias))
                {
                    StackPanel stack = GetIHM(feature);
                    mGrid.Children.Add(stack);

                    Grid.SetRow(stack, GetPositions()[feature.Alias].X);
                    Grid.SetColumn(stack, GetPositions()[feature.Alias].Y);
                    Grid.SetRowSpan(stack, GetPositions()[feature.Alias].RowSpan);
                }
            }

            FeatureGrid.Children.Add(mGrid);
            Grid.SetRow(FeatureGrid, 2);
            Grid.SetColumn(FeatureGrid, 0);
        }

        // TODO : Voir comment optimiser cela
        private Dictionary<string, Position> GetPositions()
        {
            Dictionary<string, Position> item = new Dictionary<string, Position>()
            {
                {"INT",new Position(){X=0,Y=0,RowSpan = 3}},
                {"REF",new Position(){X=0,Y=1,RowSpan = 2}},
                {"TECH",new Position(){X=0,Y=2,RowSpan = 1}},
                {"MVT",new Position(){X=2,Y=1,RowSpan = 1}},
                {"CON",new Position(){X=2,Y=2,RowSpan = 1}},
                {"SF",new Position(){X=1,Y=2,RowSpan = 1}},
                {"EMP",new Position(){X=0,Y=3,RowSpan = 1}},
                {"BT",new Position(){X=1,Y=3,RowSpan = 1}},
            };

            return item;
        }

        private StackPanel GetIHM(Feature feature)
        {
            StackPanel panel = new StackPanel()
            {
                //Height = 100,
                Name = "StkPan_Features",
                Orientation = Orientation.Vertical,
            };

            StackPanel stkPanFeature = GetStkPanFeature(feature.Alias);
            StackPanel stkPanSkill = GetStkPanSkill();

            panel.Children.Add(stkPanFeature);
            panel.Children.Add(stkPanSkill);

            //Grid.SetRow(stkPanFeature, 0);
            //Grid.SetRow(stkPanSkill, 1);
            return panel;

            
            //Grid.SetRow(stkPanFeature, 2);
            //Grid.SetColumn(stkPanFeature, 0);
        }

        private StackPanel GetStkPanFeature(string alias)
        {
            StackPanel stackFeature = new StackPanel
            {
                Name = "StkPan_Features",
                Orientation = Orientation.Horizontal,
            };

            Feature = _factory.GetFeature(alias);

            foreach (var element in getEltFeature())
            {
                stackFeature.Children.Add(element);
                if (element is CheckBox)
                {
                    CheckBox chx = (CheckBox)element;

                    chx.AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(chx_Check));
                    chx.AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(chx_UnCheck));
                }

                if (element is TextBox)
                {
                    TextBox textBox = (TextBox) element;
                    if (textBox.Name.StartsWith("tbScore_"))
                    {
                        _textBoxes.Add(textBox);
                    }
                }

            }
            return stackFeature;
        }

        private void chx_Check(object sender, RoutedEventArgs e)
        {
            int score = GetScore(sender as CheckBox);
            score += string.IsNullOrWhiteSpace(_ucPlaying.ScoreText) ? 0 : int.Parse(_ucPlaying.ScoreText);
            _ucPlaying.ScoreText = score.ToString();
        }

        private void chx_UnCheck(object sender, RoutedEventArgs e)
        {
            int pt = string.IsNullOrWhiteSpace(_ucPlaying.ScoreText) ? 0 : int.Parse(_ucPlaying.ScoreText);
            pt -= GetScore(sender as CheckBox);
            _ucPlaying.ScoreText = pt.ToString();
        }

        private int GetScore(CheckBox checkBox)
        {
            string name = "tbScore_" + checkBox.Name.Replace("chBxPt_", string.Empty);
            return int.Parse(_textBoxes.FirstOrDefault(t => t.Name == name).Text);
        }

        private UIElement[] getEltFeature()
        {
            UIElement[] elements =
            {
                new TextBlock
                {
                    Name = string.Concat("lb_", Feature.Alias),
                    Text = Feature.Name,
                    Width = 100,
                    Margin = new Thickness(5, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center
                },

                new TextBox
                {
                    Name = string.Concat("tbScore_", Feature.Alias),
                    FontFamily = new FontFamily("Segoe UI"),
                    Background = Brushes.WhiteSmoke,
                    Text = GetRandom().ToString(),
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 5, 0),
                    Style = (Style)Application.Current.Resources["TextBoxFeature"]
                },

                new TextBox
                {
                    Name = string.Concat("tbPoint_", Feature.Alias),
                    //Text = "10",
                    Style = (Style)Application.Current.Resources["TextBoxFeature"]
                },

                new CheckBox
                {
                    Name = string.Concat("chBxPt_", Feature.Alias),
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 14,
                    //Width = 14,
                    Margin = new Thickness(10, 0, 10, 0),
                }
            };
            return elements;
        }


        private StackPanel GetStkPanSkill()
        {
            StackPanel mainPanel = new StackPanel()
            {
                Name = "StkPan_MainSkill",
                Orientation = Orientation.Vertical,
            };

            List<Skill> skills = _factory.GetSkills(Feature);


            foreach (var skill in skills)
            {
                mainPanel.Children.Add(getStacks(skill));
            }

            return mainPanel;
        }

        private StackPanel getStacks(Skill skill)
        {
            StackPanel stackSkill = new StackPanel
            {
                Name = "StkPan_Skill",
                Orientation = Orientation.Horizontal,
            };


            foreach (var element in GetEltsSkill(skill))
            {
                stackSkill.Children.Add(element);
            }

            return stackSkill;
        }

        private UIElement[] GetEltsSkill(Skill skill)
        {
            UIElement[] elements =
            {
                new TextBlock
                {
                    Name = "TxtBlk_" + skill.Alias,
                    Text = skill.Name,
                    FontSize = 10,
                    Width = 100,
                    Margin = new Thickness(15, 0, 0, BOTTOM),
                },
                new TextBox
                {
                    Name = string.Concat("tbScore_",  skill.Alias),
                    //Text = "9",
                    Margin = new Thickness(10, 0,0,BOTTOM),
                    //Margin = new Thickness(0),
                    Style = (Style)Application.Current.Resources["TextBoxSkill"]
                },
                new TextBox
                {
                    Name = string.Concat("tbPoint_", skill.Alias),
                    //Text = "10",
                    Margin = new Thickness(10, 0, 5, BOTTOM),
                    Style = (Style)Application.Current.Resources["TextBoxSkill"]
                },
                new CheckBox
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 14,
                    //Width = 14,
                    Margin = new Thickness(10, 0, 10, BOTTOM),
                },
            };
            return elements;
        }


        private int GetRandom()
        {
            Random rnd = new Random();

            return rnd.Next(2, 10);
        }

    }

    internal struct Position
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int RowSpan { get; set; }

    }

}
