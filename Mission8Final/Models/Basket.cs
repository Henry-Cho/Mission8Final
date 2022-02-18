using System;
using System.Collections.Generic;
using System.Linq;
using Mission8Final.Models;

namespace Mission8Final.Models
{
    public class Basket
    {
        public List<BasketLineItem> Items { get; set; } = new List<BasketLineItem>();

        // Add an item to the busket
        public void AddItem(Book libre, int qty)
        {
            // get the line that matches its BookID
            BasketLineItem line = Items
                .Where(p => p.Book.BookID == libre.BookID)
                .FirstOrDefault();

            // if line is null, create a new instance of BasketLineItem with the info in the parameter
            if (line == null)
            {
                Items.Add(new BasketLineItem
                {
                    Book = libre,
                    Quantity = qty
                });
            }
            // Else, add the quantity to the existing quantity
            else
            {
                line.Quantity += qty;
            }
        }

        // Calculate the total sum (price) of the items in the basket
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class BasketLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
