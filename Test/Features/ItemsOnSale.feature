Feature: Items on sale
A user should recieve appropriate discount on the products on sale

	Background: 
		Given I navigate to automation practice site

@mytag
Scenario: Verify if the appropriate dresses pae is opened
	When I logon with username "jaivasudevan@gmail.com" with password "Passw0rd"
	And I navigate to the "Dresses" section
	Then I should land on the "dresses" page

Scenario: Verify if products on offer are appropriate with proper price calculation
When I logon with username "jaivasudevan@gmail.com" with password "Passw0rd"
And I navigate to the "Dresses" section
Then I should see the below products on offer with appropriate price
| products              | offerPercentage | oldPrice	| productPrice |
| Printed Summer Dress  | 5               | 30.51       | 28.98        |

