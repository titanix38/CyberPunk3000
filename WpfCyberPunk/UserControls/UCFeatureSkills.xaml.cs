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

namespace WpfCyberPunk.UserControls
{
    /// <summary>
    /// Interaction logic for UCFeatureSkills.xaml
    /// </summary>
    public partial class UCFeatureSkills : UserControl
    {
        protected bool IsDisposed { get; }

        public UCFeatureSkills()
        {
            InitializeComponent();
            this.DataContext = new SkillsViewModel();
        }
    }
}
