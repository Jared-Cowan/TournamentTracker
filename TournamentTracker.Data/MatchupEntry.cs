using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class MatchupEntry
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int MatchupId { get; set; }
        public int? ParentMatchupId { get; set; }
        public int? TeamCompetingId { get; set; }
        public double? Score { get; set; }

        [ForeignKey(nameof(MatchupId))]
        [InverseProperty("MatchupEntries")]
        public virtual Matchup Matchup { get; set; }
        [ForeignKey(nameof(TeamCompetingId))]
        [InverseProperty(nameof(Team.MatchupEntries))]
        public virtual Team TeamCompeting { get; set; }
    }
}
