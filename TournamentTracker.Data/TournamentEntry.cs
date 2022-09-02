using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class TournamentEntry
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        [InverseProperty("TournamentEntries")]
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(TournamentId))]
        [InverseProperty("TournamentEntries")]
        public virtual Tournament Tournament { get; set; }
    }
}
