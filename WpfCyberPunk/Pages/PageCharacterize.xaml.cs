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
using ViewModel;

namespace WpfCyberPunk.Pages
{
    /// <summary>
    /// Interaction logic for PageCharacterize.xaml
    /// </summary>
    public partial class PageCharacterize : Page
    {
        public PageCharacterize()
        {
            InitializeComponent();
        }

        private void SpecialsViewControl_Loaded(object sender, RoutedEventArgs e) 
        {
            SpecialAbilitiesViewModel vmSpecials = new SpecialAbilitiesViewModel();
            vmSpecials.LoadItems();
            SpecialsViewControl.DataContext = vmSpecials;
        }
        private void FeatureSkillsViewControl_Loaded(object sender, RoutedEventArgs e) 
        {
            SkillsViewModel vmSkills = new SkillsViewModel();
            vmSkills.LoadItems();
            FeatureSkillsViewControl.DataContext = vmSkills;
        }
    }
}
