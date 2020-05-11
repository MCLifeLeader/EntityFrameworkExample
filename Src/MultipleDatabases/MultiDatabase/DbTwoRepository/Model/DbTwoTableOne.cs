using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MultiDatabase.DbTwoRepository.Model.Enum;

namespace MultiDatabase.DbTwoRepository.Model
{
   [Table("DbTwoTableOne")]
   public class DbTwoTableOne
   {
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      [Required] 
      public short DbTwoTableTwoLookupId { get; set; }

      [Required]
      [StringLength(100)]
      public string Data { get; set; }

      [Required]
      public DateTime DateCreated { get; set; }
   }
}
