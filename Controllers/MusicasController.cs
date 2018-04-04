using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DojoMyPlaylist.Controllers
{
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        [HttpGet("{filter}")]
        public Playlist Get(string user)
        {
            var usuarioId = Guid.NewGuid();
            var result = new Playlist
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuarioId,
                Usuario = new Usuario { Id = usuarioId, Nome = "Tanato" },
                Musicas = new List<Musica>(),
            };

            return result;
        }
    }
}
