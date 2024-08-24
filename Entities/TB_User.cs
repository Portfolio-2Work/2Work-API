using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2Work_API.Entities;

[Table("TB_User")]
public class TB_User : BaseEntity
{
    [Required]
    public string NM_User { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string TP_User { get; set; }

    [Required]
    public string ST_Record { get; set; }

    [Required]
    public string Password { get; set; }
}
