using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonsterDB2.Models
{
    public partial class Monster
    {
        [Key]
        public int Monster_ID { get; set; }
        [Required(ErrorMessage = "Monster needs a name"), StringLength(50, MinimumLength = 2)]
        public string Monster_Name { get; set; }
        [Required]
        public int Monster_HP { get; set; }
        [Required(ErrorMessage = "Monster needs to have a Race"), StringLength(10, MinimumLength = 1)]
        public string Monster_Race { get; set; }
        [Required(ErrorMessage = "Monster needs to have a property"), StringLength(10, MinimumLength = 1)]
        public string Monster_Property { get; set; }
    }
}