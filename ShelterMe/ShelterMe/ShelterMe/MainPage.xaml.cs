using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage {
		public MainPage() {
			InitializeComponent();
		}
        protected override bool OnBackButtonPressed() {
            return true;
        }
        private async void onLogoutClicked(Object sender, EventArgs e) {
            await Navigation.PopToRootAsync();
        }
        private async void ShelterSelected(Object sender, EventArgs e) {
            await Navigation.PushAsync(new InformationPage(((Button)sender).Text));
        }
        private async void FilterClicked(Object sender, EventArgs e) {
            await Navigation.PushAsync(new FilterPage());
        }
    }
}
