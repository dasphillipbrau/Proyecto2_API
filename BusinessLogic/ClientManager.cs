using Proyecto2_API.DataAccess;
using Proyecto2_AppWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2_API.BusinessLogic
{
    public class ClientManager
    {
        ClientRepository repository = new ClientRepository();
        public bool AddClient(Client client)
        {
            if (repository.GetClientById(client.Id) == null)
            {

                repository.AddClient(client);
                return true;
            }
            else
                return false;

        }

        public Client FindClient(string clientId)
        {
            Client foundClient = repository.GetClientById(clientId);
            return foundClient;
        }

        public bool UpdateClient(Client client)
        {
            if (repository.UpdateClient(client) != null)
                return true;
            else
                return false;
        }

        public IEnumerable<Prospect> GetAllProspects()
        {
            var prospects = repository.GetAllProspects();
            if (prospects.Any())
                return prospects;
            return null;
        }

        public IEnumerable<BadProspect> GetAllBadProspects()
        {
            var badProspects = repository.GetAllBadProspects();
            if (badProspects.Any())
                return badProspects;
            return null;
        }

        public IEnumerable<Client> GetAllClients()
        {
            var clients = repository.GetaAllClients();
            if (clients.Any())
                return clients;
            return null;
        }
    }
}