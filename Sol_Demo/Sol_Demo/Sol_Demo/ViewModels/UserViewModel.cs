using MvvmHelpers;
using Sol_Demo.Models;
using Sol_Demo.Services;
using Sol_Demo.UiModels;
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
            UserUiM = new UserUiModel();

            UserUiM.IsCancelEnabled = true;
            UserUiM.IsSubmitEnabled = false;

            DisplayCommand = new Command(() => this.OnDisplay());
            CancelCommand = new Command<ContentPage>((contentPage) => this.OnCancel(contentPage));
        }

        private UserModel userM;

        public UserModel UserM
        {
            get => userM;
            set => base.SetProperty(ref userM, value);
        }

        private UserUiModel userUiM;

        public UserUiModel UserUiM
        {
            get => userUiM;
            set => base.SetProperty(ref userUiM, value);
        }

        private String display;

        public String Display
        {
            get => display;
            set => SetProperty(ref display, value);
        }

        public ICommand DisplayCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        private void OnDisplay()
        {
            Display = userService.DisplayUsers(UserM);
            UserUiM.IsCancelEnabled = false;
            UserUiM.IsSubmitEnabled = true;
        }

        private void OnCancel(ContentPage contentPage)
        {
            Display = String.Empty;
            UserM.FirstName = String.Empty;
            UserM.LastName = String.Empty;
            UserUiM.IsSubmitEnabled = false;
            UserUiM.IsCancelEnabled = true;

            Entry entryObj = contentPage.FindByName<Entry>("txtFirstName");
            entryObj.Focus();
        }
    }
}