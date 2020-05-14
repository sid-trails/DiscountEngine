using System;
using System.Collections.Generic;
using DiscountEngine.InterFaces;

namespace DiscountEngine
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var inv = new Inventory();
            Console.WriteLine("Just Running the test :P");
            inv.AddSKU('A', 50);
            inv.AddSKU('B',30.0d);
            inv.AddSKU('C',20.0d);
            inv.AddSKU('D',15.0d);

            var rules = new List<IDiscountRule>()
            {
                new SameSKUFixedPriceRule('A', 3, 130, inv),
                new CombinationDiscountRule('C', 'D', 30.00d, inv),
                new SameSKUFixedPriceRule('B', 2, 45.00d, inv)
            };

            var engine = new DiscountEngine(rules);

            Console.WriteLine("Scenario 1");
            Cart cart = new Cart(inv);
            cart.AddItem('A',1);
            cart.AddItem('B',1);
            cart.AddItem('C',1);

            double discount = engine.ApplyBestDiscount(cart);
            Console.WriteLine(String.Format("Cart Value {0} and Discount is {1} /n Amount Tobe Paid {2}", cart.CartValue , discount, 
                cart.CartValue-discount));
            
            Console.WriteLine("============================================================");
            Console.WriteLine("Scenario 2");
            cart = new Cart(inv);
            cart.AddItem('A',5);
            cart.AddItem('B',5);
            cart.AddItem('C',1);

             discount = engine.ApplyBestDiscount(cart);
            Console.WriteLine(String.Format("Cart Value {0} and Discount is {1} /n Amount Tobe Paid {2}", cart.CartValue , discount, 
                cart.CartValue-discount));

            Console.WriteLine("============================================================");
            Console.WriteLine("Scenario 3");
            cart = new Cart(inv);
            cart.AddItem('A',3);
            cart.AddItem('B',5);
            cart.AddItem('C',1);
            cart.AddItem('D',1);

            discount = engine.ApplyBestDiscount(cart);
            Console.WriteLine(String.Format("Cart Value {0} and Discount is {1} /n Amount Tobe Paid {2}", cart.CartValue , discount, 
                cart.CartValue-discount));
            
            Console.WriteLine("============================================================");
            Console.ReadKey();
        }
    }
}