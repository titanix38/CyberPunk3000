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
using WpfCyberPunk.IHM;

namespace WpfCyberPunk.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlSkills.xaml
    /// </summary>
    public partial class UserControlSkills : UserControl
    {
        public FeatureIHM FeatureIHM { get; private set; }

        public UserControlSkills()
        {
            InitializeComponent();
            SetHeader();
        }


        private void SetHeader()
        {
            Grid grid = new Grid()
            {
                //Height = 100,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            RowDefinition rowData = new RowDefinition();
            grid.RowDefinitions.Add(rowData);
            StackPanel stackFeature = getStkPanFeature();

            grid.Children.Add(stackFeature);
            Grid.SetRow(stackFeature, 0);

            FeatureGrid.Children.Add(grid);
            Grid.SetRow(grid, 2);
            Grid.SetColumn(grid, 0);
        }

        private StackPanel getStkPanFeature()
        {
            FeatureIHM feat = new FeatureIHM()
            {
                Alias = "INT",
                Name = "Intelligence",
            };
            
            feat.SetStackPanel();
            return feat.Stack;
        }
    }
}
