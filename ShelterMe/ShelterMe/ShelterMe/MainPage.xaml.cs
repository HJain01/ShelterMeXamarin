using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage {
        UserInformation userIn = new UserInformation();
        List<ShelterInformation> shelterInfo = new List<ShelterInformation>();
        ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
        public MainPage(UserInformation user) {
            InitializeComponent();
            userIn = user;
            if (userIn.userType == "User" || userIn.userType == "user") {
                AddShelter.IsVisible = false;
            }
            Task<List<ShelterInformation>> shelterInfoTask = Task.Run(async () => await agent.GetShelterInformation());
            shelterInfo = shelterInfoTask.Result;
            List<string> shelterNames = new List<string>();
            Task.Delay(1000);
            Task<List<string>> shelterNameListTask = Task.Run(async () => await agent.getShelterNames());
            shelterNames = shelterNameListTask.Result;
            var layout = stack;
            foreach (string name in shelterNames) {
                var button = new Button {
                    Text = name
                };
                button.Clicked += new EventHandler(ShelterSelected);
                layout.Children.Add(button);
            }
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
        private async void AddShelterClicked(Object sender, EventArgs e) {
            await Navigation.PushAsync(new AddShelterPage(userIn));
        }
        public async void MapSelected(Object sender, EventArgs e) {
            await Navigation.PushAsync(new MapPage(shelterInfo));
        }
    }
}
