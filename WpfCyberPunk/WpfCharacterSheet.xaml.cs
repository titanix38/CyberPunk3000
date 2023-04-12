using Data.Entities.Characterize;
using Data.Repositories;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Data.Factory;
using WpfCyberPunk.UserControls;

namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour WpfCharacterSheet.xaml
    /// </summary>
    public partial class WpfCharacterSheet : Page
    {
        private const double WIDTH_LABEL = 70;
        private const double WIDTH_TEXTBOX = 130;
        private const string STACKPANELPREFIXE = "StPa_";
        private const string SPECIALPREFIXE = "Sp_";

        public WpfCharacterSheet()
        {
            InitializeComponent();
            SetSkills();
            //GenerateControls();
            //SetGridAbilities();
        }

        private void SetSkills()
        {
            //_factory = new Factory();
            //UserControlSkills uc = new UserControlSkills();
            //uc.Features = _factory.GetFeature("INT");
            //uc.GetIHM();
            //MainGrid.Children.Add(FeaturesGrid);

            //Grid.SetRow(FeaturesGrid,2);
            //Grid.SetColumn(FeaturesGrid,0);

            //FeaturesGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //FeaturesGrid.ColumnDefinitions.Add(new ColumnDefinition());


            //Grid.SetRow(FeaturesGrid, 2);
            //Grid.SetColumn(FeaturesGrid, 0);

            //uc.Features = _factory.GetFeature("REF");
            //uc.GetIHM();
            //Grid.SetRow(FeaturesGrid, 2);
            //Grid.SetColumn(FeaturesGrid, 1);


        }


        private void SetPicture() 
        {
            //MainTab.Items.Clear(); //Clear previous Items in the user controls which is my tabItems    
            var userControls = new UserControlPicture();
            TabItem _tabUserPage = new TabItem { Content = userControls };
        }
        private void SetGridAbilities()
        {
            //SpecialAbilitiesGrid.RowDefinitions.Add(new RowDefinition());
            int i = 2;
            using (DbModelRepository<SpecialAbility> dbModel = new DbModelRepository<SpecialAbility>(new SpecialAbility()))
            {
                IQueryable<SpecialAbility> entities = dbModel.GetAll<SpecialAbility>();

                //RowDefinition newRow = new RowDefinition()
                //{
                //    Height = new GridLength(10),                    
                //};

                //foreach (SpecialAbility item in entities)
                //{
                //    SpecialAbilitiesGrid.RowDefinitions.Add(new RowDefinition()
                //    {
                //        Height = new GridLength(16),
                //    });

                //    item.Alias = item.Alias.Replace(" ", "_");

                //    StackPanel stack = new StackPanel()
                //    {
                //        Name = string.Concat(STACKPANELPREFIXE, SPECIALPREFIXE, item.Alias),
                //        Orientation = Orientation.Horizontal
                //    };
                    
                //    SubItem(stack, item.Wording, null, null,i);

                //    SpecialAbilitiesGrid.Children.Add(stack);

                //    Grid.SetRow(stack, i);
                //    Grid.SetColumn(stack, 0);

                //    i++;
                //}

            }
        }

        private void SubItem(StackPanel stack, string name, int? score, int? point, int pos)
        {

            string itemName = stack.Name.Replace(STACKPANELPREFIXE, string.Empty);
            //StackPanel stack = new StackPanel()
            //{
            //    Wording = "NewStack",
            //    Orientation = Orientation.Horizontal
            //};

            //Grid.SetRow(stack, SpecialAbilitiesGrid.RowDefinitions.Count - 1);
            //Grid.SetRow(ucPoint, SpecialAbilitiesGrid.RowDefinitions.Count - 1);
            //Grid.SetRow(ucAcquired, SpecialAbilitiesGrid.RowDefinitions.Count - 1);
            Label label = new Label()
            {
                Name = string.Concat("lb_", itemName),
                Content = name,
                Margin = new Thickness(10, 0, 0, 0),
                Width = WIDTH_LABEL,
                FontSize = 8,
                VerticalAlignment = VerticalAlignment.Stretch,
                VerticalContentAlignment = VerticalAlignment.Stretch
                //    Margin.Left = 0xA,
            };
            TextBox tbScore = new TextBox()
            {
                Name = string.Concat("tbScore_", itemName),
                Text = score == null ? string.Empty : score.ToString(),
                Height = 18,
                Width = WIDTH_TEXTBOX,
                Margin = new Thickness(40, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Top

                //Margin.Left = 10,
            };
            TextBox tbPoint = new TextBox()
            {
                Name = string.Concat("tbPoint_", itemName),
                //Text = point == null ? string.Empty : point.ToString(),
                Text = pos.ToString(),
                Height = 18,
                Width = WIDTH_TEXTBOX,
                Margin = new Thickness(25, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Top

                //Margin.Left = 10,
            };
            stack.Children.Add(label);
            stack.Children.Add(tbScore);
            stack.Children.Add(tbPoint);
        }

        public void GenerateControls()
        {
            Grid grid = new Grid();

            TextBox txtNumber = new TextBox
            {
                Name = "txtNumber",
                Text = "1776"
            };



            Button btnClickMe = new Button
            {
                Content = "Click Me",
                Name = "btnClickMe"
            };
            //grid.RegisterName(txtNumber.Wording, txtNumber);
            grid.Children.Add(btnClickMe);


            grid.Children.Add(txtNumber);
            TextBox textBox = new TextBox();
        }

        private void SpecialAbilitiesTab_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
