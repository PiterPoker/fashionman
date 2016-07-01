using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dick.Models.Entities
{
    public class Cloth
    {
        [Required(ErrorMessage = "Не корректно введено уникальный код")]
        [Display(Name = "Уникальный код")]
        public string Code { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string ImageType { get; set; }

        [Required(ErrorMessage = "Не корректно введена ширина длина")]
        [Display(Name = "Длина ткани")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Не корректно введено Название ткани")]
        [Display(Name = "Название ткани")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не корректно введена цена")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Не корректно введена ширина ткани")]
        [Display(Name = "Ширина ткани")]
        public double Width { get; set; }
    }
}