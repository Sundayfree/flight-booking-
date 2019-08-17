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
    public sealed partial class ListTicketView : Page
    {

		private const int BUSSINESS = 0;
		private List<object> param;
		private Ticket ticket;
		private FlightService flightService = new FlightService();
		private User user;
		private TicketVO tVo;
		private Frame container;
        private Button backbtn;
		public ListTicketView()
        {
            this.InitializeComponent();
			
		}
	
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
        
			if (e.Parameter.GetType().Equals(typeof(List<object>)))
			{
				param = e.Parameter as List<object>;

				ticket = param.ElementAt(0) as Ticket;
				user = param.ElementAt(1) as User;
				container = param.ElementAt(2) as Frame;
				tVo = param.ElementAt(3) as TicketVO;
                backbtn = param.ElementAt(4) as Button;
                DateLoader();
				
			}
			else
				throw new Exception("INTERNAL ERROR");
		}
		private void DateLoader()
		{
			List<Flight> flights = flightService.GetFlights();
            List < Flight> list = flights.Where(f => f.FromCity.Equals(this.ticket.FromCity) && f.ToCity.Equals(this.ticket.ToCity)).ToList();
			listView.ItemsSource = list;
                
		}

		private void Buy_btnHandler(object sender, RoutedEventArgs e)
		{
			try
			{
                if (user==null)
					throw new Exception("Please login first...");
				if (listView.SelectedIndex < 0)
				{
					throw new Exception("Please choose your ticket first...");
				}	
				
				Flight f = listView.Items.ElementAt(listView.SelectedIndex) as Flight;
				tVo.Name = user.Username;
				tVo.FromCity = f.FromCity;
				tVo.Tocity = f.ToCity;
				tVo.TicketName = f.Name;
				tVo.LeaveDate = ticket.LeaveDate.ToString();
				tVo.Price= ticket.TypeSit == 1 ? f.Economicprice : f.Businessprice;
				tVo.SitType = ticket.TypeSit == 1 ? "Economy" : "Bussiness";
				tVo.TypeTrip = ticket.TypeTrip;
				if (ticket.TypeTrip == BUSSINESS)
					tVo.ReturnTicket = f.Name;
				tVo.ReturnDate = ticket.ReturnDate.ToString();
                ShowMessageDialog("Do you want purchase the tickert??");

			}
			catch(Exception e1)
			{
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
                        List<object> param = new List<object>();
                        param.Add(tVo);
                        param.Add(user);
                        container.Navigate(typeof(TicketInfoView), param); break;
					}

				case "Cancel": break;
			}
		}
	}
}
