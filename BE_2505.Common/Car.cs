using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.Common
{
    public class Car
    {
        private string _brand { get; set; }
        public string _model { get; set; }
        public int _year { get; set; }

        //public Car(string brand, string model, int year)
        //{
        //    this._brand = brand;
        //    this._model = model;
        //    this._year = year;
        //}

        public string display_info()
        {
            return _brand + " " + _model + " " + _year;
        }
    }
}
