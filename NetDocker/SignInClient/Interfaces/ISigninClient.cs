using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInClient.Interfaces
{
    public interface ISigninClient
    {
        public Task<bool> SignInAsync(string username, string password);
    }
}
