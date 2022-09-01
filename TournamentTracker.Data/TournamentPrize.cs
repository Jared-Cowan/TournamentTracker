using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class TournamentPrize
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int PrizeId { get; set; }

        [ForeignKey(nameof(TournamentId))]
        [InverseProperty(nameof(Prize.TournamentPrizes))]
        public virtual Prize Tournament { get; set; }
        [ForeignKey(nameof(TournamentId))]
        [InverseProperty("TournamentPrizes")]
        public virtual Tournament TournamentNavigation { get; set; }
    }
}
