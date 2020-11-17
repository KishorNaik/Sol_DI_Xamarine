using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sol_Demo.UiModels
{
    public class UserUiModel : ObservableObject
    {
        private bool isCancelEnabled;

        public bool IsCancelEnabled
        {
            get => isCancelEnabled;
            set => base.SetProperty(ref isCancelEnabled, value);
        }

        private bool isSubmitEnabled;

        public bool IsSubmitEnabled
        {
            get => isSubmitEnabled;
            set => base.SetProperty(ref isSubmitEnabled, value);
        }
    }
}