using System;
using System.Collections.Generic;
using System.Linq;

namespace LmazonBookStore.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        public void AddItem (Books books, int qty)
        {
            BasketLineItem line = Items
                .Where(b => b.Books.BookId == books.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Books = books,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalcualteTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Books.Price);

            return sum;
        }

        public int TotalBook()
        {
            int sum = Items.Sum(x => x.Quantity++);

            return sum;
        }

    }

    public class BasketLineItem
    {
        public int LineID { get; set; }

        public Books Books { get; set; }

        public int Quantity { get; set; }
    }

}
