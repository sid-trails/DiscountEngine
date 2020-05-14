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
            
            // var Engine = new DiscountEngine(new IList<IDiscountRule>()
            // {
            //     new SameSKUFixedPriceRule('A',3,130,inv)
            // });

        }
    }
}