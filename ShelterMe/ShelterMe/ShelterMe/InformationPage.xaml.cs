using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe {
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformationPage : ContentPage
	{
        ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
        UserInformation user = new UserInformation();
        ShelterInformation shelter = new ShelterInformation();
		public InformationPage (string shelterName)
		{
			InitializeComponent ();
            Task<ShelterInformation> shelterInformationTask = Task.Run(async () => await agent.getShelterInformation(shelterName));
            var results = shelterInformationTask.Result;
            UniqueKey.Text = results.uniqueKey.ToString();
            ShelterName.Text = results.shelterName;
            Capacity.Text = results.capacity.ToString();
            Restrictions.Text = results.restrictions;
            Longitude.Text = results.longitude.ToString();
            Latitude.Text = results.latitude.ToString();
            Address.Text = results.address;
            PhoneNumber.Text = results.phoneNumber;
        }
        private async void ReserveClicked(Object sender, EventArgs e) {
            var action = await DisplayActionSheet("Reserve A Room", "Cancel", "Reserve");
            if (action.Equals("Reserve") && user.claimedARoom == false && Convert.ToInt32(Capacity.Text) != 0) {
                agent.reduceCapacity(Convert.ToInt32(UniqueKey.Text), ShelterName.Text, Convert.ToInt32(Capacity.Text), Restrictions.Text, (float) Convert.ToDouble(Longitude.Text), (float) Convert.ToDouble(Latitude.Text), Address.Text, PhoneNumber.Text);
                user.claimedARoom = true;
                LeaveRoom.IsVisible = true;
                await Navigation.PushAsync(new MainPage());
            } else {
                await DisplayAlert("Cannot reserve room", "You cannot reserve a room because either you already have a room reserved or the capacity is 0", "Ok");
            }
        }
        private async void LeaveRoomClicked(Object sender, EventArgs e) {
            var action = await DisplayActionSheet("Leave Room", "Cancel", "Confirm");
            if (action.Equals("Confirm") && user.claimedARoom == true) {
                agent.increaseCapacity(Convert.ToInt32(UniqueKey.Text), ShelterName.Text, Convert.ToInt32(Capacity.Text), Restrictions.Text, (float)Convert.ToDouble(Longitude.Text), (float)Convert.ToDouble(Latitude.Text), Address.Text, PhoneNumber.Text);
                user.claimedARoom = false;
                LeaveRoom.IsVisible = false;
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}