using System.ComponentModel.DataAnnotations;

namespace kursovaya.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Age")]
        [Range(10,80,ErrorMessage ="Возраст должен быть от 18-80")]
        public int age { get; set; }
        [Required]
        [Display(Name = "Sport Title")]
        public string sport_title { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
        [Required]
        [Display (Name = "Image")]
        public string imageUrl { get; set; }
        [Required]
        public double distHammer { get; set; }
        [Required]
        public double distCore { get; set; }
        [Required]
        public double distDisk { get; set; }
        [Required]
        public double distSpear { get; set; }

       
    }
}
