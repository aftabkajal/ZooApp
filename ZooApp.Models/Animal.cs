using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public partial class Animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index("IX_AnimalName", 1, IsUnique = true)]
        
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Origin { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual ICollection<AnimalFood> AnimalFood { get; set; }
    }


    public partial class Animal : IValidatableObject
    {
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            
             ZooContext db = new ZooContext();
            Name = Name.ToUpper();
            var DbModel = db.Animals.FirstOrDefault(x => x.Name.ToUpper() == Name);
            if (DbModel !=null)
            {
                ValidationResult error = new ValidationResult("Name already Exist", new []{"Name"});
                yield return error;
            }
            
        }
    }




}
