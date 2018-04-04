using System;

namespace DojoMyPlaylist
{
    public class Musica{

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ArtistaId { get; set; }
        public Artista Artista { get; set; }
    }
}