using Avanade.Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Ecommerce.Mock.Storage
{
    public static class AllocationMockStorage
    {
        public static IList<User> Users { get; set; }

        public static void Initialize()
        {
            //creazione della lista vuota
            Users = new List<User>();

            //Aggiunta di utenti base
            Users.Add(new User
            {
                Id = 1111,
                UserName = "mario.rossi",
                Password = "12345",
                Email = "mario@gmail.com"
            });
            Users.Add(new User
            {
                Id = 2222,
                UserName = "giuseppe.verdi",
                Password = "abcdefh",
                Email = "giuseppe@gmail.com"
            });
        }
    }
}
