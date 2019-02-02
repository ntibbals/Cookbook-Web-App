# Cookbook



## Schema
![Schema Image](Assets/Schema.jpg)

### Schema Description
- The user contains a Primary Key of ID(int), UserName(varchar). User has the navigational property of Saved Recipes. It has a one to many relationship with SavedRecipes. 
- SavedRecipes contains a Primary Key of ID(int) a Foreign Key of UserID(int) referencing the User table. It also contains a ApiRecipeID which is a reference to the Recipe inside the API. It has a one to many relationship with comments. 
- Comments has a Primary Key of ID(int) a foreign key of SavedRecipesID, and a Comment(varchar). It has a navigational property of SavedRecipes and a many to one relationship with SavedRecipes. 
