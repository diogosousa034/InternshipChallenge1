using System;
using System.Collections.Generic;
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
        public Account Account { get; set; }

        public IEnumerable<AccountContentComment> AccountContentComments { get; set; }
    }
}
