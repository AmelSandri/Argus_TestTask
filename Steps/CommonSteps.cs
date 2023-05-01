using CheckoutSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestTask.Steps
{
    [Binding]
    public class CommonSteps
    {
        private InitialSetUp _initialSetUp;

        public CommonSteps(InitialSetUp initialSetUp)
        {
            _initialSetUp = initialSetUp;
        }

        [Given(@"The restaurant set cost is")]
        public void GivenTheRestaurantSetCostIs(Table table)
        {
            var dict = Tools.parseTableToDictionary(table);

            _initialSetUp.FillObject(dict);
        }
    }
}
