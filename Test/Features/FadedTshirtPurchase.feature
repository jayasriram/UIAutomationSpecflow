Feature: Faded t-shirt purchase
	User should be able to add a faded short sleeve t-shirt to his cart

	Background: 
		Given I navigate to automation practice site
@functional @regression @smoke
Scenario: Logon to automation practice website to see an empty cart
	When I logon with username "jaivasudevan@gmail.com" with password "Passw0rd"
	Then I should see "my account" page
	And I should see that my cart is empty

@functional @regression
Scenario: User is able to add a faded short sleeve t-shirt with a specific colour to the cart
When I logon with username "jaivasudevan@gmail.com" with password "Passw0rd"
And I navigate to the "Women" section
And I add the following product to cart
| product            | colour | size |
| Faded Short Sleeve T-shirts| Blue   | M    |
Then I should see the success message for adding to cart as ‘Product successfully added to your shopping cart
And I should see the number of products in cart as "1"

