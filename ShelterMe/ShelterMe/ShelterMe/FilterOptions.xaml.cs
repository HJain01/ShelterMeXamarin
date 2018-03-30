using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterOptions : ContentPage {
		public FilterOptions (List<string> nameList) {
            InitializeComponent();
            if (!nameList.Any()) {
                EmptyMessage.IsVisible = true;
            }
            var layout = shelterStack;
            foreach (string name in nameList) {
                var button = new Button {
                    Text = name
                };
                button.Clicked += new EventHandler(ShelterNameClicked);
                layout.Children.Add(button);
            }
        }
        private async void ShelterNameClicked(Object sender, EventArgs e) {
            await Navigation.PushAsync(new InformationPage(((Button)sender).Text));
        }
	}
}