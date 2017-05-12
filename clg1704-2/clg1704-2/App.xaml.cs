using clg17042.Services;
using clg17042.Views;
using Xamarin.Forms;

namespace clg17042
{
    public partial class App : Application
    {

		public static string BackendUrl = "https://randomuser.me/";

		// not use seed.
		// https://randomuser.me/api/?seed=foobar
		public static string BasicParams = "api/?results=20&nat=AU,BR,CA,CH,DE,DK,ES,FI,FR,GB,IE,NL,NZ,TR,US";


        public App()
        {
            InitializeComponent();

			DependencyService.Register<CloudDataStore>();

			MainPage = new NavigationPage(new ItemsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
