using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TournamentTracker.Data
{
    public partial class Person
    {
        public Person()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string CellphoneNumber { get; set; }

        [InverseProperty(nameof(TeamMember.Person))]
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
