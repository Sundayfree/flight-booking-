using flightbooking.Dao;
using flightbooking.model;
using flightbooking.Model;
using flightbooking.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class HomeView : Page
    {
		private CityService cityService = new CityService();
		private FlightService flightService = new FlightService();
		private Frame Container;
		private TextBlock title;
		private List<object> param;
		private User user;
		private TicketVO tVo;
		private Button btn;
       
      
        public HomeView()
        {
            this.InitializeComponent();
	
			CityLoader();
			SkipPassDate();
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			

			if (e.Parameter.GetType().Equals(typeof(List<object>)))
			{
				
				param = e.Parameter as List<object>;
				if (param.Count == 5)
				{
					Container = param.ElementAt(0) as Frame;
					title = param.ElementAt(1) as TextBlock;
					btn = param.ElementAt(2) as Button;
					tVo = param.ElementAt(3) as TicketVO;
                    user = param.ElementAt(4) as User;
				}
				else
				{
					user = param.ElementAt(0) as User;
					Container = param.ElementAt(1) as Frame;
					tVo = param.ElementAt(2) as TicketVO;
				}
               
			}
			
		}
		private void CityLoader()
		{

			List<City> citis = cityService.getList();
			citis.ForEach(c =>
			{
				from_combo.Items.Add(c);
				to_combo.Items.Add(c);
			});
		
		}
		public void SkipPassDate()
		{
			leave_datePicker.MinDate = DateTime.Now;
			return_datePicker.MinDate = DateTime.Now;
		}

		private void RadioHandler(object sender, RoutedEventArgs e)
		{
			RadioButton radio = sender as RadioButton;
			if (radio == oneway_Radio)
			{
				return_datePicker.IsEnabled = false;
			}
			else
			{
				return_datePicker.IsEnabled = true;
			}
		}

		private void SearchHandler(object sender, RoutedEventArgs e)
		{
			try
			{
				
				string fromCity = getComboxValue(from_combo);
				string toCity = getComboxValue(to_combo);

				if (fromCity.Equals(toCity))
					throw new Exception("Not choose the same city...");

				if (return_Radio.IsChecked==false && oneway_Radio.IsChecked==false)
					throw new Exception("Please choose your trip type...");

				if (oneway_Radio.IsChecked == false)
				{
					if (compareDates(leave_datePicker, return_datePicker))
						throw new Exception("Return date is ealier than leave date...");
				}
		
				if(leave_datePicker.Date.Value.ToString().Trim().Equals("") || leave_datePicker.Date.Value.ToString()==null)
				{
					throw new Exception("Please choose date...");
				}
						
				Ticket ticket = new Ticket();

				ticket.FromCity = fromCity;
				ticket.ToCity = toCity;
				ticket.LeaveDate = DateTime.Parse(leave_datePicker.Date.Value.ToString());
				
				if (return_Radio.IsChecked == true)
				{
					ticket.TypeTrip = 1;
					ticket.ReturnDate = DateTime.Parse(return_datePicker.Date.Value.ToString());
				}
				else
					ticket.TypeTrip = 0;
				ticket.TypeSit = ticketType.SelectedIndex==0 ? 1 : 0;
				List<object> param = new List<object>();
				param.Add(ticket);
				param.Add(user);
				param.Add(Container);
				param.Add(tVo);
                param.Add(btn);
                List<Flight> flights = flightService.GetFlights();
                List<Flight> list = flights.Where(f => f.FromCity.Equals(ticket.FromCity) && f.ToCity.Equals(ticket.ToCity)).ToList();
                if (list.Count == 0)
                    throw new Exception(" No such the Fligt...");
                Container.Navigate(typeof(ListTicketView), param);


			}
			catch (Exception e1)
			{
				SystemUtils.ErrorMsg(e1.Message);
			}
			
		}
		private string getComboxValue(ComboBox combo)
		{
			if (combo.SelectedIndex < 0)
			{
				throw new Exception("Pleasw choose the city...");
			}
			return combo.Items[combo.SelectedIndex].ToString() ;
		}
		private bool compareDates(CalendarDatePicker fromdate, CalendarDatePicker todate)
		{
			
			DateTime from = DateTime.Parse(fromdate.Date.Value.ToString());
			DateTime to = DateTime.Parse(todate.Date.Value.ToString());
			return from.CompareTo(to) > 0;
		}
	}
}
