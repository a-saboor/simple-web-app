using System.ComponentModel.DataAnnotations;

namespace Proj9.DTOs
{
    public class ItemCategoryDto
    {
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
