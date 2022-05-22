using System.ComponentModel.DataAnnotations;

namespace skm_back_dotnet.DTOs
{
    public class MovieTheaterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class MovieTheaterCreationDTO{
        [Required]
        [StringLength(75)]
        public string Name { get; set;}
        [Range(-90, 90)]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        public double Longitude { get; set; }

    }

}