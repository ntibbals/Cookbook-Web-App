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
- Ability to create new user
- Ability to search for a recipe by name
- Ability to save and delete reference to recipe
- Full crud abilitys on Comments for recipes

- Ability to Add, Edit, View and Delete Recipes
- Ability to Add, Edit, View and Delete Ingredients
- Ability to Add, Edit, View and Delete Instructions
- Ability to Add and Delete RecipeIngredients
- Remove associations upon deletion


### Stretch
- Add ability to leave reviews
- Add ability to generate a meal plan
- Add Meal Type properties to recipes.
- Filter API results by Ingredient or Meal Type

### Functional Requirements
- New user can create a user name
- A user can update or delete their username 
- Users can save recipes to their account
- Users can leave comments on saved recipes. They can edit, delete and view them.


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
- If the user sees a recipe they like, they can then save a reference recipe to the SaveRecipe table.
- They can then view their saved recipes will call out to the API and return their saved recipes via ID. 
- A user can create a comment, saving it to the Comment table which is connected to the SavedRecipes table.

