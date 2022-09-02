using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class Team
    {
        public Team()
        {
            MatchupEntries = new HashSet<MatchupEntry>();
            Matchups = new HashSet<Matchup>();
            TeamMembers = new HashSet<TeamMember>();
            TournamentEntries = new HashSet<TournamentEntry>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string TeamName { get; set; }

        [InverseProperty(nameof(MatchupEntry.TeamCompeting))]
        public virtual ICollection<MatchupEntry> MatchupEntries { get; set; }
        [InverseProperty(nameof(Matchup.Winner))]
        public virtual ICollection<Matchup> Matchups { get; set; }
        [InverseProperty(nameof(TeamMember.Team))]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        [InverseProperty(nameof(TournamentEntry.Team))]
        public virtual ICollection<TournamentEntry> TournamentEntries { get; set; }
    }
}
