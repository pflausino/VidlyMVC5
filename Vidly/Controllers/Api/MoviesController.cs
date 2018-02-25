using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<MoviesDTO> GetMovies()
        {
            return _context.Movies
                .Include(g => g.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MoviesDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MoviesDTO>(movie));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDTO moviesDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MoviesDTO, Movie>(moviesDto);
                _context.Movies.Add(movie);
                _context.SaveChanges();

                moviesDto.Id = movie.Id;

                return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);
            }
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateMovie(int Id, MoviesDTO moviesDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == Id);
                if (movieInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                Mapper.Map(moviesDto, movieInDb);

                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (MovieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
        }
    }
}
