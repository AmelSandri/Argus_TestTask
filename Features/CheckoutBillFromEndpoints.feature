Feature: Testing a checkout system for a restaurant with endpoind response

#For now these feature scenario is not work because we don't get endpoint response
#It is just example of implementation a scenario and steps using endpoint request and response

Background: Set cost for the restaurant only serves
	Given The restaurant set cost is
	| key                    | value |
	| starter                | 4     |
	| main                   | 7     |
	| drink                  | 2.5   |
	| drinks discount        | 30    |
	| discount hours         | 19:00 |
	| service charge on food | 10    |

@scenario5
Scenario: User verifies the total bill amount from endpoind corresponds to calculated value
	When Group of people makes an order using
	| key     | value |
	| starter | 4     |
	| main    | 4     |
	| drink   | 4     |
	And User sent request to the endpoint
	Then the bill is calculated and has a value from endpoind corresponds to calculated value
