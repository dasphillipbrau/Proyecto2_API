using Proyecto2_API.BusinessLogic;
using Proyecto2_AppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2_API.Controllers
{
    public class Campanas_PublicitariasController : ApiController
    {
        static ClientManager clientManager = new ClientManager();
        [HttpGet]
        [Route("~/api/Campanas_Publicitarias/Listar_Promociones_Mensuales")]
        public HttpResponseMessage Listar_Promociones_Mensuales(HttpRequestMessage req)
        {
            var prospects = clientManager.GetAllProspects();
            if (prospects != null)
                return req.CreateResponse<IEnumerable<Prospect>>(HttpStatusCode.OK, prospects);
            return req.CreateResponse(HttpStatusCode.NotFound, "No Prospects");
        }

        [HttpGet]
        [Route("~/api/Campanas_Publicitarias/Lista_Peores_Clientes")]
        public HttpResponseMessage Lista_Peores_Clientes(HttpRequestMessage req)
        {
            var badProspects = clientManager.GetAllBadProspects();
            if (badProspects != null)
                return req.CreateResponse<IEnumerable<BadProspect>>(HttpStatusCode.OK, badProspects);
            return req.CreateResponse(HttpStatusCode.NotFound, "No Prospects");
        }
    }
}