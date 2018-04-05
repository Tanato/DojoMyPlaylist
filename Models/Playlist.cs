using System;
using System.Collections.Generic;

namespace DojoMyPlaylist
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public ICollection<PlaylistMusica> PlaylistMusicas { get; set; }
        public Usuario Usuario { get; set; }
    }
}