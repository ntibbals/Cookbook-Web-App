using System;
using Xunit;
using Cookbook_Web_App.Models;

namespace Cookbook_Web_App_TDD
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetNameOfSavedRecipe()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.Name = "ChickenParm";

            Assert.Equal("ChickenParm", savedRecipe.Name);

        }
       

        [Fact]
        public void CanSetNameOfSavedRecipe()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.Name = "ChickenParm";
            savedRecipe.Name = "Chicken Alfredo";

            Assert.Equal("Chicken Alfredo", savedRecipe.Name);

        }

        [Fact]
        public void CanGetSavedRecipeID()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.SavedRecipeID = 2;

            Assert.Equal(2, savedRecipe.SavedRecipeID);

        }

        [Fact]
        public void CanSetSavedRecipeID()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.SavedRecipeID = 1;
            savedRecipe.SavedRecipeID = 2;

            Assert.Equal(2, savedRecipe.SavedRecipeID);

        }


        [Fact]
        public void CanGetAPIReference()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.APIReference = 1;

            Assert.Equal(1, savedRecipe.APIReference);

        }

        [Fact]
        public void CanSetAPIReference()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.APIReference = 1;
            savedRecipe.APIReference = 2;

            Assert.Equal(2, savedRecipe.APIReference);

        }
        [Fact]
        public void CanGetUserID()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.UserID = 1;

            Assert.Equal(1, savedRecipe.UserID);

        }

        [Fact]
        public void CanSetUserID()
        {
            SavedRecipe savedRecipe = new SavedRecipe();
            savedRecipe.UserID = 1;
            savedRecipe.UserID = 2;

            Assert.Equal(2, savedRecipe.UserID);

        }

        [Fact]
        public void CanGetNameOfUser()
        {
            User user = new User();
            user.UserName = "Guest34";

            Assert.Equal("Guest34", user.UserName);

        }

        [Fact]
        public void CanSetNameOfUser()
        {
            User user = new User();
            user.UserName = "Guest34";
            user.UserName = "Guest12";

            Assert.Equal("Guest12", user.UserName);

        }

        [Fact]
        public void CanGetIngredientsID()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.ID = 1;

            Assert.Equal(1, ingredients.ID);

        }
        [Fact]
        public void CanSetIngredientsID()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.ID = 1;
            ingredients.ID = 2;

            Assert.Equal(2, ingredients.ID);

        }

        [Fact]
        public void CanGetIngredientsName()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.Name = "Potato";

            Assert.Equal("Potato", ingredients.Name);

        }

        [Fact]
        public void CanSetIngredientsName()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.Name = "Potato";
            ingredients.Name = "Tomato";

            Assert.Equal("Tomato", ingredients.Name);

        }

        [Fact]
        public void CanGetIngredientsQuantity()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.Quantity = "1 cup";

            Assert.Equal("1 cup", ingredients.Quantity);

        }

        [Fact]
        public void CanSetIngredientsQuantity()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.Quantity = "1 cup";
            ingredients.Quantity = "2 cups";

            Assert.Equal("2 cups", ingredients.Quantity);

        }

        [Fact]
        public void CanSetIngredientsRecipeID()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.RecipeID = 1;
            ingredients.RecipeID = 2;

            Assert.Equal(2, ingredients.RecipeID);

        }

        [Fact]
        public void CanGetIngredientsRecipeID()
        {
            Ingredients ingredients = new Ingredients();
            ingredients.RecipeID = 1;

            Assert.Equal(1, ingredients.RecipeID);

        }

        [Fact]
        public void CanGetInstructionsRecipeId()
        {
            Instructions instructions = new Instructions();
            instructions.RecipeId = 1;

            Assert.Equal(1, instructions.RecipeId);

        }

        [Fact]
        public void CanSetInstructionsRecipeId()
        {
            Instructions instructions = new Instructions();
            instructions.RecipeId = 1;
            instructions.RecipeId = 2;

            Assert.Equal(2, instructions.RecipeId);

        }
        [Fact]
        public void CanGetInstructionsStepNumberID()
        {
            Instructions instructions = new Instructions();
            instructions.stepNumberID = 1;

            Assert.Equal(1, instructions.stepNumberID);

        }
        [Fact]
        public void CanSetInstructionsStepNumberID()
        {
            Instructions instructions = new Instructions();
            instructions.stepNumberID = 1;
            instructions.stepNumberID = 2;

            Assert.Equal(2, instructions.stepNumberID);

        }
        [Fact]
        public void CanGetInstructionsAction()
        {
            Instructions instructions = new Instructions();
            instructions.action = "Pour";

            Assert.Equal("Pour", instructions.action);
        }
        [Fact]
        public void CanSetInstructionsAction()
        {
            Instructions instructions = new Instructions();
            instructions.action = "Sprinkle";
            instructions.action = "Pour";

            Assert.Equal("Pour", instructions.action);
        }

        [Fact]
        public void CanGetRecipeID()
        {

            Recipe recipe = new Recipe();
            recipe.ID = 1;

            Assert.Equal(1, recipe.ID);

        }
        [Fact]
        public void CanSetRecipeID()
        {

            Recipe recipe = new Recipe();
            recipe.ID = 2;
            recipe.ID = 1;

            Assert.Equal(1, recipe.ID);

        }

        [Fact]
        public void CanGetRecipeName()
        {

            Recipe recipe = new Recipe();
            recipe.Name = "Chicken Alfredo";

            Assert.Equal("Chicken Alfredo", recipe.Name);

        }

        [Fact]
        public void CanSetRecipeName()
        {

            Recipe recipe = new Recipe();
            recipe.Name = "ChickenParm";
            recipe.Name = "Chicken Alfredo";

            Assert.Equal("Chicken Alfredo", recipe.Name);

        }
        [Fact]
        public void CanGetRecipeIngredientsRecipeID()
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();
            recipeIngredients.recipeID = 1;

            Assert.Equal(1, recipeIngredients.recipeID);
        }

        [Fact]
        public void CanSetRecipeIngredientsRecipeID()
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();
            recipeIngredients.recipeID = 2;
            recipeIngredients.recipeID = 1;

            Assert.Equal(1, recipeIngredients.recipeID);
        }

        [Fact]
        public void CanGetRecipeIngredientsIngredientsID()
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();
            recipeIngredients.ingredientsID = 1;

            Assert.Equal(1, recipeIngredients.ingredientsID);

        }
        [Fact]
        public void CanSetRecipeIngredientsIngredientsID()
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();
            recipeIngredients.ingredientsID = 2;
            recipeIngredients.ingredientsID = 1;

            Assert.Equal(1, recipeIngredients.ingredientsID);

        }
        [Fact]
        public void CanGetRecipeIngredientsQuantity()
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();
            recipeIngredients.quantity = "1 cup";

            Assert.Equal("1 cup", recipeIngredients.quantity);
        }

        [Fact]
        public void CanSetRecipeIngredientsQuantity()
        {
            RecipeIngredients recipeIngredients = new RecipeIngredients();
            recipeIngredients.quantity = "2 cups";
            recipeIngredients.quantity = "1 cup";

            Assert.Equal("1 cup", recipeIngredients.quantity);
        }

        [Fact]
        public void CanGetCommentsID()
        {
            Comments comments = new Comments();
            comments.ID = 1;

            Assert.Equal(1, comments.ID);

        

        [Fact]
        public void CanSetCommentsID()
        {
            Comments comments = new Comments();
            comments.ID = 2;
            comments.ID = 1;

            Assert.Equal(1, comments.ID);

        }















    }
}
