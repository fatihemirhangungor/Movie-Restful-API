using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using film_api.data.Models;
using film_api.Controllers;
using System.Net;

namespace Watchflix.Controllers
{
    public class MovieController : Controller
    {
        private readonly DatabaseContext _context;
        public MovieController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri("https://localhost:7176/api/movies");
                HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Result: " + result);
                return View(result.ToList());
            }

            
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movieDto = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDto == null)
            {
                return NotFound();
            }

            return View(movieDto);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adult,BelongsToCollection,Budget,Genres,Homepage,Id,ImdbId,OriginalLanguage,OriginalTitle,Overview,Popularity,PosterPath,ProductionCompanies,ProductionCountries,ReleaseDate,Revenue,Runtime,SpokenLanguages,Status,Tagline,Title,Video,VoteAverage,VoteCount")] MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieDto);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movieDto = await _context.Movies.FindAsync(id);
            if (movieDto == null)
            {
                return NotFound();
            }
            return View(movieDto);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Adult,BelongsToCollection,Budget,Genres,Homepage,Id,ImdbId,OriginalLanguage,OriginalTitle,Overview,Popularity,PosterPath,ProductionCompanies,ProductionCountries,ReleaseDate,Revenue,Runtime,SpokenLanguages,Status,Tagline,Title,Video,VoteAverage,VoteCount")] MovieDto movieDto)
        {
            if (id != movieDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDtoExists(movieDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movieDto);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movieDto = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDto == null)
            {
                return NotFound();
            }

            return View(movieDto);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'DatabaseContext.Movies'  is null.");
            }
            var movieDto = await _context.Movies.FindAsync(id);
            if (movieDto != null)
            {
                _context.Movies.Remove(movieDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDtoExists(long id)
        {
          return _context.Movies.Any(e => e.Id == id);
        }
    }
}
