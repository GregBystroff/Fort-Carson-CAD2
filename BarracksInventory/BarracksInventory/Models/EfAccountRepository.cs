using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarracksInventory.Models
{
    public class EfAccountRepository 
        : IAccountRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        Account _account;
        //   C o n s t u c t o r s

        public EfAccountRepository(Account account)
        {
            _account = account;
        }
        
        //   M e t h o d s
    }
}
