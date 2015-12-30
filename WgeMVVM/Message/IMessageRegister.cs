/*
Author:wge
Date:2015.10.11
interface of MessageRegister
*/

namespace WgeMVVM.Message
{
    public interface IMessageRegister
    {
        object RegInstance { get; set; }
        IMessageManager MsgManager { get; set; }
        void Register();
    }
}
