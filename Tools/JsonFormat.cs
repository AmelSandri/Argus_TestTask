using CheckoutSystem.DTO;
using Newtonsoft.Json;
using System.Text;
using TestTask.DTO;

namespace TestTask
{ 
    public class JsonFormat
    {
        private InitialSetUp _initialSetUp;
        private OrderResponse _orderResponse;

        public JsonFormat(InitialSetUp initialSetUp)
        {
            _initialSetUp = initialSetUp;
            _orderResponse = new OrderResponse();
        }
        public string Orders(int starterAmount, int mainAmount, int drinkAmount, bool IsDiscount)
        {
            List<OrderRequest> orders = new List<OrderRequest>
            {
                new OrderRequest { Name = "starter", Amount = starterAmount, ServiceChargeOnFood = _initialSetUp.GetServiceChargeOnFood(), 
                    DrinksDiscount = 0, DiscountHours = _initialSetUp.GetDiscountHours()},
                new OrderRequest { Name = "main", Amount = mainAmount, ServiceChargeOnFood = _initialSetUp.GetServiceChargeOnFood(),
                    DrinksDiscount = 0, DiscountHours = _initialSetUp.GetDiscountHours()},
                new OrderRequest { Name = "drink", Amount = drinkAmount, ServiceChargeOnFood = _initialSetUp.GetServiceChargeOnFood(),
                    DrinksDiscount = _initialSetUp.GetDrinkDiscount(), DiscountHours = _initialSetUp.GetDiscountHours()}
            };

            // Serialize the orders list to a JSON string
            string json = JsonConvert.SerializeObject(orders);

            return json;
        }

        public async void PostRequestToTheHost(string json)
        {
            // Create a new instance of the HttpClient class
            using var client = new HttpClient();

            // Define the URL of the endpoint
            string url = "http://localhost:8080";

            // Create a new StringContent object containing the JSON payload
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request to the endpoint and receive the response
            var response = await client.PostAsync(url, content);

            // Read the response content as a string
            string responseContent = await response.Content.ReadAsStringAsync();

            // Deserialize the response JSON into an OrderResponse object
            _orderResponse = JsonConvert.DeserializeObject<OrderResponse>(responseContent);
        }

        public double GetTotalBillCostFromResponse()
        {
            var totalAmount = Convert.ToDouble(_orderResponse.TotalBill);

            return totalAmount;
        }
    }
}
