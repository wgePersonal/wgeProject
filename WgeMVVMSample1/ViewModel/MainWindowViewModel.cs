using System;
using System.Windows;
using WgeMVVM;
using WgeMVVM.Command;

namespace WgeMVVMSample1.ViewModel
{
    public class MainWindowViewModel:ObserveObject
    {
        private bool _canExecute;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                _canExecute = value;
                RaisePropertyChanged("CanExecute");
            }
        }

        private WgeCommand _normalCommand;
        public WgeCommand NormalCommand
        {
            get
            {
                if(_normalCommand == null)
                {
                    _normalCommand = new WgeCommand(new Action<object>(o=> MessageBox.Show("This is normal wgeCommand!")));
                }
                return _normalCommand;
            }
        }

        private WgeCommand _canExecuteCommand;
        public WgeCommand CanExecuteCommand
        {
            get
            {
                if (_canExecuteCommand == null)
                {
                    _canExecuteCommand = new WgeCommand(new Action<object>(o => MessageBox.Show("This is can execute wgeCommand!")), new Func<object, bool>(o => CanExecute));                   
                }
                return _canExecuteCommand;
            }
        }

        private WgeCommand _paramCommand;
        public WgeCommand ParamCommand
        {
            get
            {
                if(_paramCommand==null)
                {
                    _paramCommand = new WgeCommand(new Action<object>(o => MessageBox.Show(o.ToString())), new Func<object, bool>(o => CanExecute));
                }
                return _paramCommand;
            }
        }
    }
}
