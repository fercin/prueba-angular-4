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

        public HttpResponseMessage Post([FromBody]Actores newactor, int? id)
        {
            //var ActorCreado = _db.Actores.First(x => x.nombre == newactor.nombre && x.apellido == newactor.apellido);

            var relacion = new PeliculaActores();

            var actor = _db.Actores.FirstOrDefault(x => x.nombre == newactor.nombre && x.apellido == newactor.apellido);
            
            var verifyRelation = _db.PeliculaActores.Where(x => x.idactor == actor.id && x.idpelicula == id.Value);

           
            
            if (actor == null)
            {

                _db.Actores.Add(newactor);
                _db.SaveChanges();
                var idactor = newactor.id;

                relacion.id = 0;
                relacion.idactor = idactor;
                relacion.idpelicula = id.Value;

                _db.PeliculaActores.Add(relacion);
                _db.SaveChanges();
                

                return new HttpResponseMessage(HttpStatusCode.Created);

            }
            

            if (verifyRelation != null) {

                relacion.idactor = actor.id;
                relacion.idpelicula = id.Value;

                _db.PeliculaActores.Add(relacion);

                _db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);

            }
            else{

               


                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            
           

           
        }


        public HttpResponseMessage Delete(int id, int? idpeli)
        {

            var relacion = _db.PeliculaActores.FirstOrDefault(x => x.idactor == id && x.idpelicula == idpeli.Value);
            var CantidadRegistro = _db.PeliculaActores.Where(x => x.idactor == id).Count();



            var deleteactor = _db.Actores.FirstOrDefault(x => x.id == id);



            if (CantidadRegistro >1)
            {
                _db.PeliculaActores.Remove(relacion);
                _db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                _db.PeliculaActores.Remove(relacion);


                _db.Actores.Remove(deleteactor);
                _db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
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
