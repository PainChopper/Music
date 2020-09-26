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
    [Route("api/Albums/{albumId:int}/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IMusicRepository _repository;
        private readonly IMapper _mapper;

        public TracksController(IMusicRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackModel>>> GetTracks(int albumId)
        {
            try
            {
                var tracks = await _repository.GetTracks(albumId);
                return _mapper.Map<TrackModel[]>(tracks);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPut("{trackId:int}")]
        public async Task<ActionResult<TrackModel>> PutTrack(int albumId, int trackId, TrackModel trackModel)
        {
            try
            {
                if (trackId != trackModel.Id)
                    return BadRequest("Cannot match the track ID");
                var track = await _repository.GetTrackByAlbum(albumId, trackId);
                if (track == null)
                    return NotFound("Couldn't find the track");

                track.IsFavorite = trackModel.IsFavorite;
                track.Rating = trackModel.Rating;
                track.IsListened = trackModel.IsListened;

                if (!_repository.HasChanges() || await _repository.SaveChangesAsync())
                    return _mapper.Map<TrackModel>(track);
                
                return BadRequest("Failed to update database.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to get tracks");
            }
        }
    }
}
