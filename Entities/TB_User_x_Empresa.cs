using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Work_API.Entities
{
    [Table("TB_User_x_Empresa")]
    public class TB_User_x_Empresa : BaseEntity
    {
        [Required]
        public Guid ID_TB_User { get; set; }

        [ForeignKey("ID_TB_User")]
        public TB_User FK_TB_User { get; set; }

        [Required]
        public Guid ID_TB_Empresa { get; set; }

        [ForeignKey("ID_TB_Empresa")]
        public TB_Empresa FK_TB_Empresa { get; set; }
    }
}
