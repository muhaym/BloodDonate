using Xamarin.Forms;

namespace BloodDonate
{
    public partial class BloodDonatePage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new Donate());
        }

        void Handle_Clicked1(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new List());
        }

        public BloodDonatePage()
        {
            InitializeComponent();
        }
    }
}
