using flightbooking.model;
using flightbooking.Model;
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

namespace flightbooking
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TicketInfoView : Page
    {
		private TicketVO tVo;
        private User user;
		private const int BUSINESS = 0;
		
		public TicketInfoView()
        {
            this.InitializeComponent();
        }
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
            List<object> param;
            if (e.Parameter.GetType().Equals(typeof(List<object>)))
			{

                param = e.Parameter as List<object>;
                tVo = param.ElementAt(0) as TicketVO;
                user = param.ElementAt(1) as User;
				
			}
            showInfo();


        }
        private void showInfo()
        {
            if (user==null)
            {
                PrintTitle();
            }
            else if (!String.IsNullOrEmpty(tVo.FromCity))
            {
                PrintDateInfo();
            }
            else if (user!=null)
            {
                userTille.Text = $"{user.Username} has not bought titicket..";
                tlist.Visibility = Visibility.Collapsed;
            }
        }
		private void PrintTitle()
		{
			userTille.Text = "Please login first..";
			tlist.Visibility = Visibility.Collapsed;
		}
		private  void PrintDateInfo()
		{
			tlist.Visibility = Visibility.Visible;
			
			name_block.Text = tVo.Name;
			frome_block.Text = tVo.FromCity;
			to_block.Text = tVo.Tocity;
			ticket_block.Text = tVo.TicketName;
			price_block.Text = tVo.Price;
			sit_block.Text = tVo.SitType;
			leave_block.Text = tVo.LeaveDate;
			if (tVo.TypeTrip != BUSINESS)
			{
				
				rticket_blcok.Text = tVo.TicketName;
				return_block.Text = tVo.ReturnDate;

			}

		}
	}
}
