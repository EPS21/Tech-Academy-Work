﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace MonsterDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

    // TODO change race and property from strings to enums

    /*
    public enum Monster_Race
    {
        Formless, Undead, Brute, Plant, Insect, Fish, Demon, Demi-Human, Angel, Dragon
    }
    */

    /*
    public enum Monster_Property
    {
        Neutral, Water, Earth, Fire, Wind, Poison, Holy, Shadow, Ghost, Undead
    }
    */
}
