Note: Challenge--Console holds the program and programUI for each Challenge.
These are all Console Apps.

# Challenge One: Komodo Cafe
Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, update menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.
 
The Menu Items:

    A meal number, so customers can say "I'll have the #5"
    A meal name
    A description
    A list of ingredients,
    A price
 
Your Task:

    Create a Menu Class with properties, constructors, and fields.
    Create a MenuRepository Class that has methods needed.
    Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
    Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.

NOTE: When you delete a menu item, the other numbers shift to replace the lost item. Personal decision.


# Challenge Two: Komodo Insurance Claims
Komodo has a bug in its software and needs some new code.
The Claim has the following properties:

    ClaimID
    ClaimType
    Description
    ClaimAmount
    DateOfIncident
    DateOfClaim
    IsValid

Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.
A ClaimType could be the following:

    Car
    Home
    Theft
 
The app will need methods to do the following:
Show a claims agent a menu:
Choose a menu item:
1. See all claims
2. Take care of next claim
3. Enter a new claim
4. Modify an existing claim

For #1, a claims agent could see all items in the queue listed out.

For #2, when a claims agent needs to deal with an item they see the next item in the queue.
(Details)
Do you want to deal with this claim now(y/n)? y

When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

For #3, when a claims agent enters new data about a claim they will be prompted for questions about it.
 
Your goal is to do the following:
1. Create a Claim class with properties, constructors, and any necessary fields.
2. Create a ClaimRepository class that has proper methods.
3. Create a Test Class for your repository methods.
4. Create a Program file that allows a claims manager to manage items in a list of claims.


# Challenge Three: Komodo Insurance Badges
Komodo Insurance is fixing their badging system.
Here's what they need:

An app that maintains a dictionary of details about employee badge information.

Essentially, an badge will have a badge number that gives access to a specific list of doors. For instance, a developer might have access to Door A1 & A5. A claims agent might have access to B2 & B4.
Your task will be to create the following:
A badge class that has the following properties:

    BadgeID
    List of door names for access

A badge repository that will have methods that do the following:

    Create a dictionary of badges.
    The key for the dictionary will be the BadgeID.
    The value for the dictionary will be the List of Door Names.
 
The Program will allow a security staff member to do the following:

    create a new badge
    update doors on an existing badge.
    delete all doors from an existing badge.
    show a list with all badge numbers and door access.

Out of scope:

You do not need to consider tying an individual badge to a particular user. Just the Badge # will do.

Be sure to Unit Test your Repository methods.

- NOTE: The Name property is never utilized in the program, but it's there for use.