using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAndLoadFormBasket
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ProductCategory { get; set; }
        //public Category ProductCategory { get; set; }

        public Product(int id, string name, double price, double productCategory) //Category productCategory
        {
            Id = id;
            Name = name;
            Price = price;
            ProductCategory = productCategory;
           // ProductCategory = productCategory;
        }

        //public Category GetProductCategory()
        //{

        //    return ProductCategory;
        //}

        public override string ToString()
        {
            return $"ID : {Id}\t Name : {Name}\t Price : {Price}\t Product Category : {ProductCategory} ";
        }
    }
}
