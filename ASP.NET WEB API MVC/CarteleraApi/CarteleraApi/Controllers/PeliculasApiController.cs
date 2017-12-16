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
            var deletepelicula = _db.Peliculas.FirstOrDefault(x => x.id == id);

            if (peliactor != null)
            {
                _db.PeliculaActores.RemoveRange(peliactor);
                _db.SaveChanges();
            }

            
            if (deletepelicula != null)
            {
                _db.Peliculas.Remove(deletepelicula);
                _db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

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
