using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiDatabase.DbOneRepository.Model
{
    [Table("DbOneTableTwoLookup")]
    public sealed class DbOneTableTwoLookup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DbOneTableTwoLookup()
        {
            DbOneTableOnes = new HashSet<DbOneTableOne>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // ReSharper disable once InconsistentNaming
        public ICollection<DbOneTableOne> DbOneTableOnes { get; set; }
    }
}