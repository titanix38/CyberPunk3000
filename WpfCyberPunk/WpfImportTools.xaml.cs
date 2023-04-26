using ExportToDataBase;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace WpfCyberPunk
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WpfImportTools : Window
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;

        private const int WS_MAXIMIZEBOX = 0x10000; //maximize button
        private const int WS_MINIMIZEBOX = 0x20000; //minimize button
        public WpfImportTools()
        {
            InitializeComponent();
            this.SourceInitialized += WpfImportTools_SourceInitialized;

        }
        private IntPtr _windowHandle;

        private void WpfImportTools_SourceInitialized(object sender, EventArgs e)
        {
            _windowHandle = new WindowInteropHelper(this).Handle;

            //disable minimize button
            DisableMinimizeButton();
            DisableMaximizeButton();
        }
        protected void DisableMinimizeButton()
        {
            if (_windowHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MINIMIZEBOX);
        }

        protected void DisableMaximizeButton()
        {
            if (_windowHandle == null)
            {
                throw new InvalidOperationException("The window has not yet been completely initialized");
            }

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MAXIMIZEBOX);
        }
        private void BtnExample_Click(object sender, RoutedEventArgs e)
        {
            WpfExample example = new WpfExample();
            example.ShowDialog();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtbxFrmText.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtbxFrmText.Text))
            {
                MessageBox.Show("Aucune donnée à lire !!!", "Vide", MessageBoxButton.OK, MessageBoxImage.Error);
                //MessageBox.Show("Aucune donnée à extraire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //while (!_genderValidated)
            //{
            //    FrmGender frm = new FrmGender();

            //    DialogResult dialogResult = frm.ShowDialog();
            //    switch (dialogResult)
            //    {
            //        case DialogResult.OK:
            //            _gender = frm.GenderValue;
            //            _genderValidated = true;
            //            btnChangeGender.Enabled = true;
            //            break;
            //        case DialogResult.Cancel:
            //            return;
            //        default:
            //            return;
            //    }
            //}
            Export();
        }

        private void Export()
        {
            string message;
            //try
            //{
            Export import = new Export();

            //import.ImportText(txtBox_Appt.Text, _gender);
            import.ImportText(TxtbxFrmText.Text, "Homme");
            if (import.Success)
            {
                message = import.Message + Environment.NewLine + "Voulez-vous exporter un autre personnage ?";
                //DialogResult answer = MessageBox.Show(message, "Succés", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                //switch (answer)
                //{
                //    case DialogResult.None:
                //        break;
                //    case DialogResult.OK:
                //        break;
                //    case DialogResult.Cancel:
                //        break;
                //    case DialogResult.Abort:
                //        break;
                //    case DialogResult.Retry:
                //        break;
                //    case DialogResult.Ignore:
                //        break;
                //    case DialogResult.Yes:
                //        btn_Clear.PerformClick();
                //        break;
                //    case DialogResult.No:
                //        break;
                //    default:
                //        break;
                //}
            }
            //}
            //catch (CharacterException e)
            //{
            //    //GetErrorMessage(e, Error.InvalidData);
            //}
        }



    }
}
