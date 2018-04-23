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
	public partial class FilterPage : ContentPage
	{
        ShelterMeWebAPIAgent agent = new ShelterMeWebAPIAgent();
		public FilterPage ()
		{
			InitializeComponent ();
		}
        private async void ListClicked(Object sender, EventArgs e) {
            ShelterInformation shelterNameList = new ShelterInformation();
            List<ShelterInformation> restrictionsList = new List<ShelterInformation>();
            List<string> nameList = new List<string>();
            string restrictionsString = "";
            if (men.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Men";
                } else {
                    restrictionsString += " Men";
                }
            }
            if (women.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Women";
                } else {
                    restrictionsString += " Women";
                }
            }
            if (newborns.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Newborns";
                } else {
                    restrictionsString += " Newborns";
                }
            }
            if (children.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Children";
                } else {
                    restrictionsString += " Children";
                }
            }
            if (youngAdults.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Young Adults";
                } else {
                    restrictionsString += " Young Adults";
                }
            }
            if (anyone.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Anyone";
                } else {
                    restrictionsString += " Anyone";
                }
            }
            Task<ShelterInformation> shelterNameListTask = Task.Run(async () => await agent.getShelterInformation(shelterName.Text));
            shelterNameList = shelterNameListTask.Result;
            Task<List<ShelterInformation>> restrictionsListTask = Task.Run(async () => await agent.getFilteredSheltersByRestrictions(restrictionsString));
            restrictionsList = restrictionsListTask.Result;
            if (shelterNameList == null) {
                foreach(ShelterInformation list in restrictionsList) {
                    nameList.Add(list.shelterName);
                }
            } else if (restrictionsList == null) {
                nameList.Add(shelterNameList.shelterName);
            } else if (shelterNameList.restrictions.Contains(restrictionsString)) {
                nameList.Add(shelterNameList.shelterName);
            }
            await Navigation.PushAsync(new FilterOptions(nameList));
        }
        private async void MapClicked(Object sender, EventArgs e) {
            ShelterInformation shelterNameList = new ShelterInformation();
            List<ShelterInformation> restrictionsList = new List<ShelterInformation>();
            List<ShelterInformation> nameList = new List<ShelterInformation>();
            string restrictionsString = "";
            if (men.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Men";
                } else {
                    restrictionsString += " Men";
                }
            }
            if (women.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Women";
                } else {
                    restrictionsString += " Women";
                }
            }
            if (newborns.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Newborns";
                } else {
                    restrictionsString += " Newborns";
                }
            }
            if (children.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Children";
                } else {
                    restrictionsString += " Children";
                }
            }
            if (youngAdults.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Young Adults";
                } else {
                    restrictionsString += " Young Adults";
                }
            }
            if (anyone.Checked) {
                if (restrictionsString == "") {
                    restrictionsString += "Anyone";
                } else {
                    restrictionsString += " Anyone";
                }
            }
            Task<ShelterInformation> shelterNameListTask = Task.Run(async () => await agent.getShelterInformation(shelterName.Text));
            shelterNameList = shelterNameListTask.Result;
            Task<List<ShelterInformation>> restrictionsListTask = Task.Run(async () => await agent.getFilteredSheltersByRestrictions(restrictionsString));
            restrictionsList = restrictionsListTask.Result;
            if (shelterNameList == null) {
                foreach (ShelterInformation list in restrictionsList) {
                    nameList.Add(list);
                }
            } else if (restrictionsList == null) {
                nameList.Add(shelterNameList);
            } else if (shelterNameList.restrictions.Contains(restrictionsString)) {
                nameList.Add(shelterNameList);
            }
            await Navigation.PushAsync(new MapPage(nameList));
        }
	}
}