namespace SpaceShooterGame.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerScore")]
    public partial class PlayerScore
    {
        public int id { get; set; }

        public int? id_player { get; set; }

        public int? id_score { get; set; }

        public virtual Player Player { get; set; }

        public virtual Score Score { get; set; }
    }
}
