using CarteleraApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarteleraApi.Controllers
{
    public class PeliculasApiController : ApiController
    {

        private CarteleraEntities3 _db = new CarteleraEntities3();




        //public HttpResponseMessage Get(int id)
        //{

        //    var pelicula = _db.Peliculas.FirstOrDefault(x => x.id == id);

        //    return Request.CreateResponse<Peliculas>(HttpStatusCode.OK, pelicula);
        //}

  

        public HttpResponseMessage Get()
        {
            var peliculas = _db.Peliculas;

            return Request.CreateResponse<IEnumerable<Peliculas>>(HttpStatusCode.OK, peliculas);
        }

        public HttpResponseMessage Get(int? id)
        {
            var pelicula = _db.Peliculas.FirstOrDefault(x => x.id == id);
            return Request.CreateResponse<Peliculas>(HttpStatusCode.OK, pelicula);
        }

        public HttpResponseMessage Post([FromBody]Peliculas newpeli)
        {

            _db.Peliculas.Add(newpeli);
            _db.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }


        public HttpResponseMessage Delete(int id)
        {

            var peliactor = _db.PeliculaActores.Where(x => x.idpelicula == id);
            var idpelicula = _db.Peliculas.Find(id);
        
            foreach (var objecto in peliactor)
            {
                var sqlActores = _db.PeliculaActores.Where(x => x.idactor == objecto.Actores.id).Count();
                var actor = _db.Actores.Find(objecto.Actores.id);

                if (sqlActores <= 1)
                {
                    _db.PeliculaActores.Remove(objecto);
                    _db.Actores.Remove(actor);
                    
                }else
                {
                    _db.PeliculaActores.Remove(objecto);
                }
              
            }

            _db.Peliculas.Remove(idpelicula);

            _db.SaveChanges();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
            

        public HttpResponseMessage Put([FromBody]Peliculas oldpeli)
        {

            var putpelicula = _db.Peliculas.FirstOrDefault(x => x.id == oldpeli.id);

            if (putpelicula != null)
            {
                putpelicula.titulo = oldpeli.titulo;
                putpelicula.genero = oldpeli.genero;
                putpelicula.ano = oldpeli.ano;
                putpelicula.sinopsis = oldpeli.sinopsis;

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
