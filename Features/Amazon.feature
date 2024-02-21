Feature: Amazon

Verifying some basic functionalities of Amazon.in applications in below scenarios.

Background: 
	Given Application url is 'https://www.amazon.in/'
	When Launch the application
	Then Validate amazon logo in top left corner of the application
	
Scenario Outline: Validate search bar functionality is working for multiple products
	When Search for a product: '<product>'
	Then Validate the searched product from Result bar info
	Examples: 
	| product                                                |
	| Himalaya Baby Body Lotion, For All Skin Types (400 ml) |
	| Amazon Brand - Vedaka Whole Jeera (Cumin), 200g        |

Scenario: Validate item is added to the cart
	When Search for a product: 'Norton Antivirus Plus'
	And Select the first product
	And Click add to cart button
	And Goto shopping cart 
	Then Validate the above added item is present in the shopping cart 
	
Scenario: Validate image logo
	When Select the Hamburger Menu button from the main navigation bar
	And Select option - Mobiles, Computers
	And Select option - Software
	Then Validate the logo is present under Top categories section
