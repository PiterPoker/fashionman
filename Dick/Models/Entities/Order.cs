using System;
using System.ComponentModel.DataAnnotations;

namespace Dick.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не корректно введена дата начала")]
        [Display(Name = "Дата начала")]
        public DateTime BeginDate { get; set; }
        [Required(ErrorMessage = "Не корректно введена дата окончание")]
        [Display(Name = "Дата окончание")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Не корректно введена дата примерки")]
        [Display(Name = "Дата примерки")]
        public DateTime FittingDate { get; set; }
        [Required(ErrorMessage = "Не корректно введено Id Заказчика")]
        [Display(Name = "Id Заказчика")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public Cutter Cutter { get; set; }
        [Required(ErrorMessage = "Не корректно введено Id Закройщика")]
        [Display(Name = "Id Заказчика")]
        public int CutterId { get; set; }
        [Display(Name = "Готовность заказа")]
        public bool IsDone { get; set; }
        public Cloth Cloth { get; set; }
        [Required(ErrorMessage = "Не корректно введено Id Ткани")]
        [Display(Name = "Id Ткани")]
        public int ClothId { get; set; }
        [Required(ErrorMessage = "Не корректно введено Id Модели")]
        [Display(Name = "Id Модели")]
        public ClothingPattern ClothingPattern { get; set; }
        public int ClothingPatternId { get; set; }
    }
}