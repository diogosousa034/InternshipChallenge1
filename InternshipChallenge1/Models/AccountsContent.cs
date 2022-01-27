using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Models
{
    public class AccountsContent
    {
        public int AccountsContentId { get; set; }
        public byte[] Image { get; set; }
        public DateTime PublicationData { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual IEnumerable<AccountContentComment> AccountContentComments { get; set; }
    }
}
