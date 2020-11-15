using Data.Entities.Characterize;
using Data.Repositories;
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
    /// Interaction logic for UserControlSpecialAbilities.xaml
    /// </summary>
    public partial class UserControlSpecialAbilities : UserControl
    {
        /****************************************************************************************************************/
        /*                                    CONSTANTES                                                                */
        private const double WIDTH_LABEL = 50;
        private const double WIDTH_TEXTBOX = 130;
        private const string STACKPANELPREFIXE = "StPa_";
        private const string SPECIALPREFIXE = "Sp_";
        private const int COLUMNS = 3;
        private const double PIXELS = 30;
        /****************************************************************************************************************/
        /****************************************************************************************************************/
        /*                                    ATTRIBUTES                                                                 */
        private Label _label;
        private StackPanel _stack;
        /****************************************************************************************************************/


        public UserControlSpecialAbilities()
        {
            InitializeComponent();
            SetHeader();
            //SetGridAbilities();
        }

        private void SetHeader()
        {
            Grid grid = new Grid()
            {
                //Height = 100,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            //ColumnDefinition gridCol1 = new ColumnDefinition();

            //ColumnDefinition gridCol2 = new ColumnDefinition();

            //ColumnDefinition gridCol3 = new ColumnDefinition();

            //grid.ColumnDefinitions.Add(new ColumnDefinition());

            //grid.ColumnDefinitions.Add(new ColumnDefinition());

            //grid.ColumnDefinitions.Add(new ColumnDefinition());

            //StackPanel stack = new StackPanel()
            //{
            //    Name = "St_Header",
            //    Orientation = Orientation.Horizontal,
            //    //Width = 200

            //};
            //RowDefinition rowHeader = new RowDefinition();
            //grid.RowDefinitions.Add(rowHeader);
            //for (int i = 0; i < COLUMNS; i++)
            //{
            // TODO : A supprimer ensuite
            //int i= 0;
            ColumnDefinition childGrid = new ColumnDefinition();
            grid.ColumnDefinitions.Add(childGrid);
            //_stack = GetStkPanHeader();
            //grid.Children.Add(_stack);
            //Grid.SetColumn(_stack,i);
            //Grid.SetRow(_stack,0);

            grid.ShowGridLines = true;
            //}
            RowDefinition rowData = new RowDefinition();
            grid.RowDefinitions.Add(rowData);
            Grid gridData = getStkPanSpecAbilities();
            grid.Children.Add(gridData);
            Grid.SetRow(gridData, 0);
            //stack.Children.Add(lblName);
            //stack.Children.Add(lblValue);
            //stack.Children.Add(lblAcquired);
            //Grid.SetColumn(grid, i);
            //}
            SpecialAbilitiesGrid.Children.Add(grid);
            Grid.SetRow(grid, 1);
            Grid.SetColumn(grid, 0);
        }

        private StackPanel GetStkPanHeader()
        {
            // TODO : Ceci sera utilisé pour d'autres Attributs
            List<Label> labels = new List<Label>()
            {
                {
                    new Label()
                    {
                        Name = "lb_Name",
                        Content = "Nom",
                        VerticalAlignment = VerticalAlignment.Stretch,
                        VerticalContentAlignment = VerticalAlignment.Stretch
                    }
                },
                new Label()
                {
                    Name = "lb_Space",
                    Content = " ",
                    Width = 10,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    VerticalContentAlignment = VerticalAlignment.Stretch
                },
                {
                    new Label()
                    {
                        Name = "lb_Score",
                        Content = "Score",
                        VerticalAlignment = VerticalAlignment.Stretch,
                        VerticalContentAlignment = VerticalAlignment.Stretch
                    }
                },
                {
                    new Label()
                    {
                        Name = "lb_Point",
                        Content = "Point",
                        VerticalAlignment = VerticalAlignment.Stretch,
                        VerticalContentAlignment = VerticalAlignment.Stretch
                    }
                },
            };

            StackPanel stack = new StackPanel()
            {
                Name = "StackPanel_Header",
                Orientation = Orientation.Horizontal,
                //Width = 200
            };

            foreach (var l in labels)
            {
                stack.Children.Add(l);
            }

            return stack;
        }

        private Grid getStkPanSpecAbilities()
        {
            //Grid mainGrid = new Grid()
            //{
            //    HorizontalAlignment = HorizontalAlignment.Left,
            //};
            ////ColumnDefinition column1 = new ColumnDefinition();
            ////ColumnDefinition column2 = new ColumnDefinition();
            ////mainGrid.ColumnDefinitions.Add(column1);
            ////mainGrid.ColumnDefinitions.Add(column2);
            //mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            //mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

            //mainGrid.RowDefinitions.Add(new RowDefinition());
            //mainGrid.RowDefinitions.Add(new RowDefinition());
            //mainGrid.RowDefinitions.Add(new RowDefinition());
            //mainGrid.RowDefinitions.Add(new RowDefinition());
            //mainGrid.RowDefinitions.Add(new RowDefinition());
            //mainGrid.RowDefinitions.Add(new RowDefinition());

            //int i = 0;
            //int j = 0;



            using (DbModelRepository<SpecialAbility> dbModel =
                new DbModelRepository<SpecialAbility>(new SpecialAbility()))
            {
                IQueryable<SpecialAbility> specials = dbModel.GetAll<SpecialAbility>();

                //for (int r = 0; r < specials.Count(); i++)
                //{
                //    //RowDefinition row = new RowDefinition();
                //    mainGrid.RowDefinitions.Add(new RowDefinition());
                //}

                SkillIHM test = new SkillIHM();


                SkillIHM att = new SkillIHM(specials.Count(),3);
                
                foreach (var special in specials)
                {
                    att.Alias = special.Alias;
                    att.Name = special.Name;
                    att.SetGrid();

                    //StackPanel subStack = new StackPanel()
                    //{
                    //    Name = "StkPan_SubItems",
                    //    Orientation = Orientation.Horizontal,
                    //    //Height = 20
                    //    //Width = 200
                    //};
                    //Label lblName = new Label()
                    //{
                    //    Name = string.Concat("lb_", special.Alias),
                    //    Content = special.Name,
                    //    FontSize = 10,
                    //    Width = 100
                    //};
                    //TextBox txtScore = new TextBox()
                    //{
                    //    Name = string.Concat("tbScore_", special.Alias),
                    //    FontSize = 10,
                    //    Height = 14,
                    //    Width = 25,
                    //    Margin = new Thickness(0, 0, 10, 0),
                    //    HorizontalAlignment = HorizontalAlignment.Center,
                    //    HorizontalContentAlignment = HorizontalAlignment.Center,
                    //    VerticalContentAlignment = VerticalAlignment.Center
                    //};

                    //TextBox txtPoint = new TextBox()
                    //{
                    //    Name = string.Concat("tbPoint_", special.Alias),
                    //    FontSize = 10,
                    //    Height = 14,
                    //    Width = 25,
                    //    HorizontalContentAlignment = HorizontalAlignment.Center,
                    //    HorizontalAlignment = HorizontalAlignment.Center,
                    //    VerticalAlignment = VerticalAlignment.Center
                    //};
                    //CheckBox chkBox = new CheckBox()
                    //{
                    //    VerticalAlignment =  VerticalAlignment.Center,
                    //    Height = 15,
                    //    Width = 15,
                    //    Margin = new Thickness(10, 0, 10, 0),
                    //};

                    //subStack.Children.Add(lblName);
                    //subStack.Children.Add(txtScore);
                    //subStack.Children.Add(txtPoint);
                    //subStack.Children.Add(chkBox);



                    //if (i == 6)
                    //{
                    //    i = 0;
                    //    j++;
                    //}
                    //mainGrid.Children.Add(subStack);

                    //Grid.SetRow(subStack, i);
                    //Grid.SetColumn(subStack, j);
                    //i++;
                }
                return att.MainGrid;
            }
        }
        private void SetGridAbilities()
        {
            //SpecialAbilitiesGrid.RowDefinitions.Add(new RowDefinition());
            //int i = 2;
            //int j = 0;
            Label label = new Label();
            label.Content = "Point";
            label.FontSize = 10;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetRow(label, 1);
            Grid.SetColumn(label, 0);

            //using (DbModelRepository<SpecialAbility> dbModel = new DbModelRepository<SpecialAbility>(new SpecialAbility()))
            //{
            //    IQueryable<SpecialAbility> entities = dbModel.GetAll<SpecialAbility>();

            //    //RowDefinition newRow = new RowDefinition()
            //    //{
            //    //    Height = new GridLength(10),                    
            //    //};

            //    foreach (SpecialAbility item in entities)
            //    {
            //        SpecialAbilitiesGrid.RowDefinitions.Add(new RowDefinition()
            //        {
            //            Height = new GridLength(PIXELS)
            //        });

            //        item.Alias = item.Alias.Replace(" ", "_");

            //        StackPanel stack = new StackPanel()
            //        {
            //            Name = string.Concat(STACKPANELPREFIXE, SPECIALPREFIXE, item.Alias),
            //            Orientation = Orientation.Horizontal,
            //        };

            //        SubItem(stack, item.Name, null, null, i);

            //        SpecialAbilitiesGrid.Children.Add(stack);

            //        Grid.SetRow(stack, i);
            //        if (i % COLUMNS == 0) j++;
            //        Grid.SetColumn(stack, j);

            //        i++;
            //    }

            //}
        }

        private void SubItem(StackPanel stack, string name, int? score, int? point, int pos)
        {

            string itemName = stack.Name.Replace(STACKPANELPREFIXE, string.Empty);
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
                Name = string.Concat("lb_", itemName),
                Content = name,
                Margin = new Thickness(10, 0, 0, 0),
                //Width = WIDTH_LABEL,
                FontSize = 10,
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
    }
}
