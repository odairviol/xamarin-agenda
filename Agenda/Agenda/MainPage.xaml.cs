using System;
using Xamarin.Forms;
using XamarinFirebase.Helper;

namespace Agenda
{
    public partial class MainPage : ContentPage
    {
        readonly FirebaseHelper firebaseHelper;
        public MainPage()
        {
            InitializeComponent();
            firebaseHelper = new FirebaseHelper();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await firebaseHelper.GetAllPessoas();
        }

        private void onItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if(args != null) {
                Navigation.PushAsync(new PagePessoa()
                {
                    BindingContext = args.SelectedItem as Pessoa
                });
            }
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PagePessoa()
            {
                BindingContext = new Pessoa(),

            });
        }

        private async void OnDelete(object sender, SelectedItemChangedEventArgs args)
        {
            var pessoa = args.SelectedItem as Pessoa;
            await firebaseHelper.DeletePessoa(pessoa.ID);
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var pessoa = mi.CommandParameter as Pessoa;
            await firebaseHelper.DeletePessoa(pessoa.ID);
            listView.ItemsSource = await firebaseHelper.GetAllPessoas();
            await DisplayAlert("Alerta", "Contato removido com sucesso.", "OK");
        }
    }
}
