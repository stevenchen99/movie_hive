using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieHive.DTOs;
using MovieHive.Models;
using MovieHive.Repositories.Interfaces;

namespace MovieHive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies()
        {
            try
            {
                var movies = await _unitOfWork.repoMovie.GetAll();
                var movieListDTOs = _mapper.Map<IEnumerable<MovieDTO>>(movies);
                return Ok(movieListDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        // GET: api/Movie/1
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            var movie = await _unitOfWork.repoMovie.Get(m => m.Id == id);

            if (movie == null)
                return NotFound();

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return Ok(movieDTO);
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult> CreateMovie(Movie movie)
        {
            DateTime currentTimestamp = DateTime.Now;
            movie.CreatedAt = currentTimestamp;
            movie.UpdatedAt = currentTimestamp;
            movie.CreatedBy = 0;
            movie.UpdatedBy = 0;

            try
            {
                await _unitOfWork.repoMovie.Add(movie);
                await _unitOfWork.Save();

                return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDTO movieUpdateDTO)
        {
            try
            {
                var existingMovie = await _unitOfWork.repoMovie.Get(m => m.Id == id);
                if (existingMovie == null)
                    return NotFound();

                existingMovie.UpdatedAt = DateTime.Now;
                existingMovie.UpdatedBy = 0;

                var newMovie = _mapper.Map<Movie>(movieUpdateDTO);
                _unitOfWork.repoMovie.Update(existingMovie, newMovie);
                await _unitOfWork.Save();

                return await GetMovieById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal Server Error: {e.Message}");
            }
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _unitOfWork.repoMovie.Get(m => m.Id == id);
            if (movie == null)
                return NotFound();

            _unitOfWork.repoMovie.Remove(movie);
            await _unitOfWork.Save();

            return Ok(new { id });
        }
    }
}
