using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Work_API.Entities
{
    [Table("Users_x_Empresa")]
    public class Users_x_Empresa : BaseEntity
    {
        [Required]
        public Guid ID_Users { get; set; }

        [ForeignKey("ID_Users")]
        public Users FK_Users { get; set; }

        [Required]
        public Guid ID_Empresa { get; set; }

        [ForeignKey("ID_Empresa")]
        public Empresa FK_Empresa { get; set; }
    }
}
