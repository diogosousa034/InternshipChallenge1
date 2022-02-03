using InternshipChallenge1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Dto
{
    public class AccountContentCommentDto
    {
        [Required]
        public int AccountContentCommentId { get; set; }
        [Required]
        public string Message { get; set; }

        public int AccountsContentId { get; set; }
        public AccountsContent AccountsContent { get; set; }
    }
}
