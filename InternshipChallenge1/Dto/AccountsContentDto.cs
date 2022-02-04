using InternshipChallenge1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Dto
{
    public class AccountsContentDto
    {
        [Required]
        public int AccountsContentId { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public DateTime PublicationData { get; set; }

        public int AccountId { get; set; }

        public AccountDto Account { get; set; }

        public IEnumerable<AccountContentCommentDto> AccountContentComments { get; set; }
    }
}
