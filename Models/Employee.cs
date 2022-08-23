using CadastroSoftDelete.Models;
using System;
namespace CadastroSoftDelete.Models{
    public class Employee : ISoftDelete{ //se n quiser softdelete remove Interface
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char RecStatus{ get; set; } = 'A';
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}