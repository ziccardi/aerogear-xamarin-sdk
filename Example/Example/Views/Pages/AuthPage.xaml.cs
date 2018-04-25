using System;
using AeroGear.Mobile.Auth;
using AeroGear.Mobile.Core;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;
namespace Example.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthPage : ContentPage
    {
        public AuthPage()
        {
            InitializeComponent();
            IAuthService service = MobileCore.Instance.GetInstance<IAuthService>();
            if (service.CurrentUser() != null) {
                Navigation.PushAsync(new UserDetails());
            }
        }

        public void OnAuthenticateClicked(object sender, EventArgs args)
        {
            
            IAuthService service = MobileCore.Instance.GetInstance<IAuthService>();
            Navigation.PopToRootAsync();


        }
    }
}
