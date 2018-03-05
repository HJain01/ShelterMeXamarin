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
		public InformationPage (string shelterName)
		{
			InitializeComponent ();
            Task<List<string>> shelterInformationTask = Task.Run<List<string>>(async () => await agent.getShelterInformation(shelterName));
            var results = shelterInformationTask.Result;
            Console.Write(results);
        }
	}
}