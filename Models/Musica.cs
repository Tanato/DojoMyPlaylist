using System;
using System.Collections.Generic;

namespace DojoMyPlaylist
{
    public class Musica
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string ArtistaId { get; set; }
        public Artista Artista { get; set; }
        public ICollection<PlaylistMusica> PlaylistMusicas { get; set; }
    }
}