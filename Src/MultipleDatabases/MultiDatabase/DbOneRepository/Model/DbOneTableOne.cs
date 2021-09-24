using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiDatabase.DbOneRepository.Model
{
    [Table("DbOneTableOne")]
    public class DbOneTableOne
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        // ReSharper disable once InconsistentNaming
        public short DbOneTableTwoLookupId { get; set; }

        [Required]
        [StringLength(50)]
        public string Data { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
