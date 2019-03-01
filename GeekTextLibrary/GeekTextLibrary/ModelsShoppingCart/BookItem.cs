using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace GeekTextLibrary.ModelsShoppingCart
{
    public class BookItem : Book
    {

        public int quantity { get; set; }

        public BookItem()
        {
            ISBN = "";
            title = "";
            description = "";
            quantity = 0;
            price = 0;
        }

        public void Add(int _quantity)
        {
            this.quantity = this.quantity + _quantity;
        }

        public void Remove(int _quantity)
        {
            if (_quantity < this.quantity)
            {
                this.quantity = this.quantity - _quantity;
            }
            else
            {
                this.quantity = 0;
            }

        }
    }
}
