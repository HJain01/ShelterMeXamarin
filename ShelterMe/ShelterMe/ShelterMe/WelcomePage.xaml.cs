using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent ();
		}
        private async void LoginOnClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new Login());
        }
        private async void SignUpClicked(Object sender, EventArgs e) {
            await Navigation.PushAsync(new Registration());
        }
    }
}