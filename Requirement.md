# Software Requirements

### Vision

- This is an all in one Cookbook. It allows the end user the ability to search for new recipes, save recipes to their personal cookbook, create new recipes to hold in their cookbook, provide feedback/review on recipes as well as set dietary preferences/requirements. It is designed to be a go to resource of all of your favorite recipes so you aren’t constantly having to do the same google search countless times or hit up Grandma for her German Chocolate cake recipe. In addition, having the ability to provide feedback on existing recipes provides transparency on both the quality of the recipe as well as creative additions to some of the staples we all love.

### Scope
- This application will be a source of popular recipes
- This application will allow users the ability to provide feedback/reviews on recipes
- This application will allows users to save and edit their favorite recipes
- This application will allow users to search for specific recipes
- Users will have the ability to create a personal profile

### MVP
- Resource for recipes in seeded database
- User profiles
- Create/Edit/Delete Recipes to user profile
- Add feedback/review on recipes

### Stretch
- Add star rating to recipes
- Add nutritional api to compare against recipes
- Add third party API to pull in recipe database
- Associate Images with recipes

### Functional Requirements
- New user can create a username
- User can search API and save returned recipes
- User can edit saved recipes
- User can create and save recipes
- Users can save food type preferences to their profile.
- User can leave reviews and comments on the recipe.




### Non-Functional Requirements

#### Usability 
- The usability to this app is straight forward, easy to use, and user friendly. Users are able to easily access recipes and alter them at ease.

#### Modifiability
- The app's modifiability can be easily changed through creating, editing, and updating through a click of a button, thereby providing this app with easy modification.


### Data Flow
- The user first lands on our homepage where they can login or create an account
- If they login, our application checks the user table to determine who they are
- If they create an account, our application will save their information into our user table
- A user can then search for a recipe which will call out to our recipe api
- Our recipe table will then pull information from the recipe ingredients, reviews and instructions tables
- If the user sees a recipe they like, they can then save the recipe which will save the recipe in our saved recipe table
- They can then view their saved recipes will result in the savedRecipe table calling out to the recipe ingredients table, instructions table, reviews table, comments.
- A user editing their saved recipes will result in the same data flow as viewing their saved recipes but simply override the previous recipe
- If a user creates a recipe, the application will add this to the saved recipe which will concurrently add the recipe ingredients, instructions, reviews, and comments which only reside on saved recipes




# Schema Description
- The user contains a Primary Key of ID(int), UserName(varchar), and dietary preference properties(bit). User has the navigational property of Saved Recipes. It has a one to many relationship with SavedRecipes. 
- SavedRecipes contains a Primary Key of ID(int) a Foreign Key of UserID(int) referencing the User table. It also contains dietary preferent properties(bool). It has navigational properties of User, Instructions, Reviews, Comments, and SavedRecipeIngredients. It has a many to one relationship with Users, a one to many relationship to Reviews, Comments, and SaveRecipeIngredients.
- Reviews has a Primary Key of ID(int) a foreign key of SavedRecipesID, and a Review(varchar). It has a navigational property of SavedRecipes and a many to one relationship with SavedRecipes. 
- Comments has a Primary Key of ID(int) a foreign key of SavedRecipesID, and a Comment(varchar). It has a navigational property of SavedRecipes and a many to one relationship with SavedRecipes. 
- Instructions has a Composite Key of StepNumber(int) and SavedRecipesId, and a Actiont(varchar). It has a navigational property of SavedRecipes and a many to one relationship with SavedRecipes. 
- SavedRecipesIngredients has a Composite Key made up of SavedRecipeID(int) and IngredientID(int). It also contains the property Quantity(varchar). It has navigational properties of SavedRecipes and Ingredients. It has a many to one relationship with both SavedRecipes and Ingredients. 
- Ingredients has a Primary Key of ID(int) and a property Name. It has a naviational property of SavedRecipeIngredients. It has a one to many relationship with SavedRecipeIngredients. 
