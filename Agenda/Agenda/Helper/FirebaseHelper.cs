using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Agenda;

namespace XamarinFirebase.Helper
{
    
    public class FirebaseHelper
    {
        readonly FirebaseClient firebase = new FirebaseClient("https://fir-xamarin-4b3dd.firebaseio.com/");

        public async Task<List<Pessoa>> GetAllPessoas()
        {

            return (await firebase
              .Child("Pessoa")
              .OnceAsync<Pessoa>()).Select(item => new Pessoa
              {
                  Email = item.Object.Email,
                  ID = item.Key,
                  Nome = item.Object.Nome,
                  Telefone = item.Object.Telefone
              }).ToList();
        }

        public async Task AddPessoa(Pessoa p)
        {
            await firebase
              .Child("Pessoa")
              .PostAsync(new Pessoa() { ID=p.ID, Email = p.Email, Telefone = p.Telefone, Nome = p.Nome });
        }

        public async Task<Pessoa> GetPessoa(string id)
        {
            var all = await GetAllPessoas();
            await firebase
              .Child("Pessoa")
              .OnceAsync<Pessoa>();
            return all.Where(a => a.ID == id).FirstOrDefault();
        }

        public async Task UpdatePessoa(Pessoa p)
        {
            var toUpdate = (await firebase
              .Child("Pessoa")
              .OnceAsync<Pessoa>()).Where(a => a.Key == p.ID).FirstOrDefault();

            await firebase
              .Child("Pessoa")
              .Child(toUpdate.Key)
              .PutAsync(new Pessoa() { ID = p.ID, Email = p.Email, Telefone = p.Telefone, Nome = p.Nome });
        }

        public async Task DeletePessoa(string id)
        {
            var toDeletePerson = (await firebase
              .Child("Pessoa")
              .OnceAsync<Pessoa>()).Where(a => a.Key == id).FirstOrDefault();
            await firebase.Child("Pessoa").Child(toDeletePerson.Key).DeleteAsync();
        }
    }
    
}
