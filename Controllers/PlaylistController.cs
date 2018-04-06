using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoMyPlaylist.Models;
using Microsoft.EntityFrameworkCore;

namespace DojoMyPlaylist.Controllers
{
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext db;

        public PlaylistController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet("{usuario}")]
        [ProducesResponseType(typeof(Playlist), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> GetByUser(string usuario)
        {
            var result = await db.Playlists
                            .Include(x => x.Usuario)
                            .Include(x => x.PlaylistMusicas)
                            .ThenInclude(x => x.Musica)
                            .ThenInclude(x => x.Artista)
                            .SingleOrDefaultAsync(x => x.Usuario.Nome == usuario);

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPut("AddMusica/{playlistId}")]
        public async Task<IActionResult> PutAddMusic(string playlistId, [FromBody]Musica value)
        {
            var playlist = await db.Playlists.SingleOrDefaultAsync(x => x.Id == playlistId);
            var musica = await db.Musicas.SingleOrDefaultAsync(x => x.Id == value.Id);
            if (playlist == null || musica == null)
                return NoContent();

            var playlistMusica = await db.PlaylistMusicas.SingleOrDefaultAsync(x => x.MusicaId == value.Id && x.PlaylistId == playlistId);
            if (playlistMusica != null)
                return BadRequest();

            var pm = new PlaylistMusica { PlaylistId = playlistId, MusicaId = value.Id };
            db.PlaylistMusicas.Add(pm);

            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("RemoveMusica/{playlistId}")]
        public async Task PutRemoveMusic(string playlistId, [FromBody]Musica value)
        {
            var pm = await db.PlaylistMusicas.SingleAsync(x => x.MusicaId == value.Id && x.PlaylistId == playlistId);
            db.PlaylistMusicas.Remove(pm);

            await db.SaveChangesAsync();
        }
    }
}
