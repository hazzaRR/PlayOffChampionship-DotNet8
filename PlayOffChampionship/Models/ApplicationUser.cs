using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayOffChampionship.Models
{

    public class ApplicationUser: IdentityUser
    {


        [PersonalData]
        public string? Name { get; set; }

        public List<League> Leagues { get; set; } = new List<League>();
    }
}
