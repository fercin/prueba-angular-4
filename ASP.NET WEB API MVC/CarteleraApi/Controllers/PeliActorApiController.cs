using CarteleraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarteleraApi.Controllers
{
    public class PeliActorApiController : ApiController
    {

        CarteleraEntities3 _db = new CarteleraEntities3();





        public HttpResponseMessage Get()
        {

            var peliactor = _db.PeliculaActores;



            return Request.CreateResponse<IEnumerable<PeliculaActores>>(HttpStatusCode.OK, peliactor);

        }

            public HttpResponseMessage Post([FromBody]PeliculaActores peliactor)
             {

            var registro = _db.PeliculaActores.FirstOrDefault(x => x.idpelicula == peliactor.idpelicula && x.idactor == peliactor.idactor);

            if (registro == null)
            {
                _db.PeliculaActores.Add(peliactor);
                _db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }else
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

           
        }
    }
}
