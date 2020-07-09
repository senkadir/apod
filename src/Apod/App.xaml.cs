using Xamarin.Forms;

namespace Apod
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Current.Properties["api-key"] = "X9kVgfYjlDhPPfyJ6ZddbhNY4hOw052jIvoCNgU4";
            Current.Properties["api-url"] = $"https://api.nasa.gov/planetary/apod";

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
