using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCoreHome.Models
{
    [Table("Products", Schema = "dbo")]
    public class Product
    {
        [Key]
        [Required]
        [Display(Name = "Product Id")]
        [Range(100,999999)]
        public int Id { get; set; }



        [Display(Name ="Product Name")]
        [Column(TypeName ="nvarchar(20)")]
        [Required]
        [StringLength(20)]
        public string Name  { get; set; }



        [Display(Name = "Product Number")]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        [Display(Name = "Product Discription")]
        public string? Discription { get; set; }

        [Range(1,10000)]
        [Required]
        public decimal Price { get; set; }




        [Required]
        public int CategoryID { get; set; }


        public virtual Category Category { get; set; }

    }
}
