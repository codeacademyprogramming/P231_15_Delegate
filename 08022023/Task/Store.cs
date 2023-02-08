using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Store
    {
        public List<Product> Products = new List<Product>();

        public List<Product> GetDiscountedProducts()
        {
            List<Product> wantedProducts = new List<Product>();
            
            foreach (var item in Products)
            {
                if (item.DiscountPercent > 0)
                    wantedProducts.Add(item);
            }

            return wantedProducts;
        }

        public List<Product> GetProductsByPriceRange(double min,double max)
        {
            List<Product> wantedProducts = new List<Product>();

            foreach (var item in Products)
            {
                if (item.Price>=min && item.Price<=max)
                    wantedProducts.Add(item);
            }

            return wantedProducts;
        }

        public List<Product> FilterProducts(Predicate<Product> pred)
        {
            List<Product> wantedProducts = new List<Product>();

            foreach (var item in Products)
            {
                if (pred(item))
                    wantedProducts.Add(item);
            }

            return wantedProducts;
        }

        public Product GetproductByNo(int no)
        {
            foreach (var item in Products)
            {
                if (item.No == no)
                    return item;
            }

            return null;
        }

        public Product GetProduct(Predicate<Product> pred)
        {
            foreach (var item in Products)
            {
                if (pred(item))
                    return item;
            }

            return null;
        }

        public List<Product> GetProducts(params int[] numbers)
        {
            List<Product> wantedProducts = new List<Product>();

            foreach (var no in numbers)
            {
                var prod = GetproductByNo(no);
                if (prod !=null)
                    wantedProducts.Add(prod);

            }

            return wantedProducts;
        }

        public void ChangeProduct(Action<Product> act)
        {
            foreach (var item in Products)
            {
                act(item);
            }
        }
    }
}
