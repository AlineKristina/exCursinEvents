using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events
{
    public class Client
    {

        public event EventHandler<ClientEventArgs> AddClient;
        public event EventHandler<ClientEventArgs> RemoveClient;
        public event EventHandler Success;
        public event EventHandler Failure;

        public ICollection<ClientEventArgs> clientList = new List<ClientEventArgs>();

        public void AdicionarCliente(string name, string email, string cpf)
        {
            clientList.Add(new ClientEventArgs(name, email, cpf));
            OnAddClient(name, email, cpf);
        }

        public void RemoverCliente(string cpf)
        {
            var client = clientList.Where(x => x.CPF == cpf).FirstOrDefault();
            clientList.Remove(client);
            OnRemoveClient(client);
        }

        private void OnAddClient(string name, string email, string cpf)
        {
            var del = AddClient;
            if (del != null)
            {
                del(this, new ClientEventArgs(name, email, cpf));
            }
            else
            {
                OnFailure();
            }
        }

        private void OnRemoveClient(ClientEventArgs client)
        {
            var del = RemoveClient;

            if(del != null)
            {
                del(this, client);
            }
            else
            {
                OnFailure();
            }
        }

        private void OnSuccess()
        {
            var del = Success;
            if(del != null)
            {
                del(this, EventArgs.Empty);
            }
        }

        private void OnFailure()
        {
            var del = Failure;
            if( del != null)
            {
                del(this, EventArgs.Empty);
            }
        }

    }
}
