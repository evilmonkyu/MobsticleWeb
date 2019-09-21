using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MobsticleWeb.Models.Mobs
{
    public class MobModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}