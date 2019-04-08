using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekTextLibrary
{
    public class CreditCard
    {
        public string CreditCardNumber { get; set; }
        public string expirationDate { get; set; }
        public int cvv { get; set; }        
        public string cardFirstName { get; set; }
        public string cardLastName { get; set; }
        public int cardIndex { get; set; }

    }
}
