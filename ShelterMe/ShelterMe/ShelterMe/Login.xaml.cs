using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage {
        ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
		public Login () {
			InitializeComponent ();
		}
        private async void LoginClicked(object sender, EventArgs e) {
            Task<bool> usernameAndPasswordTask = Task.Run<bool>(async () => await agent.ContainsUsernameAndPassword(UsernameEntry.Text, PasswordEntry.Text));
            var results = usernameAndPasswordTask.Result;
            if (results) {
                await Navigation.PushAsync(new MainPage());
            } else {
                await DisplayAlert("Login Failed", "The login failed. Re-enter username and password", "Ok");
            }
        }
    }
}