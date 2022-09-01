﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class Prize
    {
        public Prize()
        {
            TournamentPrizes = new HashSet<TournamentPrize>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int PlaceNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string PlaceName { get; set; }
        [Column(TypeName = "money")]
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        [InverseProperty(nameof(TournamentPrize.Tournament))]
        public virtual ICollection<TournamentPrize> TournamentPrizes { get; set; }
    }
}
