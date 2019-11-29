using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Agenda
{
    public partial class App : Application
    {
        private static PessoaItemDatabase dataBase;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        internal static PessoaItemDatabase Database
        {
            get
            {
                if(dataBase == null)
                {
                    dataBase = new PessoaItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("PessoaSQLite.db3"));
                }
                return dataBase;
            }
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
