using System;
using System.Collections.Generic;
using BloodDonate.Models;
using BloodDonate.Services;
using Plugin.Connectivity;
using Xamarin.Forms;
using Plugin.CrossPlacePicker;
using Plugin.CrossPlacePicker.Abstractions;

namespace BloodDonate
{
    public partial class Donate : ContentPage
    {
        public Places place;
        public Donate()
        {
            InitializeComponent();
        }

        async void Handle_Clicked1(object sender, System.EventArgs e)
        {
            try
            {
                var res = await CrossPlacePicker.Current.Display();
                Place.Text = res.Name;
                Place.IsVisible = true;
                place = res;
            }
            catch (Exception xe)
            {
            }

        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (await CrossConnectivity.Current.IsRemoteReachable("http://www.google.com"))
            {
                var Donor = new Donors();
                Donor.Group = Group.SelectedItem as string;
                Donor.Name = Name.Text;
                Donor.MobileNumber = Mobile.Text;
                if (place != null)
                {
                    Donor.Latitude = place.Coordinates.Latitude;
                    Donor.Longitude = place.Coordinates.Longitude;
                }
                if (string.IsNullOrWhiteSpace(Donor.Group))
                {
                    await DisplayAlert("Error", "Group not mentioned", "OK");
                }
                var res = await BasicServices.AddBloodAsync(Donor);
                if (res.data)
                {
                    await DisplayAlert("Success", res.Message, "OK");
                }
                else
                {
                    await DisplayAlert("Error", res.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "No Internet", "OK");
            }
        }
    }
}
