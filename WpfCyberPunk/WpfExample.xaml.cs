using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;

namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class WpfExample : Window
    {
        public WpfExample()
        {
            InitializeComponent();
        }

        private void GetExample(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(@".\info\example.rtf", FileMode.Open, FileAccess.Read))
            {
                TextRange textRange = new TextRange(RtxBxExample.Document.ContentStart, RtxBxExample.Document.ContentEnd);
                textRange.Load(fs, DataFormats.Rtf);
            }
            //RtxBxExample.Document.Blocks.Add(new Paragraph(new Run("")));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RichText_MouseOver(object sender, EventArgs e)
        {
            string contains = string.Empty;
            string line;

            RichTextBox example = sender as RichTextBox;
            using (StreamReader sr = new StreamReader(@".\info\info.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    contains = string.Concat(contains, Environment.NewLine, line);

                }

                //toolTip.Load(fs, DataFormats.Rtf);
            }
            //ToolTip tool = new ToolTip() { Content = contains };
            ToolTip tool = new ToolTip() { Content = contains, IsOpen = true, StaysOpen = true };
            example.ToolTip = tool;
        }

        //TODO : Afficher le contenu du fichier (@".\example.rtf");

    }
}