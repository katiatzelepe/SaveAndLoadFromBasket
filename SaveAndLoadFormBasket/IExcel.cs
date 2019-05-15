using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveAndLoadFormBasket
{
    interface IExcel
    {
        bool SaveExcel(string ExcelFileName);
        bool LoadExcel(string ExcelFileName);
    }

    interface IText
    {
        void SaveText(string TextFileName);
        bool LoadText(string TextFileName);
    }

    interface IJson
    {
        void SaveJson(string JsonFileName);
        void LoadJson(string JsonFileName);
    }
}
