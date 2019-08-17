using flightbooking.model;
using flightbooking.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace flightbooking.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class PasswordView : Page
	{
        private User user;
        private UserService userService = new UserService();
        private Button loginBtn;
        private Button rBtn;
        private Button logoutBtn;
        private string oldP;
        private string newP;
        private string rPass;
        public PasswordView()
		{
			this.InitializeComponent();
		}

		private void SubmitBtn_Handler(object sender, RoutedEventArgs e)
		{
           
                 oldP = oldp_box.Text;
                 newP = newp_box.Text;
                 rPass = rep_box.Text;
                ShowMessageDialog("Do you want to confirm your Password??");
       }
        public async void ShowMessageDialog(string content)
        {
            MessageDialog msg = new MessageDialog(content, "Information");

            msg.Commands.Add(new UICommand("Conform", new UICommandInvokedHandler(CommandHandler)));
            msg.Commands.Add(new UICommand("Cancel", new UICommandInvokedHandler(CommandHandler)));
            await msg.ShowAsync();
        }
        private void CommandHandler(IUICommand c)
        {
            string str = c.Label;
            switch (str)
            {
                case "Conform":
                {
                        try
                        {
                            userService.ChangePassword(oldP, newP, rPass, user);
                            logoutBtn.Visibility = Visibility.Collapsed;
                            loginBtn.Visibility = Visibility.Visible;
                            rBtn.Visibility = Visibility.Visible;
                            clearInput();
                        }
                        catch (Exception e1)
                        {
                            SystemUtils.ErrorMsg(e1.Message);
                        }
                        break;
                 }
                case "Cancel": clearInput();  break;
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter.GetType().Equals(typeof(List<object>)))
            {
                List<object> param = e.Parameter as List<object>;
                user = param.ElementAt(0) as User;
                rBtn = param.ElementAt(1) as Button;
                loginBtn = param.ElementAt(2) as Button;
                logoutBtn = param.ElementAt(3) as Button;
            }
        }
        private void clearInput()
        {
            oldp_box.Text="";
            newp_box.Text="";
            rep_box.Text="";
        }
    }
}
