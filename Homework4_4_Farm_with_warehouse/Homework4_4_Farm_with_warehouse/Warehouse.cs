using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_4_Farm_with_warehouse
{
    class Warehouse
    {
        public int Capacity { get; set; }
        public List<Product> Products { get; set; }

        public Warehouse(int capacity = 100)
        {
            Capacity = capacity;
            Products = new List<Product>();
        }

        public int OccupiedCapacity
        {
            get
            {
                int occupiedCapacity = 0;
                foreach (var product in Products)
                {
                    occupiedCapacity += product.Weight;
                }
                return occupiedCapacity;
            }
        }

        public void WarehouseFill(List<Product> newProducts)
        {
            foreach (var newProduct in newProducts)
            {
                if ((OccupiedCapacity + newProduct.Weight) <= Capacity)
                {
                    int productIndex = IndexOfProduct(Products, newProduct);
                    if (productIndex == -1)
                    {
                        Products.Add(newProduct);
                    }
                    else
                    {
                        Products[productIndex].Weight += newProduct.Weight;
                    }
                }
                else
                {
                    Console.WriteLine($"Продукт {newProduct.Name} не добавлен, поскольку он уже не помещается на склад");
                }
            }
        }

        private int IndexOfProduct(List<Product> products, Product newProduct)
        {
            int productIndex = -1;
            for (var productCount = 0; productCount < products.Count; productCount++)
            {
                if (products[productCount].Name == newProduct.Name)
                {
                    productIndex = productCount;
                    break;
                }
            }
            return productIndex;
        }
    }
}
