using System.ComponentModel.DataAnnotations;

namespace TextGameAPI.Models.ViewModels
{
    public class CharacterViewModel
    {
        [Required]
        public string CharName { get; set; }
        [Required]
        public string CharRace { get; set; }
        [Required]
        public string CharGender { get; set; }
    }
}
