using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.AccessAPI
{
    public class SpoonacularService : ISpoonacularService
    {
        public async Task<IEnumerable<Recipe>> Get5Recipies(String query)
        {
            List<Recipe> recipes = new List<Recipe>();

            var url = $"https://dog.ceo/api/breeds/image/random";
            var parameters = $"?query={query}&apiKey={ConstantString.SpoonacularKey}&number=5";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var recipeList = JsonConvert.DeserializeObject<RecipeList>(jsonString);

                if (recipeList != null)
                {
                    recipes.AddRange(recipeList.Recipes);
                }
            }

            return recipes;
        }
    }

    public interface ISpoonacularService
    {
      public  Task<IEnumerable<Recipe>> Get5Recipies(string query);
    }


    
    public class Recipe
    {
        
        public string Title { get; set; }
    }

    [Serializable]
    public class RecipeList
    {
        [JsonProperty("results")]
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
