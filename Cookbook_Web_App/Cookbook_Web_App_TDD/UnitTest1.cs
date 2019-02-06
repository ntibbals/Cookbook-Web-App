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
    }
}
