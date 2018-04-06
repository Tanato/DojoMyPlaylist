using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoMyPlaylist
{
    public class Playlist
    {
        public string Id { get; set; }
        public ICollection<PlaylistMusica> PlaylistMusicas { get; set; }
        public Usuario Usuario { get; set; }
    }
}