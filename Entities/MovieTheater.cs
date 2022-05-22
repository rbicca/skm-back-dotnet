using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace skm_back_dotnet.Entities
{
    public class MovieTheater
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:75)]
        public string Name { get; set; }
        public Point Location { get; set; }
    }
}