using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dick.Models.Entities
{
    public class ClothingPattern
    {
        public ClothingPattern()
        {
            Recommendation = new List<Cloth>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
        public List<Cloth> Recommendation { get; set; }
    }
}