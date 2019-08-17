using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace flightbooking
{
	static class SystemUtils
	{
		public async static void ErrorMsg(string content)
		{
			MessageDialog msg = new MessageDialog(content, "Error");
			await msg.ShowAsync();
		}
		public async static void SuccessMsg(string content)
		{
			MessageDialog msg = new MessageDialog(content, "Success");
			await msg.ShowAsync();
		}
		
	}
}
