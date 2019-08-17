
using flightbooking.model;
using flightbooking.Model;
using flightbooking.Service;
using flightbooking.view;
using flightbooking.View;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace flightbooking
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
		private UserService userService = new UserService();

        private TicketVO tVo;
        private User user;

        internal TicketVO TVo { get => tVo; set => tVo = value; }
        public User User { get => user; set => user = value; }

        public MainPage()
        {
            this.InitializeComponent();
			initHomePage();
            tVo = new TicketVO();
        }
		

		private void menu_handler(object sender, RoutedEventArgs e)
		{
			split_view.IsPaneOpen = !split_view.IsPaneOpen;
		}

		private void menu_handler(object sender, SelectionChangedEventArgs e)
		{
			if (Home.IsSelected)
			{
				container.Navigate(typeof(HomeView), makeParam());
				back_btn.Visibility = Visibility.Collapsed;
				title.Text = "Airline";
			}
				
			else if(Profile.IsSelected)
			{
                List<object> param = new List<object>();
                param.Add(TVo);
                param.Add(user);
				container.Navigate(typeof(TicketInfoView), param);
				title.Text = "Tickert Info";
				back_btn.Visibility = Visibility.Visible;
			}
				
			else if (Setting.IsSelected)
			{
                if (user == null)
                    container.Navigate(typeof(SettingsView));
                else
                {
                    List<object> param = new List<object>();
                    param.Add(user);
                    param.Add(register_btn);
                    param.Add(login_btn);
                    param.Add(logout_btn);
                    container.Navigate(typeof(SettingsView), param);
                }
                   
				title.Text = "Setting";
				back_btn.Visibility = Visibility.Visible;
			}
				
		}
		private void initHomePage()
		{
			
			container.Navigate(typeof(HomeView), makeParam());
			back_btn.Visibility = Visibility.Collapsed;
			title.Text = "Airline";
		}

		private void backbtnHandler(object sender, RoutedEventArgs e)
		{
		
			if (container.CanGoBack)
			{
				container.GoBack();
				Home.IsSelected = true;
				title.Text = "Airline";
				back_btn.Visibility = Visibility.Collapsed;
			}
		}

		private void RegisterBtnHandler(object sender, RoutedEventArgs e)
		{
			List<object> param = new List<object>();
			param.Add(userService);
			param.Add(title);
			param.Add(back_btn);
			container.Navigate(typeof(RegisterView), param);
			title.Text = "Register";
			back_btn.Visibility = Visibility.Visible;
		}

		private void LoginBtnHandler(object sender, RoutedEventArgs e)
		{
			List<object> param= new List<object>();
			param.Add(userService);
			param.Add(container);
			param.Add(register_btn);
			param.Add(login_btn);
			param.Add(TVo);
			param.Add(logout_btn);
            param.Add(this);

			container.Navigate(typeof(LoginView), param);
			title.Text = "Login";
			back_btn.Visibility = Visibility.Visible;

		}
		private List<object> makeParam()
		{
			List<Object> param = new List<object>();
			param.Add(container);
			param.Add(title);
			param.Add(back_btn);
			param.Add(TVo);
            param.Add(user);
            return param;
		}

		private void Logout_btnHandler(object sender, RoutedEventArgs e)
		{
			ShowMessageDialog("Do you want to logout?");
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
                        logout_btn.Visibility = Visibility.Collapsed;
						login_btn.Visibility = Visibility.Visible;
						register_btn.Visibility = Visibility.Visible;
                        user = null;
                        tVo = null;
						container.Navigate(typeof(HomeView), userService);
						TVo = new TicketVO();
						break;
					}

				case "Cancel": break;
			}
		}
       
    }
}
