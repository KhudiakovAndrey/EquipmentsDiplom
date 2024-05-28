using System;

namespace Equipments.WebAPI.Models
{
    public class Installer
    {
        public string Version { get; set; }
        public string Filename { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
