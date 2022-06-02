using System.ComponentModel.DataAnnotations;

namespace kursovaya.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        [Range(10,80,ErrorMessage ="Возраст должен быть от 18-80")]
        public int age { get; set; }
        [Required]
        [Display(Name = "Спортивный титул")]
        public string sport_title { get; set; }
        [Required]
        [Display(Name = "Страна")]
        public string country { get; set; }
        [Required]
        [Display (Name="Изобржение")]
        public string imageUrl { get; set; }
        public double distHammer { get; set; }
        public double distCore { get; set; }
        public double distDisk { get; set; }
        public double distSpear { get; set; }

       
    }
}
