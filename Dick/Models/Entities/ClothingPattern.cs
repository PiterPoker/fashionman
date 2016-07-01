using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dick.Models.Entities
{
    public class ClothingPattern
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не корректно введено название модели")]
        [Display(Name = "Название модели")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не корректно введен уникальный номер")]
        [Display(Name = "Уникальный номер")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Не корректно введена цена")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        public byte[] Image { get; set; }

        public string ImageType { get; set; }
    }
}