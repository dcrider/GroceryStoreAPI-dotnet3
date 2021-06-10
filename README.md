# Overview
This exercise is intentionally left open ended.  Within you will find a skeleton code base and a json file intended to simulate a database.

# Requirements
 - API listing all customers
 - API retrieving a customer
 - API adding a customer
 - API updating a customer
 - Unit tests
 - Use .NET Core 3.1 or NET 5+

# Expectations
Implement the above listed requirements in a manner you see fitting.  Demonstrate design and implementation aspects you feel are important in a software project.

# Publish
Publish your implementation under your own github account.

# Notes
Used a pretty standard repo pattern with dependency injection: controller -> service -> repo -> datasource.  Initially handled data from the database.json file as a dictionary structure (Customers-1st-attempt.cs).  This was probably faster (hashes) and allowed for more database-like manipulation, but ultimately, I decided it probably wasn't worth the additional transformations necessary to convert it to/from json unless the number of customer grew very large. Also, I do now realize that 'delete' capability was not required, but I didn't notice that on first read and it just seemed natural for it to be there so I left it in.  Unit testing with Xunit.

# Would-do's:
If I was building this out into a larger application I would probably take the time to make it fully asyncronous.  
