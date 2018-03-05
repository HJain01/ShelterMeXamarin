using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registration : ContentPage
	{
        ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
		public Registration ()
		{
			InitializeComponent ();
		}
        private async void signUpClicked(Object sender, EventArgs e) {
            agent.EnterData(FirstName.Text, LastName.Text, Email.Text, Password.Text, UserType.Items[UserType.SelectedIndex]);
            await Navigation.PushAsync(new Login());
        }
    }
}