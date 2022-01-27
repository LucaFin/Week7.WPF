using Avanade.Ecommerce.Core.Entities;
using Avanade.Ecommerce.Core.Repositories;
using Avanade.Ecommerce.Mock.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Ecommerce.Core.BusinessLayer
{
    public class AuthenticationBusinessLayer
    {
        private IUserRepository _userRepository;

        public AuthenticationBusinessLayer(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public Response SignIn(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
                return new Response { Success = false, Message = "Invalid username" };
            if (string.IsNullOrEmpty(password))
                return new Response { Success = false, Message = "Invalid password" };

            //verifica esistenza utente
            User existingUser = GetUserByUserName(userName);

            //se l'utente non esiste non vado oltre
            if (existingUser == null)
                return new Response { Success = false, Message = "Inexistend user" };
            //verifico che la password passata sia quella dell'utente
            if (!existingUser.Password.Equals(password))
                return new Response { Success = false, Message = "Incorrect password" };

            return new Response { Success = true, Message = $"User authenticated" };
        }

        public async Task<Response> SignInAsync(string userName, string password)
        {
            //validazione degli argomenti
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException(nameof(userName));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            //Richiamo la funzione che esegue il log-in 
            var response = SignIn(userName, password);

            /*//Simuliamo un ritardo 5 secondi
            await Task.Delay(5000);*/

            return response;
        }

        private User GetUserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;
            return _userRepository.GetByUserName(userName);
        }
    }
}
