using Cookbook_Web_App.Data;
using Cookbook_Web_App.Models;
using Xunit;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Cookbook_Web_App.Models.Services;
using System.Linq;
using System.Net.Http;

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
        }


        [Fact]
        public void CanSetCommentsID()
        {
            Comments comments = new Comments();
            comments.ID = 2;
            comments.ID = 1;

            Assert.Equal(1, comments.ID);

        }

        [Fact]
        public void CanGetCommentsSavedRecipeID()
        {
            Comments comments = new Comments();
            comments.SavedRecipeID = 1;

            Assert.Equal(1, comments.SavedRecipeID);

        }

        [Fact]
        public void CanSetCommentsSavedRecipeID()
        {
            Comments comments = new Comments();
            comments.SavedRecipeID = 2;
            comments.SavedRecipeID = 1;

            Assert.Equal(1, comments.SavedRecipeID);

        }

        [Fact]
        public void CanGetCommentsComment()
        {
            Comments comments = new Comments();
            comments.Comment = "Hello World";


            Assert.Equal("Hello World", comments.Comment);

        }
        [Fact]
        public void CanSetCommentsComment()
        {
            Comments comments = new Comments();
            comments.Comment = "Bye World";
            comments.Comment = "Hello World";


            Assert.Equal("Hello World", comments.Comment);

        }

        [Fact]
        public async void CanCreateComments()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanCreateComments").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                Comments comments = new Comments();
                comments.ID = 1;
                comments.APIReference = 2;
                comments.SavedRecipeID = 3;
                comments.Comment = "So delish";

                CommentsServices commentsServices = new CommentsServices(context);

                await commentsServices.CreateComment(comments);

                var result = context.Comments.FirstOrDefault(c => c.ID == comments.ID);

                Assert.Equal(comments, result);
            }
        }

        [Fact]
        public async void CanDeleteComments()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanDeleteComments").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                Comments comments = new Comments();
                comments.ID = 1;
                comments.APIReference = 2;
                comments.SavedRecipeID = 3;
                comments.Comment = "So delish";

                CommentsServices commentsServices = new CommentsServices(context);

                await commentsServices.CreateComment(comments);
                await commentsServices.Delete(1);

                var result = context.Comments.Any(c => c.ID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public async void CanReadComments()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanReadComments").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                Comments comments = new Comments();
                comments.ID = 1;
                comments.APIReference = 2;
                comments.SavedRecipeID = 3;
                comments.Comment = "So delish";

                CommentsServices commentsServices = new CommentsServices(context);

                await commentsServices.CreateComment(comments);
                await commentsServices.GetComments(comments);

                var result = context.Comments.FirstOrDefault(c => c.ID == c.ID);

                Assert.Equal(comments, result);
            }
        }
        [Fact]
        public async void CanReadSavedComments()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanReadSavedComments").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                Comments comments = new Comments();
                comments.ID = 1;
                comments.APIReference = 2;
                comments.SavedRecipeID = 3;
                comments.Comment = "So delish";

                CommentsServices commentsServices = new CommentsServices(context);

                await commentsServices.CreateComment(comments);
                await commentsServices.GetSavedComments(1);

                var result = context.Comments.FirstOrDefault(c => c.ID == 1);

                Assert.Equal(comments, result);
            }
        }

        [Fact]
        public async void CanUpdateComments()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanUpdateComments").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                Comments comments = new Comments();
                comments.ID = 1;
                comments.APIReference = 2;
                comments.SavedRecipeID = 3;
                comments.Comment = "So delish";

                CommentsServices commentsServices = new CommentsServices(context);

                await commentsServices.CreateComment(comments);
                await commentsServices.Delete(1);

                var result = context.Comments.Any(c => c.ID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public void CreateSavedRecipeExists()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CreateSavedRecipeExists").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                SavedRecipe savedRecipe = new SavedRecipe();
                savedRecipe.SavedRecipeID = 1;
                savedRecipe.Name = "Chicken";
                savedRecipe.APIReference = 2;
                savedRecipe.UserID = 2;

                SavedRecipeService savedRecipeService = new SavedRecipeService(context);

                savedRecipeService.SavedRecipeExists(1);

                var result = context.SavedRecipe.Any(s => s.SavedRecipeID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public async void CanCreateSavedRecipe()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanCreateSavedRecipe").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                SavedRecipe savedRecipe = new SavedRecipe();
                savedRecipe.SavedRecipeID = 1;
                savedRecipe.Name = "Chicken";
                savedRecipe.APIReference = 2;
                savedRecipe.UserID = 2;

                SavedRecipeService savedRecipeService = new SavedRecipeService(context);

                await savedRecipeService.CreateRecipe(savedRecipe);

                var result = context.SavedRecipe.FirstOrDefault(s => s.SavedRecipeID == s.SavedRecipeID);

                Assert.Equal(savedRecipe, result);
            }
        }

        [Fact]
        public async void CanDeleteSavedRecipe()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanDeleteSavedRecipe").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                SavedRecipe savedRecipe = new SavedRecipe();
                savedRecipe.SavedRecipeID = 1;
                savedRecipe.Name = "Chicken";
                savedRecipe.APIReference = 2;
                savedRecipe.UserID = 2;

                SavedRecipeService savedRecipeService = new SavedRecipeService(context);

                await savedRecipeService.CreateRecipe(savedRecipe);
                await savedRecipeService.DeleteSavedRecipe(1);

                var result = context.SavedRecipe.Any(s => s.SavedRecipeID == 1);

                Assert.False(result);
            }
        }

        [Fact]
        public async void CanReadSavedRecipe()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanReadSavedRecipe").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                SavedRecipe savedRecipe = new SavedRecipe();
                savedRecipe.SavedRecipeID = 1;
                savedRecipe.Name = "Chicken";
                savedRecipe.APIReference = 2;
                savedRecipe.UserID = 2;

                SavedRecipeService savedRecipeService = new SavedRecipeService(context);

                await savedRecipeService.CreateRecipe(savedRecipe);
                await savedRecipeService.GetSavedRecipe(1);

                var result = context.SavedRecipe.FirstOrDefault(s => s.SavedRecipeID == s.SavedRecipeID);

                Assert.Equal(savedRecipe, result);
            }
        }

        [Fact]
        public async void CanUpdateSavedRecipe()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanUpdateSavedRecipe").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                SavedRecipe savedRecipe = new SavedRecipe();
                savedRecipe.SavedRecipeID = 1;
                savedRecipe.Name = "Chicken";
                savedRecipe.APIReference = 2;
                savedRecipe.UserID = 2;

                savedRecipe.Name = "Pork";
                savedRecipe.APIReference = 3;
                savedRecipe.UserID = 3;

                SavedRecipeService savedRecipeService = new SavedRecipeService(context);

                await savedRecipeService.CreateRecipe(savedRecipe);
                await savedRecipeService.UpdateSavedRecipe(savedRecipe);

                var result = context.SavedRecipe.FirstOrDefault(s => s.SavedRecipeID == s.SavedRecipeID);

                Assert.Equal(savedRecipe, result);
            }
        }

        [Fact]
        public async void CanCreateUser()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanCreateUser").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                User user = new User();
                user.ID = 1;
                user.UserName = "ImCool23";

                UserService userService = new UserService(context);

                await userService.CreateUser(user);

                var result = context.User.FirstOrDefault(u => u.ID == u.ID);

                Assert.Equal(user, result);
            }
        }

        [Fact]
        public async void CanReadUser()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanReadUser").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                User user = new User();
                user.ID = 1;
                user.UserName = "ImCool23";

                UserService userService = new UserService(context);

                await userService.CreateUser(user);
                await userService.GetUser(1);

                var result = context.User.FirstOrDefault(u => u.ID == u.ID);

                Assert.Equal(user, result);
            }
        }

        [Fact]
        public async void CanReadUserAsync()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanReadUserAsync").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                User user = new User();
                user.ID = 1;
                user.UserName = "ImCool23";

                UserService userService = new UserService(context);

                await userService.CreateUser(user);
                await userService.GetUsersAsync();

                var result = context.User.FirstOrDefault(u => u.ID == u.ID);

                Assert.Equal(user, result);
            }
        }

        [Fact]
        public async void CanUpdateUser()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanUpdateUser").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                User user = new User();
                user.ID = 1;
                user.UserName = "ImCool23";

                user.UserName = "ImSOCool23";

                UserService userService = new UserService(context);

                await userService.CreateUser(user);
                await userService.UpdateUser(user);

                var result = context.User.FirstOrDefault(u => u.ID == u.ID);

                Assert.Equal(user, result);
            }
        }

        [Fact]
        public async void CanDeleteUser()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanDeleteUser").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                User user = new User();
                user.ID = 1;
                user.UserName = "ImCool23";

                UserService userService = new UserService(context);

                await userService.CreateUser(user);
                await userService.DeleteUser(1);

                var result = context.User.FirstOrDefault(u => u.ID == 1);

                Assert.Null(result);
            }
        }

        /// <summary>
        /// Can save new recipe through search service
        /// </summary>
        [Fact]
        public async void CanSaveRecipe()
        {
            DbContextOptions<CookbookDbContext> options = new DbContextOptionsBuilder<CookbookDbContext>().UseInMemoryDatabase("CanSaveSearchRecipe").Options;
            using (CookbookDbContext context = new CookbookDbContext(options))
            {
                
                Recipe testRecipe = new Recipe();
                testRecipe.ID = 1;
                testRecipe.Name = "Peaches and Cream";

                User user = new User();
                user.ID = 1;
                user.UserName = "user";

                UserService userService = new UserService(context);

                await userService.CreateUser(user);
                SearchService searchServ = new SearchService(context);
                var recipeResult = await searchServ.SaveRecipe(testRecipe.ID, user.UserName, testRecipe.Name);

                Assert.Equal(1, recipeResult.SavedRecipeID);
                
            }

        }
    }
}
