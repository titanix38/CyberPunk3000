using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;

        private const int WS_MAXIMIZEBOX = 0x10000; //maximize button
        private const int WS_MINIMIZEBOX = 0x20000; //minimize button

        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
        }

        private IntPtr _windowHandle;
        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            _windowHandle = new WindowInteropHelper(this).Handle;

            //disable minimize button
            DisableMinimizeButton();
            DisableMaximizeButton();
        }
        protected void DisableMaximizeButton()
        {
            if (_windowHandle == null)
                throw new InvalidOperationException("The window has not yet been completely initialized");

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MAXIMIZEBOX);
        }

        protected void DisableMinimizeButton()
        {
            if (_windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MINIMIZEBOX);
        }


        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            WpfImportTools tools = new WpfImportTools();
            tools.ShowDialog();
        }

        private void BtnImport_MouseOver(object sender, RoutedEventArgs e)
        {
            Button import = sender as Button;

            //ToolTip tool = new ToolTip() { Content = contains };
            ToolTip tool = new ToolTip() { Content = "Importer personnage depuis fichier texte", IsOpen = true, StaysOpen = true };
            import.ToolTip = tool;
        }

        private void BtnCreate_MouseOver(object sender, RoutedEventArgs e)
        {
            Button import = sender as Button;

            //ToolTip tool = new ToolTip() { Content = contains };
            ToolTip tool = new ToolTip() { Content = "Creer un nouveau personnage", IsOpen = true, StaysOpen = true };
            import.ToolTip = tool;
        }
        // TODO : A voir si on laisse
        private void BtnOpen_MouseOver(object sender, RoutedEventArgs e)
        {
            Button import = sender as Button;

            //ToolTip tool = new ToolTip() { Content = contains };
            ToolTip tool = new ToolTip() { Content = "Ouvrir feuilles personnage", IsOpen = true, StaysOpen = true };
            import.ToolTip = tool;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
