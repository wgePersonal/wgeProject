﻿/*
Author:wge
Date:2015.10.11
to save View and it's ViewModel,MessageRegister
*/
using WgeMVVM.Message;
using System;

namespace WgeMVVM.ViewModel
{
    public class ViewModelInfo
    {
        /// <summary>
        /// View's type
        /// </summary>
        public Type ViewType { get; private set; }
        
        /// <summary>
        /// ViewModel's type
        /// </summary>
        public Type ViewModelType { get; private set; }

        /// <summary>
        /// MessageRegister's type
        /// </summary>
        public Type MsgRegisterType { get; private set; }

        /// <summary>
        /// View's token
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// create a new ViewModelInfo
        /// </summary>
        /// <param name="view">View's type</param>
        /// <param name="viewModel">ViewModel's type</param>
        /// <param name="msgRegister">MessageRegister's type</param>
        /// <param name="token">ViewModel's token</param>
        public ViewModelInfo(Type view, Type viewModel, Type msgRegister = null, string token = "")
        {
            ViewType = view;
            ViewModelType = viewModel;
            MsgRegisterType = msgRegister;
            Token = token;
        }

        /// <summary>
        /// Get a new instance of ViewModel
        /// </summary>
        /// <returns></returns>
        public ViewModelBase GetViewModelInstance()
        {
            if (ViewModelType == null) return null;
            return ViewModelType
                .Assembly
                .CreateInstance(ViewModelType.FullName)
                as ViewModelBase;
        }

        /// <summary>
        /// Get a new instance of MessageRegister
        /// </summary>
        /// <returns></returns>
        public IMessageRegister GetMsgRegisterInstance()
        {
            if (MsgRegisterType == null) return null;
            return MsgRegisterType
                .Assembly
                .CreateInstance(MsgRegisterType.FullName)
                as IMessageRegister;
        }
    }
}
