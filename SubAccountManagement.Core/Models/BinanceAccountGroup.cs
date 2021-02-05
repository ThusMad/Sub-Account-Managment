using SubAccountManagement.IO.Interfaces;
using System.Collections.Generic;

namespace SubAccountManagement.Core.Models
{
    public class BinanceAccountGroup
    {
        public BinanceAccountGroup(IAccountSaveModel mainAccountSave, IList<IAccountSaveModel> subAccountSaves)
        {
            SubAccountsAccount = new List<BinanceAccount>();

            MainAccount = new BinanceAccount(mainAccountSave);
            foreach(var save in subAccountSaves)
            {
                SubAccountsAccount.Add(new BinanceAccount(save));
            }
        }

        public BinanceAccount MainAccount { get; set; }
        public IList<BinanceAccount> SubAccountsAccount { get; set; }
    }
}