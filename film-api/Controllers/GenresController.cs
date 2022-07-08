using film_api.data.Models;
using film_api.repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace film_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GenresController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IEnumerable ListGenres()
        {
            var genres = _repositoryWrapper.Movie.Get().Select(x => x.Genres);
            //HashSet<List<Genre>> genresSet = new HashSet<List<Genre>>();
            HashSet<string> names = new HashSet<string>();
            //var stuff2 = JsonConvert.DeserializeObject<List<List<Genre>>>(genres);
            //List<string> asd = stuff2.Select(x => x.Name).ToList();
            //var test = JsonConvert.SerializeObject(genres);
            //var test = JsonConvert.DeserializeObject<Genre>(genres);
            //JObject json = JObject.Parse(genres);
            //var result = JsonConvert.SerializeObject(json);
            foreach (var item in genres)
            {
                var stuff = JsonConvert.DeserializeObject<List<Genre>>(item);
                foreach(var item2 in stuff)
                {
                    names.Add(item2.Name);
                }
                
                //genresSet.Add(stuff);
            }
            //var stuff = JsonConvert.DeserializeObject<List<Genre>>(genres);
            return names;
            //return _repositoryWrapper.Movie.Get().Select(x => x.Genres);
        }
    }
}
