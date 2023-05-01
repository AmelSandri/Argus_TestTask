using CheckoutSystem.DTO;
using System;
using TechTalk.SpecFlow;

namespace TestTask.Steps
{
    [Binding]
    public class CheckoutBillSteps
    {
        private InitialSetUp _initialSetUp;
        double totalBillCost;

        public CheckoutBillSteps(InitialSetUp initialSetUp)
        {
            _initialSetUp = initialSetUp;
        }

        [When(@"Group of people makes an order '(.*)' discount hours using")]
        public void WhenGroupOfPeopleMakesAnOrderDiscountHoursUsing(string discountCase, Table table)
        {
            bool discountIs = false;

            var orderDict = Tools.parseTableToDictionary(table);

            // get the total sum of ordered starters and mains with a service charge on food
            var starterCost = _initialSetUp.GetStarterCost() * double.Parse(orderDict["starter"]);
            var mainCost = _initialSetUp.GetMainCost() * double.Parse(orderDict["main"]);
            var totalFoodCost = Tools.CalculateFoodCost(starterCost, mainCost, _initialSetUp.GetServiceChargeOnFood());

            // determine if there is a discount on drinks depending on the step instance
            switch (discountCase)
            {
                case "before":
                    discountIs = true;
                    break;
                case "without":
                case "after":
                    discountIs = false;
                    break;
            }

            // get the total sum of ordered drinks depending on discount instance
            var totalDrinksCost = Tools.DrinkCost(_initialSetUp.GetDrinkCost(), _initialSetUp.GetDrinkDiscount(), discountIs) * 
                double.Parse(orderDict["drink"]);

            totalBillCost = totalBillCost + totalFoodCost + totalDrinksCost;
        }

        [When(@"Group of people cancel an order '(.*)' discount hours using")]
        public void WhenGroupOfPeopleCancelAnOrderDiscountHoursUsing(string discountCase, Table table)
        {
            bool discountIs = false;

            var orderDict = Tools.parseTableToDictionary(table);
            // get the total sum of ordered starters and mains with a service charge on food
            var starterCost = _initialSetUp.GetStarterCost() * double.Parse(orderDict["starter"]);
            var mainCost = _initialSetUp.GetMainCost() * double.Parse(orderDict["main"]);
            var totalFoodCost = Tools.CalculateFoodCost(starterCost, mainCost, _initialSetUp.GetServiceChargeOnFood());

            // determine if there is a discount on drinks depending on the step instance
            switch (discountCase)
            {
                case "before":
                    discountIs = true;
                    break;
                case "without":
                case "after":
                    discountIs = false;
                    break;
            }

            // get the total sum of ordered drinks depending on discount instance
            var totalDrinksCost = Tools.DrinkCost(_initialSetUp.GetDrinkCost(), _initialSetUp.GetDrinkDiscount(), discountIs) *
                double.Parse(orderDict["drink"]);

            totalBillCost = totalBillCost - totalFoodCost - totalDrinksCost;
        }

        [Then(@"the bill is calculated and has a value '(.*)' pounds")]
        public void ThenTheBillIsCalculatedAndHasAValuePounds(double expectedSum)
        {
            Assert.True(expectedSum.Equals(totalBillCost),
                $"The total sum should be '{expectedSum}' but current sum is '{totalBillCost}'");
        }

    }
}
