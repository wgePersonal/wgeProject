///Author:Wge
///Create date:11/24/2015
///Modify date:11/24/2015
///Memo:Binding command

using System;
using System.Windows.Input;

namespace WgeMVVM.Command
{
    public class WgeCommand: ICommand
    {
        /// <summary>
        /// [EN]Check if the command can execute
        /// [CN]检查命令是否可以执行的事件
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        /// <summary>
        /// [EN]The function that check if the command can execute
        /// [CN]检查命令是否可以执行的方法
        /// </summary>
        private Func<object, bool> _canExecute;

        /// <summary>
        /// [EN]The action that the command execute
        /// [CN]命令需要执行的方法
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// [EN]Create a new WgeCommand instance
        /// [CN]新建一个命令
        /// </summary>
        /// <param name="execute">
        /// [EN]The action that the command execute
        /// [CN]命令要执行的方法
        /// </param>
        public WgeCommand(Action<object> execute):this(execute,null)
        {
        }

        /// <summary>
        /// [EN]Create a new WgeCommand instance
        /// [CN]新建一个命令
        /// </summary>
        /// <param name="execute">
        /// [EN]The action that the command execute
        /// [CN]命令要执行的方法
        /// </param>
        /// <param name="canExecute">
        /// [EN]The function that check if the command can execute
        /// [CN]判断命令是否能执行的方法
        /// </param>
        public WgeCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// [EN]Method that check if the command can execute
        /// [CN]判断命令是否可以执行
        /// </summary>
        /// <param name="parameter">
        /// [EN]Command's parameter
        /// [CN]命令传人的参数
        /// </param>
        /// <returns>
        /// [EN]if the command can execute
        /// [CN]是否可以执行
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute(parameter);
        }

        /// <summary>
        /// [EN]Execute the command
        /// [CN]执行命令
        /// </summary>
        /// <param name="parameter">
        /// [EN]Command's parameter
        /// [CN]命令传人的参数
        /// </param>
        public void Execute(object parameter)
        {
            if (_execute != null && CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}
