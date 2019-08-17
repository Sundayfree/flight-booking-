using flightbooking.model;
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

namespace flightbooking.View
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class SettingsView : Page
	{
        private User user;
        List<object> param;

        public SettingsView()
		{
			this.InitializeComponent();
		}
     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           if( e.Parameter!= null)
            {
                if (e.Parameter.GetType().Equals(typeof(List<object>)))
                {
                   param = e.Parameter as List<object>;
                    user = param.ElementAt(0) as User;
                }
            }
           
        }
        
        private void itemClikeHandler(object sender, ItemClickEventArgs e)
		{
			listV = sender as ListView;
			
			if (listV.SelectedIndex == 0)
			{
				settingFrame.Navigate(typeof(AboutView));
			}

			if (listV.SelectedIndex == 1)
			{
                if(user ==null) {
                    SystemUtils.ErrorMsg("You has not login,Please Login first..");
                    return;
                }
				settingFrame.Navigate(typeof(PasswordView),param);
			}

		}
	}
}
