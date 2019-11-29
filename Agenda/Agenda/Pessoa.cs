using System;
using SQLite;
namespace Agenda
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public uint ID { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public String Email { get; set; }
    }
}
