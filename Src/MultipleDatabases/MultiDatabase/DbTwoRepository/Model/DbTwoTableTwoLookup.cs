using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiDatabase.DbTwoRepository.Model
{
   [Table("DbTwoTableTwoLookup")]
   public sealed class DbTwoTableTwoLookup
   {
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
      public DbTwoTableTwoLookup()
      {
         DbOneTableOnes = new HashSet<DbTwoTableOne>();
      }

      [DatabaseGenerated(DatabaseGeneratedOption.None)]
      public short Id { get; set; }

      [Required]
      [StringLength(50)]
      public string Description { get; set; }

      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      // ReSharper disable once InconsistentNaming
      public ICollection<DbTwoTableOne> DbOneTableOnes { get; set; }
   }
}