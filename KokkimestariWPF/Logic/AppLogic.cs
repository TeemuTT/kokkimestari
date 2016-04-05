/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 05/04/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
                r.Instructions = row["Instructions"].ToString();
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
        /// Deletes a recipe.
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public static bool DeleteRecipe(Recipe recipe)
        {
            try
            {
                int affected = AppEngine.DeleteRecipe(recipe.ID);
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
            var recipes = GetAllRecipes();
            if (recipes.Count == 0)
                return new Recipe(0, "Ei reseptejä!", "", "", 1, 15, @"/Images/placeholderimg.jpg");
            else if (recipes.Count == 1)
                return recipes.ElementAt(0);
            var r = new Random();
            return recipes.ElementAt(r.Next(1, GetAllRecipes().Count));
        }

        /// <summary>
        /// Returns all FavouriteLists.
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
        /// Creates a new FavouriteList.
        /// </summary>
        /// <param name="list"></param>
        public static bool AddFavouriteList(FavouriteList list)
        {
            try
            {
                if (AppEngine.AddFavouriteList(list.Name, list.Description) > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a FavouriteList.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool DeleteFavouriteList(FavouriteList list)
        {
            try
            {
                if (AppEngine.DeleteFavouriteList(list.ID) > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add recipe to a FavouriteList.
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
        /// Removes recipe from list.
        /// </summary>
        /// <param name="recipe"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool RemoveRecipeFromList(Recipe recipe, FavouriteList list)
        {
            try
            {
                if (AppEngine.RemoveRecipeFromList(recipe.ID, list.ID) > 0) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get recipes belonging to a specific FavouriteList.
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
                    r.Instructions = row["Instructions"].ToString();
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

        /// <summary>
        /// Convert minutes to hours + minutes.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string MinutesToString(int minutes)
        {
            var h = Math.Floor((decimal)minutes / 60);
            var m = minutes % 60;
            return (h > 0) ? h + "h " + m + "min" : m + "min";
        }

        /// <summary>
        /// Returns difficulty_id as string.
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public static string DifficultyToStr(int difficulty)
        {
            var difficulties = GetDifficulties();
            foreach (var d in difficulties)
            {
                if (d.ID == difficulty) return d.Name;
            }
            return "Helppo";
        }
    }

    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        private int difficulty;
        public int Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                difficulty = value;
                Difficultystr = AppLogic.DifficultyToStr(value);
            }
        }
        public string Difficultystr { get; set; }
        public int Time { get; set; }
        public string Timestr
        {
            get
            {
                return AppLogic.MinutesToString(Time);
            }
        }
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
