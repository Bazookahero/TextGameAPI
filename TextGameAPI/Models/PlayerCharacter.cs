using System.ComponentModel.DataAnnotations;

namespace TextGameAPI.Models
{
    public class PlayerCharacter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CharName { get; set; }
        [Required]
        public string CharRace { get; set; }
        [Required]
        public string CharGender { get; set; }
    }
}
