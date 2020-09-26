using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Data;
using Music.Service.Models;

namespace Music.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMusicRepository _musicRepository;

        public MusiciansController( IMapper mapper, IMusicRepository musicRepository)
        {
            _mapper = mapper;
            _musicRepository = musicRepository;
        }

        // GET: api/Musicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicianModel>>> GetMusicians(string musician_name)
        {
            try
            {
                var musicians = await _musicRepository.GetMusiciansWithAlbums(musician_name);
                return _mapper.Map<MusicianModel[]>(musicians);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
