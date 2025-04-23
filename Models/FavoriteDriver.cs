using System.ComponentModel.DataAnnotations;

namespace F1TrackerApi.Models
{
    public class FavoriteDriver
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Foreign key to the User table

        [Required]
        public string DriverName { get; set; }
    }
}