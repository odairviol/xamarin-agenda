using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetItemAsync();
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

    }
}
