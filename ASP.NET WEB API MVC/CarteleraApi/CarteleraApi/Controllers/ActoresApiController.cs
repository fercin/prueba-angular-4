using CarteleraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarteleraApi.Controllers
{
    public class ActoresApiController : ApiController
    {
        private CarteleraEntities3 _db = new CarteleraEntities3();




        public HttpResponseMessage Get(int id)
        {
            var actor = _db.Actores.FirstOrDefault(x => x.id == id);

            return Request.CreateResponse<Actores>(HttpStatusCode.OK, actor);

        }

        public HttpResponseMessage Get()
        {

            var actores = _db.Actores;
  
            return Request.CreateResponse<IEnumerable<Actores>>(HttpStatusCode.OK, actores);

        }

        public HttpResponseMessage Post([FromBody]Actores newactor)
        {
         
            var actor = _db.Actores.FirstOrDefault(x => x.nombre == newactor.nombre && x.apellido == newactor.apellido);

            if (actor == null)
            {
                _db.Actores.Add(newactor);
                _db.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.Created);

            }
            else{
                
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            
           

           
        }


        public HttpResponseMessage Delete(int id)
        {

            var peliactor = _db.PeliculaActores.Where(x => x.idactor == id);
            var deleteactor = _db.Actores.FirstOrDefault(x => x.id == id);

            if (peliactor != null)
            {
                _db.PeliculaActores.RemoveRange(peliactor);
                _db.SaveChanges();
            }



            
            if (deleteactor != null)
            {
                _db.Actores.Remove(deleteactor);
                _db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }

        public HttpResponseMessage Put([FromBody]Actores oldactor)
        {

            var putactor = _db.Actores.FirstOrDefault(x => x.id == oldactor.id);

            if (putactor != null)
            {
                putactor.nombre = oldactor.nombre;
                putactor.apellido= oldactor.apellido;
                putactor.sexo = oldactor.sexo   ;
               

                _db.SaveChanges();

                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }

    }
}
