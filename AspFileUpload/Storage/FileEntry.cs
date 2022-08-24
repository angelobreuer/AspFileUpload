namespace AspFileUpload.Storage;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("FILE_ENTRY")]
public sealed class FileEntry
{
    [Column("ID")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [Column("NAME")]
    public string Name { get; set; }

    [Required]
    [Column("CONTENT")]
    public byte[] Content { get; set; }
}
