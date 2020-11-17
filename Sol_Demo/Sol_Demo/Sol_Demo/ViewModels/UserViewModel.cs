using MvvmHelpers;
using Sol_Demo.Models;
using Sol_Demo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sol_Demo.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private readonly IUserService userService = null;

        public UserViewModel(IUserService userService)
        {
            this.userService = userService;
            UserM = new UserModel();

            IsCancelEnabled = true;
            IsSubmitEnabled = false;

            DisplayCommand = new Command(() => this.OnDisplay());
            CancelCommand = new Command<ContentPage>((contentPage) => this.OnCancel(contentPage));
        }

        private UserModel userM;

        public UserModel UserM
        {
            get => userM;
            set => base.SetProperty(ref userM, value);
        }

        private String display;

        public String Display
        {
            get => display;
            set => SetProperty(ref display, value);
        }

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

        public ICommand DisplayCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        private void OnDisplay()
        {
            Display = userService.DisplayUsers(UserM);
            IsCancelEnabled = false;
            IsSubmitEnabled = true;
        }

        private void OnCancel(ContentPage contentPage)
        {
            Display = String.Empty;
            UserM.FirstName = String.Empty;
            UserM.LastName = String.Empty;
            IsSubmitEnabled = false;
            IsCancelEnabled = true;

            Entry entryObj = contentPage.FindByName<Entry>("txtFirstName");
            entryObj.Focus();
        }
    }
}