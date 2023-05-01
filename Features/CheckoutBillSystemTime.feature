Feature: Testing a checkout system for a restaurant by determining the discount according to the system time

A short summary of the feature

Background: Set cost for the restaurant only serves
	Given The restaurant set cost is
	| key                    | value |
	| starter                | 4     |
	| main                   | 7     |
	| drink                  | 2.5   |
	| drinks discount        | 30    |
	| discount hours         | 19:00 |
	| service charge on food | 10    |

@scenario4
Scenario: User verifies the total bill amount is calculated correctly by determining the discount according to the system time
	When Group of people makes an order using
	| key     | value |
	| starter | 4     |
	| main    | 4     |
	| drink   | 4     |
	Then the bill is calculated and has the following value of pounds
	| key           | value |
	| discountTrue  | 55.4  |
	| discountFalse | 58.4  |
	When Group of people cancel an order using
	| key     | value |
	| starter | 1     |
	| main    | 1     |
	| drink   | 1     |
	Then the bill is calculated and has the following value of pounds
	| key           | value |
	| discountTrue  | 41.55 |
	| discountFalse | 43.8  |
