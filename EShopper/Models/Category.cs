using System.ComponentModel.DataAnnotations;

namespace EShopper.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(300)]
        public string? CategoryName { get; set; }

        [StringLength(300)]
        public string? CategoryPhoto { get; set; }
        public int CategoryOrder { get; set; }
    }
}
