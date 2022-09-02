using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class Matchup
    {
        public Matchup()
        {
            MatchupEntries = new HashSet<MatchupEntry>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int? WinnerId { get; set; }
        public int MatchupRound { get; set; }

        [ForeignKey(nameof(TournamentId))]
        [InverseProperty("Matchups")]
        public virtual Tournament Tournament { get; set; }
        [ForeignKey(nameof(WinnerId))]
        [InverseProperty(nameof(Team.Matchups))]
        public virtual Team Winner { get; set; }
        [InverseProperty(nameof(MatchupEntry.Matchup))]
        public virtual ICollection<MatchupEntry> MatchupEntries { get; set; }
    }
}
