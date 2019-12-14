using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFirebase.Helper;

namespace Agenda
{
    public partial class PagePessoa : ContentPage
    {
        readonly FirebaseHelper firebaseHelper;
        
        public PagePessoa()
        {
            InitializeComponent();
            firebaseHelper = new FirebaseHelper();
        }

        private async void OnSavePessoa(object sender, EventArgs args)
        {
            var pessoa = (Pessoa)BindingContext;
            if(pessoa.ID == null) 
            { 
                await firebaseHelper.AddPessoa(pessoa);
            }else
            {
                await firebaseHelper.UpdatePessoa(pessoa);
            }
            await Navigation.PopAsync();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}
