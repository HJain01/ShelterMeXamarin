using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShelterMe {
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddShelterPage : ContentPage
	{
        UserInformation userIn = new UserInformation();
        public AddShelterPage (UserInformation user)
		{
			InitializeComponent ();
            userIn = user;
		}
        private async void AddShelter2Clicked(Object sender, EventArgs e) {
            ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
            int newId = 0;
            Task<int> getLastIdTask = Task.Run(async () => await agent.getLastID());
            newId = getLastIdTask.Result + 1;
            string restrictionsString = "";
            if (men.Checked) {
                restrictionsString += "Men ";
            }
            if (women.Checked) {
                restrictionsString += "Women ";
            }
            if (newborns.Checked) {
                restrictionsString += "newborns ";
            }
            if (children.Checked) {
                restrictionsString += "Children ";
            }
            if (youngAdults.Checked) {
                restrictionsString += "Young Adults ";
            }
            if (veterans.Checked) {
                restrictionsString += "Veterans ";
            }
            if (Anyone.Checked) {
                restrictionsString += "Anyone ";
            }
            agent.EnterShelterData(newId, shelterName.Text, Convert.ToInt32(capacity.Text), restrictionsString, (float) Convert.ToDouble(longitude.Text), (float) Convert.ToDouble(latitude.Text), address.Text, phoneNumber.Text);
            await Navigation.PushAsync(new MainPage(userIn));
        }
	}
}