using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using DelegateCommandExample.Helpers;
using System.Diagnostics;

namespace DelegateCommandExample.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(() => Message);
                }
            }
        }

        private bool _isClickButtonEnable;
        public bool IsClickButtonEnable
        {
            get
            {
                return _isClickButtonEnable;
            }
            set
            {
                if(_isClickButtonEnable != value)
                {
                    _isClickButtonEnable = value;
                    RaisePropertyChanged(() => IsClickButtonEnable);
                }
            }
        }

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand;
            }

            private set { }
        }

        public MainWindowViewModel()
        {
            _clickCommand = new DelegateCommand(Click, CanExecuteClick);
            _isClickButtonEnable = true;
        }

        private int _count = 0;
        private void Click()
        {
            _count++;
            Message = string.Format("Click #{0}", _count);
        }

        private bool CanExecuteClick()
        {
            Debug.WriteLine("called CanExecuteClick: {0}", DateTime.Now);

            return IsClickButtonEnable;
        }
    }
}
