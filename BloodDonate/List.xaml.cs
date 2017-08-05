using System;
using System.Collections.Generic;
using Plugin.CrossPlacePicker;
using Xamarin.Forms;

namespace BloodDonate
{
    public partial class List : ContentPage
    {
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var res = await CrossPlacePicker.Current.Display();
                var result = await Services.BasicServices.RetrieveDonors(res.Coordinates.Latitude, res.Coordinates.Longitude, Group.SelectedItem as string, 100);
                BloodList.ItemsSource = result.data;
            }
            catch (Exception xe)
            {
            }
        }

        public List()
        {
            InitializeComponent();

        }
    }
}
