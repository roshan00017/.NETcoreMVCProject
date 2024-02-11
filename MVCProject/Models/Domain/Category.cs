using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CreatedBy { get; set; }
     
        public int? ModifiedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }


        [ForeignKey("ModifiedBy")]
        public virtual User ModifiedByUser { get; set; }

     
        public DateTime CreatedDate { get; set; }

       
        public DateTime ModifiedDate { get; set; }

  
    }
}
