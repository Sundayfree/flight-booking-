using flightbooking.model;
using flightbooking.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class RegisterView : Page
    {
		private Button back_btn;
		private TextBlock title;
		private UserService userServie;
		private List<object> param;
		public RegisterView()
        {
            this.InitializeComponent();
        }

		private void submitBtn_Handler(object sender, RoutedEventArgs e)
		{
			try
			{
				string username = name_box.Text;
				string password = password_box.Text;
				string repassword = repassword_box.Text;
				string fname = fname_box.Text;
				string lname = lname_box.Text;
				userServie.Save(username, password, repassword, fname, lname);
				SystemUtils.SuccessMsg("Register Success!!!");
			}catch(Exception e1)
			{
                clearInput();
                SystemUtils.ErrorMsg(e1.Message);
			}
			

		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			if (e.Parameter.GetType().Equals(typeof(List<object>)))
			{
				param = e.Parameter as List<object>;
				userServie = param.ElementAt(0) as UserService;
				title = param.ElementAt(1) as TextBlock;
				back_btn = param.ElementAt(2) as Button;
			}
		}

        private void ResetHandler(object sender, RoutedEventArgs e)
        {
            clearInput();
        }
        private void clearInput()
        {
            name_box.Text = "";
            password_box.Text="";
            repassword_box.Text = "";
            fname_box.Text = "";
            lname_box.Text="";
        }
    }
}
