using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int NrFollowers { get; set; }
        public int NrFollowing { get; set; }

        public IEnumerable<AccountsContent> AccountsContents { get; set; }
    }
}
