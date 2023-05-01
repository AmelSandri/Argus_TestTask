using CheckoutSystem.DTO;
using TechTalk.SpecFlow;

namespace TestTask.Steps
{
    [Binding]
    public class CheckoutBillSystemTimeSteps
    {
        private InitialSetUp _initialSetUp;
        double _totalBillCost;
        bool _discountIs;

        public CheckoutBillSystemTimeSteps(InitialSetUp initialSetUp)
        {
            _initialSetUp = initialSetUp;
        }

        [When(@"Group of people makes an order using")]
        public void WhenGroupOfPeopleMakesAnOrderUsing(Table table)
        {
            double drinkCost;
            // parse the step table to a dictionary
            var orderDict = Tools.parseTableToDictionary(table);

            // get the total sum of ordered starters and mains with a service charge on food
            var starterCost = _initialSetUp.GetStarterCost() * double.Parse(orderDict["starter"]);
            var mainCost = _initialSetUp.GetMainCost() * double.Parse(orderDict["main"]);
            var totalFoodCost = Tools.CalculateFoodCost(starterCost, mainCost, _initialSetUp.GetServiceChargeOnFood());

            // determine if there is a discount on drinks at the current time (use a system time)
            var currentTime = DateTime.Now;
            var compareResult = DateTime.Compare(currentTime, _initialSetUp.GetDiscountHours());
            _discountIs = compareResult < 0 ? true : false;

            // get the total sum of ordered drinks depending on discount hours
            var drinksCost = _initialSetUp.GetDrinkCost() * double.Parse(orderDict["drink"]);
            var totalDrinksCost = Tools.DrinkCost(drinksCost, _initialSetUp.GetDrinkDiscount(), _discountIs);

            // get the total bill sum
            _totalBillCost = _totalBillCost + totalFoodCost + totalDrinksCost;
        }

        [When(@"Group of people cancel an order using")]
        public void WhenGroupOfPeopleCancelAnOrderUsing(Table table)
        {
            double drinkCost;
            // parse the step table to a dictionary
            var orderDict = Tools.parseTableToDictionary(table);

            // get the total sum of ordered starters and mains with a service charge on food
            var starterCost = _initialSetUp.GetStarterCost() * double.Parse(orderDict["starter"]);
            var mainCost = _initialSetUp.GetMainCost() * double.Parse(orderDict["main"]);
            var totalFoodCost = Tools.CalculateFoodCost(starterCost, mainCost, _initialSetUp.GetServiceChargeOnFood());

            // determine if there is a discount on drinks at the current time (use a system time)
            var currentTime = DateTime.Now;
            var compareResult = DateTime.Compare(currentTime, _initialSetUp.GetDiscountHours());
            _discountIs = compareResult < 0 ? true : false;

            // get the total sum of ordered drinks depending on discount hours
            var drinksCost = _initialSetUp.GetDrinkCost() * double.Parse(orderDict["drink"]);
            var totalDrinksCost = Tools.DrinkCost(drinksCost, _initialSetUp.GetDrinkDiscount(), _discountIs);

            // get the total bill sum
            _totalBillCost = _totalBillCost - totalFoodCost - totalDrinksCost;
        }

        [Then(@"the bill is calculated and has the following value of pounds")]
        public void ThenTheBillIsCalculatedAndHasTheFollowingValueOfPounds(Table table)
        {
            double expectedSum;
            var orderDict = Tools.parseTableToDictionary(table);

            if (_discountIs)
            {
                expectedSum = double.Parse(orderDict["discounttrue"]);
            }
            else
            {
                expectedSum = double.Parse(orderDict["discountfalse"]);
            }

            Assert.True(expectedSum.Equals(_totalBillCost),
                $"The total sum should be '{expectedSum}' but current sum is '{_totalBillCost}'");
        }

    }
}
