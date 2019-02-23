using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeekTextLibrary.Address;
using static GeekTextLibrary.CreditCard;


namespace GeekTextLibrary
{
<<<<<<< HEAD
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
=======
    public class User
    {
        public int userID { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string userNickName { get; set; }
        public string eMailAddress { get; set; }
        public List<Address> userShippingAddress { get; set; }
        public string userProfileName { get; set; }
        public string userPassword { get; set; }
        public List<CreditCard> userCreditCard { get; set; }
        public string userComment { get; set; }
>>>>>>> master
    }
}
