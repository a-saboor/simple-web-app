using System;

namespace Proj9.DTOs
{
    public class ItemMasterDto
    {
        public long ID { get; set; }
        public long ItemCat { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public decimal SaleRate { get; set; }
        public decimal PurRate { get; set; }
        public string UpdUser { get; set; }
        public DateTime CreatedOn { get; set; } 
    }
}
