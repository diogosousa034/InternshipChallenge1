using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Models
{
    public class AccountContentComment
    {
        public int AccountContentCommentId { get; set; }
        public string Message { get; set; }

        public int AccountsContentId { get; set; }
        public AccountsContent AccountsContent { get; set; }
    }
}
