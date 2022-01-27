using InternshipChallenge1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipChallenge1.IService
{
    public interface IAccountsContentService
    {
        AccountsContent Save(AccountsContent oAccountsContent);

        AccountsContent GetSavedAccountsContent();
    }
}
