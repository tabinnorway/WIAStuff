using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;
using WIA;
using System.Windows;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace WIA2Stuff.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm/getstarted
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _clickCommand;
        public ICommand ClickCommand {
            get {
                if (_clickCommand == null) {
                    _clickCommand = new RelayCommand(() => ClickExecute(), () => CanClick() );
                }
                return _clickCommand;
            }
        }
        protected bool CanClick() {
            return true;
        }
        protected object ClickExecute() {
            return null;
        }


        private RelayCommand _zoomCommand;
        public ICommand ZoomCommand {
            get {
                if (_zoomCommand == null) {
                    _zoomCommand = new RelayCommand(() => ZoomExecute(), () => CanZoom());
                }
                return _zoomCommand;
            }
        }
        private bool CanZoom() {
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        private object ZoomExecute() {
            try {
                var commonDialog = new CommonDialogClass();
                Device d = commonDialog.ShowSelectDevice(WiaDeviceType.CameraDeviceType, true, false);
            }
            catch (Exception x) {
                if (x.Message.Contains(WiaError.ScannerNotAvailable)) {
                    MessageBox.Show("No compatible device installed");
                }
            }

            return null;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {
            if (IsInDesignMode) {
                // Code runs in Blend --> create design time data.
            }
            else {
                // Code runs "for real"
            }
        }
    }
}