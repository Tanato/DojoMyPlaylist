using System;

namespace DojoMyPlaylist
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid PlaylistId { get; set; }
    }
}