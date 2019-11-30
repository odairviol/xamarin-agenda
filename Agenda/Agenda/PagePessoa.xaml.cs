using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Agenda
{
    public partial class PagePessoa : ContentPage
    {
        public PagePessoa()
        {
            InitializeComponent();
        }

        private async void OnSavePessoa(object sender, EventArgs args)
        {
            var pessoa = (Pessoa)BindingContext;
            await App.Database.SaveItemAsync(pessoa);
            await Navigation.PopAsync();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}
