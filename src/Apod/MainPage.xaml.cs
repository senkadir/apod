using Apod.Interfaces;
using Apod.Items.Service;
using RestEase;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Apod
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            CoverWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
            DataWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);

            BindData();
        }

        private async void BindData()
        {
            IApodService service = RestClient.For<IApodService>($"{Application.Current.Properties[$"api-url"]}");

            var model = await service.GetTodayAsync($"{Application.Current.Properties[$"api-key"]}");

            ScreenImage.Source = ImageSource.FromUri(new Uri(model.Url));
            ScreenTitle.Text = model.Title;

            Title.Text = model.Title;
            Image.Source = ImageSource.FromUri(new Uri(model.Url));
            Date.Text = model.Date;
            Explanation.Text = model.Explanation;
            Copyright.Text = $"(c) {model.Copyright}";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var status = DependencyService.Get<IStatusBar>();

            if (status != null)
            {
                status.SetStatusBarColor(StatusBarColor.Light);
            }

            DataWrapper.TranslateTo(0, DataWrapper.HeightRequest, length: 0);
        }

        public async void Handle_Swiped(object sender, SwipedEventArgs e)
        {
            await CoverWrapper.TranslateTo(0, (CoverWrapper.Y - CoverWrapper.HeightRequest), length: 300, easing: Easing.CubicInOut);
            await DataWrapper.TranslateTo(0, 0, length: 300, easing: Easing.CubicInOut);
            await ScrollWrapper.ScrollToAsync(0, 0, false);

            var status = DependencyService.Get<IStatusBar>();

            if (status != null)
            {
                status.SetStatusBarColor(StatusBarColor.Dark);
            }
        }
    }
}
