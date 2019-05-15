using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAndLoadFormBasket
{
    class Basket : IExcel, IText, IJson
    {

        public List<Product> products
            = new List<Product>();

        public void FillWithDumyData()
        {
            products.Add(new Product(1, "Frozen Meat", 7, 3));
            products.Add(new Product(2, "Coffee", 1.5, 2));
            products.Add(new Product(3, "Chocolate", 1.8, 1));

        }

        public void Active(int pId)
        {

            Console.WriteLine("\nThis product is Active : {0}", products.Exists(x => x.Id == pId));

        }



        public bool SaveExcel(string ExcelFileName)
        {


            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Mysheet");
            var r1 = sheet.CreateRow(0);
            r1.CreateCell(0).SetCellValue("ID");
            r1.CreateCell(1).SetCellValue("Name"); //** create headers
            r1.CreateCell(2).SetCellValue("Price");
            r1.CreateCell(3).SetCellValue("Product Category");

            for (int i = 0; i < products.Count; i++)
            {
                var r = sheet.CreateRow(i + 1);
                r.CreateCell(0).SetCellValue(products[i].Id);
                r.CreateCell(1).SetCellValue(products[i].Name);
                r.CreateCell(2).SetCellValue(products[i].Price);
                r.CreateCell(3).SetCellValue(products[i].ProductCategory);

            }

            using (var fs = new FileStream(ExcelFileName, FileMode.Create,
            FileAccess.Write))
            {
                wb.Write(fs);
            }
            return true;

        }

        public bool LoadExcel(string ExcelFileName)
        {
            products.Clear();
            XSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(@ExcelFileName, FileMode.Open,
            FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheet("Mysheet");
            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                if (sheet.GetRow(row) != null) //null is when the row only
                                               //contains empty cells
                {
                    int Id = int.Parse(sheet.GetRow(row).GetCell(0).ToString());
                    string Name = sheet.GetRow(row).GetCell(1).ToString();
                    double Price = double.Parse(sheet.GetRow(row).GetCell(2).ToString());
                    double ProductCategory = double.Parse(sheet.GetRow(row).GetCell(3).ToString());



                    Product p = new Product(Id, Name, Price, ProductCategory);

                    products.Add(p);

                    Console.WriteLine(p);

                }
            }
            return true;
        }

        public void SaveText(string TextFileName)
        {
            using (StreamWriter file =
            new StreamWriter(TextFileName))
            {
                foreach (Product p in products)
                {
                    file.WriteLine(p);
                }
            }



        }
        public bool LoadText(string TextFileName)
        {
            try
            {

                var list = new List<string>();
                var fileStream = new FileStream(@TextFileName, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
                foreach (String l in list)
                {
                    Console.WriteLine("....................");
                    Console.WriteLine(l);
                }

            }

            catch (Exception e)
            {
                return false;

            }
            return true;
        }

        public void SaveJson(string JsonFileName)
        {
            string jsonData = JsonConvert.SerializeObject(products);// ** save to json
            File.WriteAllText(JsonFileName, jsonData);

        }

        public void LoadJson(string JsonFileName)
        {
            string data = File.ReadAllText(JsonFileName);
            var temp = JsonConvert.
                DeserializeObject<List<Product>>(data); // Load from json file
            foreach (Product t in temp)
            {
                products.Add(t);
                Console.WriteLine(t);

            }


        }

       
    }
}
