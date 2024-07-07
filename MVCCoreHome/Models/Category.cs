using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreHome.Models
{
    [Table("Category",Schema ="dbo")]
    public class Category
    {
        [Required]
        [Key]
        [Display(Name ="Category ID")]
        public int id { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        [StringLength(20)]
        [Column(TypeName ="nvarchar(20)")]
        public string Name { get; set; }

        

    }
}
