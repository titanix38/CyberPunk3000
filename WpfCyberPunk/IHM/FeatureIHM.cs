using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfCyberPunk.IHM
{
    public class FeatureIHM
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public StackPanel Stack { get; set; }


        public void SetStackPanel()
        {
            Label lblName = new Label()
            {
                Name = string.Concat("lb_", Alias),
                Content = Name,
                FontSize = 10,
                Width = 100
            };
            TextBox txtScore = new TextBox()
            {
                Name = string.Concat("tbScore_", Alias),
                FontSize = 10,
                Height = 14,
                Width = 25,
                Margin = new Thickness(0, 0, 5, 0),
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            TextBox txtPoint = new TextBox()
            {
                Name = string.Concat("tbPoint_", Alias),
                FontSize = 10,
                Height = 14,
                Width = 25,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            CheckBox chkBox = new CheckBox()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Height = 14,
                //Width = 14,
                Margin = new Thickness(10, 0, 10, 0),
            };

            Stack.Children.Add(lblName);
            Stack.Children.Add(txtScore);
            Stack.Children.Add(txtPoint);
            Stack.Children.Add(chkBox);
        }

    }
}
