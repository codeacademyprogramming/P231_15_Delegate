using System;
using System.Collections.Generic;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student std = new Student
            {
                No = 1,
                FullName = "Hikmet Abbasov",
            };

            std.AddExam("C#", 43);
            std.AddExam("Intro", 77);
            std.AddExam("Front", 87);
            std.AddExam("Back", 17);




            std.ShowExams();


            Console.WriteLine(std.GetAvgPoint());

            Group group = new Group
            {
                No = "P231",
            };

            group.AddStudent(new Student { No = 1, FullName = "Nermin" });
            group.AddStudent(new Student { No = 2, FullName = "Hikmet" });
            group.AddStudent(new Student { No = 3, FullName = "Abbas" });


            group.No = "P1234";


            Store store = new Store();

            store.Products.Add(new Product {No=11, Name = "Milla 1L", Price = 10, DiscountPercent = 10 });
            store.Products.Add(new Product { No = 16, Name = "Milla 2L", Price = 20, DiscountPercent = 20 });
            store.Products.Add(new Product { No = 14, Name = "Milla 3L", Price = 30, DiscountPercent = 0 });
            store.Products.Add(new Product { No = 21, Name = "Milla 4L", Price = 40, DiscountPercent = 0 });
            store.Products.Add(new Product { No = 61, Name = "Milla 5L", Price = 50, DiscountPercent = 10 });



            foreach (var item in store.FilterProducts(x=>x.Price*((100-x.DiscountPercent)/100)>20))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.DiscountPercent}%");
            }

            Console.WriteLine("==================");
            foreach (var item in store.GetProducts(11,21,14,45,54))
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.DiscountPercent}%");
            }


            var product = store.GetProduct(x => x.Price>20);

            Console.WriteLine(product.Name);


            store.ChangeProduct(x => x.DiscountPercent=0);
            Console.WriteLine("All products");
            foreach (var item in store.Products)
            {
                Console.WriteLine($"{item.Name} - {item.Price} - {item.DiscountPercent}%");
            }

        }
    }
}
