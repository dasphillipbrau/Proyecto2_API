using Proyecto2_AppWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto2_API.DataAccess
{
    public class ClientRepository
    {
        public void AddClient(Client client)
        {
            using (var context = new ClientContext())
            {
                context.Cliente.Add(client);
                if (client.AcUnitsPurchased >= 2 && client.RecentPurchasesAmount > 1000000)
                    context.Prospecto.Add(new Prospect(client));
                if (client.LastYearPurchases < 300000 || client.RecentPurchasesAmount == 0)
                    context.MalProspecto.Add(new BadProspect(client));
                context.SaveChanges();
            }
        }

        public IEnumerable<Client> GetaAllClients()
        {
            using (var context = new ClientContext())
            {
                return context.Cliente.ToList<Client>();
            }
        }

        public Client GetClientById(string clientId)
        {

            using (var context = new ClientContext())
            {

                if (context.Cliente.SingleOrDefault(c => c.Id.Equals(clientId)) == null)
                    return null;
                else
                    return context.Cliente.SingleOrDefault(c => c.Id.Equals(clientId));
            }

        }

        public Client UpdateClient(Client client)
        {
            using (var context = new ClientContext())
            {
                context.Cliente.Update(client);
                context.SaveChanges();
                return context.Cliente.SingleOrDefault(c => c.Id.Equals(client.Id));
            }
        }

        public IEnumerable<Prospect> GetAllProspects()
        {
            using (var context = new ClientContext())
            {
                return context.Prospecto.ToList<Prospect>();
            }
        }

        public IEnumerable<BadProspect> GetAllBadProspects()
        {
            using (var context = new ClientContext())
            {
                return context.MalProspecto.ToList<BadProspect>();
            }
        }
    }
}