using flightbooking.model;
using flightbooking.Model;
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

namespace flightbooking.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
		private UserService userServie;
		private List<object> param;
		private Frame Container;
		private Button register_btn;
		private Button login_btn;
		private TicketVO tVo;
		private User user = new User();
		private Button logout_btn;
        private MainPage page;
		public LoginView()
        {
            this.InitializeComponent();
        }
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{

			if (e.Parameter.GetType().Equals(typeof(List<object>)))
			{
				param = e.Parameter as List<object>;
				userServie = param.ElementAt(0) as UserService;
				Container = param.ElementAt(1) as Frame;
				register_btn = param.ElementAt(2) as Button;
				login_btn = param.ElementAt(3) as Button;
				tVo = param.ElementAt(4) as TicketVO;
				logout_btn = param.ElementAt(5) as Button;
                page = param.ElementAt(6) as MainPage;
			}

			else
				throw new Exception("INTERNAL ERROR");
		}

		private void LoginBtnHandler(object sender, RoutedEventArgs e)
		{
			try
			{
				string name = name_box.Text;
				string password = pass_box.Text;

				bool result = userServie.login(name, password);

				
				if (result)
				{
					user = userServie.getCurrentUser();
                    page.User = user;

                    ShowMessageDialog("Do you want login??");
					clearBox();
					return;
				}
				
			}
			catch(Exception e1)
			{
				clearBox();
				SystemUtils.ErrorMsg(e1.Message);
			}
			
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
						login_btn.Visibility = Visibility.Collapsed;
						register_btn.Visibility = Visibility.Collapsed;
						logout_btn.Visibility = Visibility.Visible;
						List<object> param = new List<object>();
						param.Add(user);
						param.Add(Container);
						param.Add(tVo);
						Container.Navigate(typeof(HomeView), param);
						break;
				}
					
				case "Cancel": break;
			}
		}
		private void clearBox()
		{
			name_box.Text="";
			pass_box.Text="";
		}
	}
	
}
