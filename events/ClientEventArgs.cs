using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{
    public class ClientEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public ClientEventArgs(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            CPF = cpf;
        }
    }
}
