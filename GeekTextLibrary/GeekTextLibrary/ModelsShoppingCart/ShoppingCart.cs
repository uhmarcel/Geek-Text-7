using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GeekTextLibrary.ModelsShoppingCart
{
    public class ShoppingCart
    {
        public List<BookItem> Items { get; set; }


        



        public ShoppingCart()
        {
            Items = new List<BookItem>();
        }

        public int GetTotalQuantity()
        {
            int result = 0;

            foreach (BookItem element in Items)
            {
                result += element.quantity;
            }
            return result;
        }

   
    }
}
