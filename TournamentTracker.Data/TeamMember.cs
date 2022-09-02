using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class TeamMember
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("TeamMembers")]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(TeamId))]
        [InverseProperty("TeamMembers")]
        public virtual Team Team { get; set; }
    }
}
