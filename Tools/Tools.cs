using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestTask
{
    public static class Tools
    {
        public static Dictionary<string, string> parseTableToDictionary(Table table, bool сonverteKeyToLowerCase = true)
        {
            Dictionary<string, string> newDict = new Dictionary<string, string>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string rowKey;
                if (сonverteKeyToLowerCase)
                {
                    rowKey = table.Rows[i][0].ToLower();
                }
                else
                {
                    rowKey = table.Rows[i][0];
                }
                string rowValue = table.Rows[i][1].ToLower();
                newDict.Add(rowKey, rowValue);
            }
            return newDict;

        }

        public static double CalculateFoodCost(double starter, double main, double serviceCharge)
        {
            double foodCost = (starter + main) * (1 + serviceCharge / 100);
            foodCost = Math.Round(foodCost, 2);
            return foodCost;
        }

        public static double DrinkCost(double drinkCost, double discount, bool discountIs)
        {
            double drinkCostWithDiscount;
            if (discountIs)
            {
                drinkCostWithDiscount = drinkCost * (1 - discount / 100);
            }
            else
            {
                drinkCostWithDiscount = drinkCost;
            }
            return drinkCostWithDiscount;
        }
    }
}
