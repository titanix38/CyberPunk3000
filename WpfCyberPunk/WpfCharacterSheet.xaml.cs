using Data.Entities.Characterize;
using Data.Repositories;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour WpfCharacterSheet.xaml
    /// </summary>
    public partial class WpfCharacterSheet : Page
    {
        private const double WIDTH_LABEL = 70;
        private const double WIDTH_TEXTBOX = 130;


        public WpfCharacterSheet()
        {
            InitializeComponent();
            //GenerateControls();
            SetGridAbilities();
        }


        private void SetGridAbilities()
        {
            SpecialAbilitiesGrid.RowDefinitions.Add(new RowDefinition());

            using (DbModelRepository<SpecialAbility> dbModel = new DbModelRepository<SpecialAbility>(new SpecialAbility()))
            {
                IQueryable<SpecialAbility> entities = dbModel.GetAll<SpecialAbility>();

                foreach (SpecialAbility item in entities)
                {
                    item.Name = item.Name.Replace(" ", "_");


                    StackPanel stack = new StackPanel()
                    {
                        Name = string.Concat("Ab_",item.Alias, "_StPa"),
                        Orientation = Orientation.Horizontal
                    };
                    SpecialAbilitiesGrid.Children.Add(stack);
                    Grid.SetColumn(stack, 0);

                    SubItem(stack, item.Name, null, null);
                }

            }
        }

        private void SubItem(StackPanel stack, string name, int? score, int? point)
        {

            string itemName = stack.Name.Replace("_stack", string.Empty);
            //StackPanel stack = new StackPanel()
            //{
            //    Name = "NewStack",
            //    Orientation = Orientation.Horizontal
            //};

            //Grid.SetRow(stack, SpecialAbilitiesGrid.RowDefinitions.Count - 1);
            //Grid.SetRow(ucPoint, SpecialAbilitiesGrid.RowDefinitions.Count - 1);
            //Grid.SetRow(ucAcquired, SpecialAbilitiesGrid.RowDefinitions.Count - 1);
            Label label = new Label()
            {
                Name = string.Concat("label-", itemName),
                Content = name,
                Margin = new Thickness(10, 0, 0, 0),
                Width = WIDTH_LABEL,
                VerticalAlignment = VerticalAlignment.Top
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
                Text = point == null ? string.Empty : point.ToString(),
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

            TextBox txtNumber = new TextBox();
            txtNumber.Name = "txtNumber";
            txtNumber.Text = "1776";



            Button btnClickMe = new Button();
            btnClickMe.Content = "Click Me";
            btnClickMe.Name = "btnClickMe";
            //grid.RegisterName(txtNumber.Name, txtNumber);
            grid.Children.Add(btnClickMe);


            grid.Children.Add(txtNumber);
            TextBox textBox = new TextBox();
        }


    }
}
