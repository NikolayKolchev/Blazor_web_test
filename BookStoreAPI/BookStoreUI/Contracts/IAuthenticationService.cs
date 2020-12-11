using BookStoreUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreUI.Contracts
{
    interface IAuthenticationService
    {

        Task<bool> Registration(RegistrationModel registrationModel);
    }
}
