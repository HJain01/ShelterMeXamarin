using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ShelterMe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
		public MapPage (List<ShelterInformation> shelterInfo)
		{
            try {
                InitializeComponent();
                var googleMap = map;
                
                foreach (ShelterInformation shelter in shelterInfo) {
                    Double latitude = shelter.latitude;
                    Double longitude = shelter.longitude;
                    String name = shelter.shelterName;
                    var pin = new Pin() {
                        Position = new Position(latitude, longitude),
                        Label = name,
                    };
                    pin.Clicked += new EventHandler(PinPressed);
                    map.Pins.Add(pin);
                }
                } catch (Exception ex) {
                throw ex;
            }
		}

        public async void PinPressed(Object sender, EventArgs e) {
            await Navigation.PushAsync(new InformationPage(((Pin)sender).Label));
        }
	}
}