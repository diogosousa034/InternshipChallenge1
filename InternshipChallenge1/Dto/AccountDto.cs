using InternshipChallenge1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Dto
{
    public class AccountDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int NrFollowers { get; set; }

        [Required]
        public int NrFollowing { get; set; }


        public virtual IEnumerable<AccountsContent> AccountsContents { get; set; }
    }
}
