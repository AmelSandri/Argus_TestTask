using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutSystem.DTO
{
    public class InitialSetUp
    {
        public InitialSetUp() { }

        private double starter { get; set; }
        private double main { get; set; }
        private double drink { get; set; }
        private double drinksDiscount { get; set; }
        private double serviceChargeOnFood { get; set; }
        private DateTime discountHours { get; set; }

        public void FillObject(Dictionary<string, string> dict)
        {
            /// <summary>
            /// Parse entered values according to the object instances
            /// </summary>>
            starter = double.Parse(dict["starter"]);
            main = double.Parse(dict["main"]);
            drink = double.Parse(dict["drink"]);
            drinksDiscount = double.Parse(dict["drinks discount"]);
            serviceChargeOnFood = double.Parse(dict["service charge on food"]);

            discountHours = Convert.ToDateTime(dict["discount hours"]);
        }

        public double GetStarterCost() { return starter; }

        public double GetMainCost() { return main; }

        public double GetDrinkCost() { return drink; }

        public DateTime GetDiscountHours() { return discountHours; }

        public double GetServiceChargeOnFood() { return serviceChargeOnFood; }

        public double GetDrinkDiscount() { return drinksDiscount; }
    }
}
