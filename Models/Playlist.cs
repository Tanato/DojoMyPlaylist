using System;
using System.Collections.Generic;

namespace DojoMyPlaylist
{
    public class Playlist
    {

        public Guid Id { get; set; }
        public List<Musica> Musicas { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}