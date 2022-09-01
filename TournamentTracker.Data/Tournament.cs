using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class Tournament
    {
        public Tournament()
        {
            Matchups = new HashSet<Matchup>();
            TournamentEntries = new HashSet<TournamentEntry>();
            TournamentPrizes = new HashSet<TournamentPrize>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TournamentName { get; set; }
        [Column(TypeName = "money")]
        public decimal EntryFee { get; set; }
        public bool Active { get; set; }

        [InverseProperty(nameof(Matchup.Tournament))]
        public virtual ICollection<Matchup> Matchups { get; set; }
        [InverseProperty(nameof(TournamentEntry.Tournament))]
        public virtual ICollection<TournamentEntry> TournamentEntries { get; set; }
        [InverseProperty(nameof(TournamentPrize.TournamentNavigation))]
        public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; }
    }
}
