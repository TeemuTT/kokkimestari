/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 27/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokkimestariWPF.Logic
{
    static class AppLogic
    {
        /// <summary>
        /// Returns a List<Recipe> of all recipes.
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            var dt = AppEngine.GetAllRecipes();
            foreach (DataRow row in dt.Rows)
            {
                var r = new Recipe(Convert.ToInt32(row["ID"]));
                r.Name = row["Name"].ToString();
                r.Ingredients = row["Ingredients"].ToString();
                r.Instructions = row["Ingredients"].ToString();
                r.Difficulty = Convert.ToInt32(row["Difficulty"]);
                r.Time = Convert.ToInt32(row["Time"]);
                r.PicturePath = row["PicturePath"].ToString();
                recipes.Add(r);
            }
            return recipes;
        }

        /// <summary>
        /// Insert a new recipe to the database.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static bool InsertRecipe(Recipe recipe)
        {
            try
            {
                int affected = AppEngine.InsertRecipe(recipe.Name, recipe.Instructions, recipe.Ingredients, recipe.Difficulty, recipe.Time, recipe.PicturePath);
                if (affected > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates a recipe.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static bool UpdateRecipe(Recipe recipe)
        {
            try
            {
                int affected = AppEngine.UpdateRecipe(recipe.ID, recipe.Name, recipe.Instructions, recipe.Ingredients, recipe.Difficulty, recipe.Time, recipe.PicturePath);
                if (affected > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return all difficulties.
        /// </summary>
        /// <returns></returns>
        public static List<Difficulty> GetDifficulties()
        {
            try
            {
                List<Difficulty> diffs = new List<Difficulty>();
                var dt = AppEngine.GetDifficulties();
                foreach (DataRow row in dt.Rows)
                {
                    diffs.Add(new Difficulty(
                        Convert.ToInt32(row["ID"]),
                        row["Name"].ToString()
                        ));
                }
                return diffs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns a random recipe for the day.
        /// </summary>
        /// <returns></returns>
        public static Recipe GetRecipeOfTheDay()
        {
            // TODO: Add logic to fetch only daily.
            var r = new Random();
            return GetAllRecipes().ElementAt(r.Next(1, GetAllRecipes().Count));
        }

        /// <summary>
        /// Returns all favourite lists.
        /// </summary>
        /// <returns></returns>
        public static List<FavouriteList> GetFavouriteLists()
        {
            try
            {
                List<FavouriteList> lists = new List<FavouriteList>();
                var dt = AppEngine.GetFavouriteLists();
                foreach (DataRow row in dt.Rows)
                {
                    lists.Add(new FavouriteList(
                        Convert.ToInt32(row["ID"]),
                        row["Name"].ToString(),
                        row["Description"].ToString()
                        ));
                }
                return lists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Creates a new favourite list.
        /// </summary>
        /// <param name="list"></param>
        public static bool AddFavouriteList(FavouriteList list)
        {
            try
            {
                AppEngine.AddFavouriteList(list);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add recipe to a favourite list.
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool AddRecipeToList(Recipe recipe, FavouriteList list)
        {
            try
            {
                int affected = AppEngine.AddRecipeToList(recipe.ID, list.ID);
                if (affected > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get recipes belonging to a specific list.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Recipe> GetRecipesOfList(FavouriteList list)
        {
            try
            {
                List<Recipe> recipes = new List<Recipe>();
                var dt = AppEngine.GetRecipesOfList(list.ID);
                foreach (DataRow row in dt.Rows)
                {
                    var r = new Recipe(Convert.ToInt32(row["ID"]));
                    r.Name = row["Name"].ToString();
                    r.Ingredients = row["Ingredients"].ToString();
                    r.Instructions = row["Ingredients"].ToString();
                    r.Difficulty = Convert.ToInt32(row["Difficulty"]);
                    r.Time = Convert.ToInt32(row["Time"]);
                    r.PicturePath = row["PicturePath"].ToString();
                    recipes.Add(r);
                }
                return recipes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public int Difficulty { get; set; }
        public int Time { get; set; }
        public string PicturePath { get; set; }

        public Recipe()
        {

        }

        public Recipe(int id)
        {
            ID = id;
        }

        public Recipe(int id, string name, string instr, string ingred, int diff, int time, string picpath)
        {
            ID = id;
            Name = name;
            Instructions = instr;
            Ingredients = ingred;
            Difficulty = diff;
            Time = time;
            PicturePath = picpath;
        }
    }

    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Ingredient()
        {

        }
    }

    public class Difficulty
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Difficulty(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    public class FavouriteList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public FavouriteList(int id, string name, string desc)
        {
            ID = id;
            Name = name;
            Description = desc;
        }
    }
}
