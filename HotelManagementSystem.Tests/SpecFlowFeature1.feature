Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And Use has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

@ShowHotel
Scenario: Show all hotels
	Given User provided valid Id 7 and name 'Hyatt' for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	Given User provided valid Id 8 and name 'Novotel' for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	Given User provided valid Id 9 and name 'Radisson' for hotel 
	And Use has added required details for hotel
	And User calls AddHotel api
	When User calls GetAllHotels api
	Then Hotels with their details should be displayed in the response

Scenario Outline: User gets hotel details of particular Id
	Given User provided valid Id '<id>'  and '<name>'for hotel
	And User has added required details for hotel
	And User calls AddHotel api to add hotel
	When User calls GetHotelById with '<id>' api
	Then Hotel with '<id>' should be present in the response

Examples: 
| id | name   |
| 4  | hotel4 |
| 5  | hotel5 |
| 6  | hotel6 |