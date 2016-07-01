using System.Collections.Generic;

namespace Dick.Models.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Cutter
    {
        public Cutter()
        {
            Order = new List<Order>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Не корректно введено Имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не корректно введена Фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Не корректно введено Отчество")]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        public List<Order> Order { get; set; }
    }
}