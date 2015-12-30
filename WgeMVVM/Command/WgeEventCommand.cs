
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace WgeMVVM.Command
{
    public class WgeEventCommand : TriggerAction<DependencyObject>
    {

        /// <summary>
        /// Command to bind
        /// </summary>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MsgName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(WgeEventCommand), new PropertyMetadata(null));

        /// <summary>
        /// Command parameter
        /// </summary>
        public object CommandParateter
        {
            get { return (object)GetValue(CommandParateterProperty); }
            set { SetValue(CommandParateterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandParateter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParateterProperty =
            DependencyProperty.Register("CommandParateter", typeof(object), typeof(WgeEventCommand), new PropertyMetadata(null));

        protected override void Invoke(object parameter)
        {
            if (CommandParateter != null)
                parameter = CommandParateter;
            var cmd = GetCommand();
            if (cmd != null)
                cmd.Execute(parameter);
        }

        private ICommand GetCommand()
        {
            return Command;
        }
    }
}
