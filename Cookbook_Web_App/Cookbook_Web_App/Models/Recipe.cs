using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<string> Instructions { get; set; }
        public ICollection<string> Ingredients { get; set; }


        static HttpClient client = new HttpClient();

        public async static Task<List<Recipe>> GetRecipe(int search)
        {
            string[] values = null;
            //GetAsync takes in a string path. To get the API connection to work, run the API and replace this local host with your local host(keep api/values)
            //To test that this works, got to Search/Index
            //TODO: After deployment, change localhost to API path
            HttpResponseMessage response = await client.GetAsync("http://localhost:50170/api/Recipes");
            if (response.IsSuccessStatusCode)
            {
                values =  await response.Content.ReadAsAsync<string[]>();

            }
            using (StreamReader reader = File.OpenText(values.ToString()))
            {
                var data = "";
                data = reader.ReadToEnd();
                FeatureCollection root = JsonConvert.DeserializeObject<FeatureCollection>(data);



                List<Recipe> recipeList = new List<Recipe>();

                var recipeEnum = root.Where(r => r.Key == r.Key);
                                            

                //foreach (var item in root)
                //{
                //    recipeList.Add(new Recipe
                //    {
                //        ID = Convert.ToInt32((string)item["recipe"]["ID"]),
                //        Name = (string)item["recipe"]["Name"],
                //        Instructions = (string)item["recipe"]["Instructions"],
                //        Ingredients = (string)item["recipe"]["Ingredients"],

                                             //    });
                                             //}
            return recipeList;
            }
        }
    }
}
