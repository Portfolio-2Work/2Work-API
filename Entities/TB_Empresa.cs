using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Work_API.Entities
{
    [Table("TB_Empresa")]
    public class TB_Empresa : BaseEntity
    {
        [Required]
        public string NM_Empresa { get; set; }

        [Required]
        public string ST_Record { get; set; }

        [Required]
        public string CNPJ { get; set; }
    }
}
