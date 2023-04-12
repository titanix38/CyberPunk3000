using Data.Entities.Characterize;
using Data.Factory;
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
    /// Interaction logic for UserControlSpecialAbilities.xaml
    /// </summary>
    public partial class UserControlSpecialAbilities : UserControl
    {
        /****************************************************************************************************************/
        /*                                    CONSTANTES                                                                */
        private const int COLUMNS = 3;
        protected bool IsDisposed { get; }

        /****************************************************************************************************************/
        /****************************************************************************************************************/
        /*                                    ATTRIBUTES                                                                 */
        private int _itemCount;
        private Grid _grid;
        private int _posRow;
        private int _posCol;
        private Thickness _thicknessTxtBox = new Thickness(0, 2, 2, 5);
        private Thickness _thicknessTxtBlk = new Thickness(5, 0, 5, 5);
        private Thickness _thicknessChkBox = new Thickness(0, 2, 10, 5);
        /****************************************************************************************************************/


        public UserControlSpecialAbilities()
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
            _itemCount = 10;
            getStkPanSpecAbilities();

            grid.Children.Add(_grid);
            Grid.SetRow(_grid, 0);

            SpecialAbilitiesGrid.Children.Add(grid);
            //SpecialAbilitiesGrid.ShowGridLines = true;
            // TODO : Définir la position dans la feuille de perso
            Grid.SetRow(grid, 1);
            Grid.SetColumn(grid, 0);
        }

        private void getStkPanSpecAbilities()
        {
            Factory factory = new Factory();
            List<SpecialAbility> specials = factory.GetSpecial();
            _itemCount = specials.Count();
            InitGrid();

            _posRow = 0;
            _posCol = 0;

            foreach (var special in specials)
            {
                SetGrid(special);
            }
        }

        public void SetGrid(SpecialAbility special)
        {
            StackPanel subStack = new StackPanel
            {
                Name = "StkPan_SubItems",
                Orientation = Orientation.Horizontal,
            };

            

            foreach (var element in getEltSpecial(special))
            {
                subStack.Children.Add(element);
            }

            if (_posRow == _itemCount / COLUMNS)
            {
                _posRow = 0;
                _posCol++;
            }

            _grid.Children.Add(subStack);

            Grid.SetRow(subStack, _posRow);
            Grid.SetColumn(subStack, _posCol);
            _posRow++;
        }

        private UIElement[] getEltSpecial(SpecialAbility special)
        {
            UIElement[] elements =
            {
                new TextBlock
                {
                    Name = string.Concat("tbk_", special.Alias),
                    Text = special.Wording,
                    FontSize = 10,
                    Width = 100,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = _thicknessTxtBlk,
                },
                new TextBox
                {
                    Name = string.Concat("tbScore_", special.Alias),
                    FontSize = 10,
                    Height = 14,
                    Width = 25,
                    //Margin = _thicknessTxtBox,
                    Style = (Style)Application.Current.Resources["TextBoxSkill"],
                },
                new TextBox
                {
                    Name = string.Concat("tbPoint_", special.Alias),
                    FontSize = 10,
                    Height = 14,
                    Width = 25,
                    Style = (Style)Application.Current.Resources["TextBoxSkill"],
                },
                new CheckBox
                {
                    Name = string.Concat("Chk_",special.Alias),
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 14,
                    Margin = _thicknessChkBox,
                }
            };
            return elements;
        }

        private void InitGrid()
        {
            _grid = new Grid
            {
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            for (int i = 1; i <= _itemCount/COLUMNS; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 1; i <= COLUMNS; i++)
            {
                _grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
