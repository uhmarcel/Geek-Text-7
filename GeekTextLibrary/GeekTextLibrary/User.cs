using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeekTextLibrary.Address;
using static GeekTextLibrary.CreditCard;


namespace GeekTextLibrary
{
    class User
    {
        private string userfirstName { get; set; }
        private string userlasttName { get; set; }
        private string userNickName { get; set; }
        private string eMailAddress { get; set; }
        private List<Address> userShippingAddress { get; set; }
        private string userProfileName { get; set; }
        private string userPassword { get; set; }
        private List<CreditCard> userCreditCard { get; set; }
        private string userComment { get; set; }
    }
}
