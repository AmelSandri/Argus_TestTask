@automated
Feature: Testing a checkout system for a restaurant

Background: Set cost for the restaurant only serves
	Given The restaurant set cost is
	| key                    | value |
	| starter                | 4     |
	| main                   | 7     |
	| drink                  | 2.5   |
	| drinks discount        | 30    |
	| discount hours         | 19:00 |
	| service charge on food | 10    |

@scenario1
Scenario: User verifies the total bill amount is calculated correctly
	When Group of people makes an order 'without' discount hours using
	| key     | value |
	| starter | 4     |
	| main    | 4     |
	| drink   | 4     |
	Then the bill is calculated and has a value '58.4' pounds

@scenario2
Scenario: User verifies the total bill amount is calculated correctly when ordering at different discount period
	When Group of people makes an order 'before' discount hours using
	| key     | value |
	| starter | 1     |
	| main    | 2     |
	| drink   | 2     |
	Then the bill is calculated and has a value '23.3' pounds
	When Group of people makes an order 'after' discount hours using
	| key     | value |
	| starter | 0     |
	| main    | 2     |
	| drink   | 2     |
	Then the bill is calculated and has a value '43.7' pounds

@scenario3
Scenario: User verifies the total bill amount is calculated correctly in case of partial order cancellation
	When Group of people makes an order 'after' discount hours using
	| key     | value |
	| starter | 4     |
	| main    | 4     |
	| drink   | 4     |
	Then the bill is calculated and has a value '58.4' pounds
	When Group of people cancel an order 'after' discount hours using
	| key     | value |
	| starter | 1     |
	| main    | 1     |
	| drink   | 1     |
	Then the bill is calculated and has a value '43.8' pounds
