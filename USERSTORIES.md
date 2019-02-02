# User Stories

## Title: Login
User Story: As a user, I want to be able to login with my username, and view my saved information.
Features: 
- After login, I want to be able to view and edit my profile
- I want my profile to include dietary preferences
- I want to be able to access my saved recipes 
- I want to be able to save recipes specific to my user name
Acceptance:
- Ensure that user gets the information related to their account
- Ensure sure the user’s ID matches userID in recipes

## Title: New User
User Story: As a new user, I want to be able to create a unique username to save my information.
Features:
- On the login page, I want the option to select Create New User
- I want to be able to create a username 
- I want to be given approval if the username is unique, if not, be prompted to input a new username
- After creating my username, I want to be prompted to login
Acceptance:
- I want to ensure that no username can be duplicated
- Ensure the username is saved to the database

## Title: Searching
User Story: As a user, I want to be able to search the recipe API for new recipes and save those recipes to my username.
Features:
- I want to be able to search by name, food preferences, ingredient or meal type
Acceptance:
- I want to ensure that the get request for the api works
- I want to ensure that the api returns recipes

## Title: New Recipe
User Story: As a user, I want to be able to add NEW recipe.
Features:
- I want to be given a form including ingredients, instructions and other recipe properties.
- Upon creation, I want my recipe to automatically save to my recipes
- I also want my recipe to be sent to the api.
Acceptance:
- Ensure recipe is created
- Ensure recipe is linked to user
- Ensure recipe is sent to API

## Title: Edit and Remove
User Story: As a user, I want to be able to edit and delete recipes that I have saved.   
Features:
- As a user, In my saved recipes, I want to be able to edit my recipe, it’s ingredients, instructions and properties.
- As a user, I want to be able to delete my recipe. 
Acceptance:
- Ensure upon delete, all related data is deleted
- Ensure Edited content is saved
