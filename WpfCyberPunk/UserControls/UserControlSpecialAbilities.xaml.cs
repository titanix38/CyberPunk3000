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
        private const int COLUMNS = 3;
        /****************************************************************************************************************/
        /****************************************************************************************************************/
        /*                                    ATTRIBUTES                                                                 */
       
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
            
            RowDefinition rowData = new RowDefinition();
            grid.RowDefinitions.Add(rowData);
            Grid gridData = getStkPanSpecAbilities();

            grid.Children.Add(gridData);
            Grid.SetRow(gridData, 0);
            
            SpecialAbilitiesGrid.Children.Add(grid);
            Grid.SetRow(grid, 1);
            Grid.SetColumn(grid, 0);
        }

        private Grid getStkPanSpecAbilities()
        {
            using (DbModelRepository<SpecialAbility> dbModel =
                new DbModelRepository<SpecialAbility>(new SpecialAbility()))
            {
                IQueryable<SpecialAbility> specials = dbModel.GetAll<SpecialAbility>();

                SkillIHM spAbil = new SkillIHM(specials.Count(), COLUMNS);
                
                foreach (var special in specials)
                {
                    spAbil.Alias = special.Alias;
                    spAbil.Name = special.Name;
                    spAbil.SetGrid();
                }
                return spAbil.MainGrid;
            }
        }
    }
}
