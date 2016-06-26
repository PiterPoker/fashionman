using System;

namespace Dick.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime FittingDate { get; set; }
        public int ClientId { get; set; }
        public ApplicationUser Users { get; set; }
        public Cutter Cutter { get; set; }
        public int CutterId { get; set; }
        public bool IsDone { get; set; }
        public Cloth Cloth { get; set; }
        public int ClothId { get; set; }
        public ClothingPattern ClothingPattern { get; set; }
        public int ClothingPatternId { get; set; }
    }
}