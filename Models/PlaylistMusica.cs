using System;
using System.Collections.Generic;

namespace DojoMyPlaylist
{
    public class PlaylistMusica
    {
        public Guid PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public Guid MusicaId { get; set; }
        public Musica Musica { get; set; }
    }
}