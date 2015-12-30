/*
Author:wge
Date:2015.10.11
Use this class to get MainWindow's Dispatcher
*/
using System.Windows.Threading;

namespace WgeMVVM.Threading
{
    public class DispatcherHelper
    {
        /// <summary>
        /// MainWindow's Dispatcher
        /// </summary>
        public static Dispatcher UIDispatcher { get; set; }
    }
}
