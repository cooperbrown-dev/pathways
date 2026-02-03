Create an application with an OOP design to help manage customer memberships (think Costco). 

Four types of memberships need to be handled - a regular, an executive, a non-profit and a corporate. 
All four types of memberships have common information including a membership id, primary contact email address, the type of membership, annual cost and the current amount of purchases for the month. 
In addition, the regular membership has a flat percent for cash-back rewards on all purchases, the executive membership has percentages for two tiers (one below $1000 and one above) of cash-back rewards, the non-profit membership has a cash-back percentage and also a field to indicate if it is a military or educational organization and if so doubles the cash-back percentage, and the corporate membership has a flat percent for cash-back rewards. 
On the administrative side, the four CRUD operations need to be implemented for a membership:
C - Create a new membership and add to the membership list.  Be sure you don't duplicate the membership ID.  It needs to be unique.
R - Read all of the memberships in the membership list.
U - Update an existing membership based on membership ID.
D - Delete an existing membership based on membership ID.
Three types of transactions need to be handled:
Purchase- A purchase will include the membership id and the amount of the purchase (which must be > 0).   All four accounts handle a purchase in the same way.  If the membership ID exists, the current amount of purchases is increased by the purchase amount.
Return - A return of an item will include the membership id and the amount of the purchase returned (which must be > 0).  All four accounts handle a return in the same way.  If the membership ID exists, the current amount of purchases is decreased by the purchase amount.
Apply cash-back reward - For the apply cash-back reward, the membership id will be provided.  Cash-back rewards are handled differently depending on the membership type as described above.  When a valid membership ID is given, the system will send a request to the rewards system for the amount of the reward.  For this application, you can simply print a console output that says "Cash-back reward request for membership xxxxxx in the amount of $yyyy has been made." Then zero out the balance. 
Technical specifications for your application include:
Create an abstract class for a membership.  Membership id, contact email, annual cost, current monthly purchases and type are to be properties.  In addition to the constructors, include a purchase method, a return method, an abstract apply cash-back rewards method, and a useful toString.
Create four classes that inherit from the membership class - one four each membership type.  Create properties for the respective data attributes, implement the apply cash-back method for each as appropriate, and override the toString as appropriate.
In addition, the regular and executive memberships will implement a special offer method from an interface.  The implementation for a regular membership will simply return 25% of the annual membership cost and the implementation for the executive membership will return 50% of the annual membership cost.
Create and test your classes and methods with hard-coded test data so that there is a list of memberships of different types, costs, and balances.
Provide the user the following administrative options:
C - Create a new membership and add to the membership list.  Be sure you don't duplicate the membership ID.  It needs to be unique.
R - Read all of the memberships in the membership list.
U - Update an existing membership based on membership ID.
D - Delete an existing membership based on membership ID.
Provide the user the following transaction options:
L - List all of the memberships in the list including all of the information for each account type.
P - Perform a purchase transaction by getting a membership number from the user and a purchase amount and if the membership exists add the purchase amount to the monthly purchase total.
T - Perform a return transaction by getting an membership number from the user and a return amount and if the membership exists, perform the return by subtracting the return amount for the monthly purchase total.
A - Apply cash-back rewards as described above by getting a membership number from the user.
Q - Quit the transaction processing.
Direct instruction/Studio time