using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAndLoadFormBasket
{
    class Program
    {
        static void Main(string[] args)
        {

            var document = new Basket();

            document.FillWithDumyData();

            // excel.SaveExcel("list.xlsx");
            //document.LoadExcel("list.xlsx");

            //document.SaveText("list.txt");
            //document.LoadText("list.txt");

            //document.SaveJson("Jsondata.txt");
            document.LoadJson("Jsondata.txt");


            //** for active or inactive product
            Console.WriteLine("Enter Product Id");
            int pId = int.Parse(Console.ReadLine());
            document.Active(pId);
            
            


            Console.ReadLine();
        }
    }
}
