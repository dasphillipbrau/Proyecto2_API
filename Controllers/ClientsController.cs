using Proyecto2_API.BusinessLogic;
using Proyecto2_AppWeb.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2_API.Controllers
{
    public class ClientsController : ApiController
    {
        static ClientManager clientManager = new ClientManager();
        [HttpPost]
        [Route("~/api/Clients/Agregar_Cliente")]
        public HttpResponseMessage Agregar_Cliente(HttpRequestMessage req, Client client)
        {
            if (clientManager.AddClient(client))
                return req.CreateResponse<Client>(HttpStatusCode.Created, client);
            return req.CreateResponse(HttpStatusCode.BadRequest, "Client not inserted");
        }
        [HttpGet]
        [Route("~/api/Clients/Buscar_Cliente/{id}")]
        public HttpResponseMessage Buscar_Cliente(HttpRequestMessage req, string id)
        {

            Client foundClient = clientManager.FindClient(id);
            if (foundClient != null)
                return req.CreateResponse<Client>(HttpStatusCode.OK, foundClient);
            return req.CreateResponse(HttpStatusCode.NotFound, "Client not found");
        }

        [HttpPut]
        [Route("~/api/Clients/Editar_Cliente")]
        public HttpResponseMessage Editar_Cliente(HttpRequestMessage req, Client client)
        {
            if (clientManager.UpdateClient(client))
            {
                Client updatedClient = clientManager.FindClient(client.Id);
                return req.CreateResponse<Client>(HttpStatusCode.OK, updatedClient);
            }
            return req.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        [HttpGet]
        [Route("~/api/Clients/Conseguir_Clientes")]
        public HttpResponseMessage Conseguir_Clientes(HttpRequestMessage req)
        {
            var clientList = clientManager.GetAllClients();
            if (clientList != null)
                return req.CreateResponse(HttpStatusCode.OK, clientList);
            return req.CreateResponse(HttpStatusCode.NotFound, new List<Client>());
        }

    }
}
