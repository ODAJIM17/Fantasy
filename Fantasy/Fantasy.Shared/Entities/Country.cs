using System.ComponentModel.DataAnnotations;

namespace Fantasy.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Country")]
        [MaxLength(100, ErrorMessage = "{0} allows max {1} characters")]
        [Required(ErrorMessage = "{0} is required.")]
        public string Name { get; set; } = null!;
    }
}