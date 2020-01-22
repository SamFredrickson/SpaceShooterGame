namespace SpaceShooterGame.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Score")]
    public partial class Score
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Score()
        {
            PlayerScore = new HashSet<PlayerScore>();
        }

        public int id { get; set; }

        public int seconds { get; set; }

        public int? minutes { get; set; }

        public int? hours { get; set; }

        [Required]
        public string difficulty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerScore> PlayerScore { get; set; }
    }
}
