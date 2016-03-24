/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 24/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokkimestariWPF.DataAccess
{
    static class AppEngine
    {
        /// <summary>
        /// Returns an SQLiteConnection to the database.
        /// </summary>
        /// <returns></returns>
        private static SQLiteConnection MakeConnection()
        {
            var db = new SQLiteConnection("database.sqlite");
            return db;
        }

        /// <summary>
        /// Initializes the database. If it doesn't exist, creates necessary tables.
        /// </summary>
        public static void InitializeDatabase()
        {
            if (!File.Exists("database.sqlite"))
            {
                var db = MakeConnection();
                db.Execute("create table Recipe (ID integer primary key not null, Name text not null, Instructions text not null, Ingredients text not null, Difficulty integer not null, Time integer not null, PicturePath text null);");
                db.Execute("create table Difficulty (ID integer primary key not null, Name text not null);");
                db.Execute("create table Ingredient (ID integer primary key not null, Name text not null);");
                db.Execute("create table FavouriteList (ID integer primary key not null, Name text not null, Description text null);");
                db.Execute("create table FavouriteList_Recipe (ID integer primary key not null, FavouriteList_id integer not null, Recipe_id integer not null);");
                db.Execute("create table Recipe_Ingredient (ID integer primary key not null, Recipe_id integer not null, Ingredient_id integer not null, Amount text not null);");
                db.Execute("insert into Difficulty (Name) values ('Helppo'), ('Keskivaikea'), ('Vaikea'), ('Tosi vaikea');");
                db.Close();
            }
        }

        /// <summary>
        /// Gets a random recipe from the database.
        /// </summary>
        /// <returns></returns>
        public static Recipe GetRandomRecipe()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    var r = new Random();
                    var recipes = db.Table<Recipe>();
                    var recipe = recipes.ElementAt(r.Next(1, recipes.Count()));
                    return recipe;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Fetches all recipes from the database.
        /// </summary>
        /// <returns></returns>
        public static List<Recipe> GetAllRecipes()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    var recipes = db.Table<Recipe>().ToList<Recipe>();
                    return recipes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert a new recipe to the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="instr"></param>
        /// <param name="diff"></param>
        /// <param name="time"></param>
        /// <param name="picpath"></param>
        /// <returns></returns>
        public static int InsertRecipe(int id, string name, string instr, string ingred, int diff, int time, string picpath)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "insert into Recipe (Name, Instructions, Ingredients, Difficulty, Time, PicturePath) values (@Name, @Instructions, @Ingredients, @Difficulty, @Time, @PicturePath)";
                    var cmd = db.CreateCommand(sql);
                    cmd.Bind("@Name", name);
                    cmd.Bind("@Instructions", instr);
                    cmd.Bind("@Ingredients", ingred);
                    cmd.Bind("@Difficulty", diff);
                    cmd.Bind("@Time", time);
                    cmd.Bind("@PicturePath", picpath);
                    int affected = cmd.ExecuteNonQuery();
                    return affected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates a recipe in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="instr"></param>
        /// <param name="ingred"></param>
        /// <param name="diff"></param>
        /// <param name="time"></param>
        /// <param name="picpath"></param>
        /// <returns></returns>
        public static int UpdateRecipe(int id, string name, string instr, string ingred, int diff, int time, string picpath)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "update Recipe set Name = @Name, Instructions = @Instructions, Ingredients = @Ingredients, Difficulty = @Difficulty, Time = @Time, PicturePath = @PicturePath where ID = @ID";
                    var cmd = db.CreateCommand(sql);
                    cmd.Bind("@Name", name);
                    cmd.Bind("@Instructions", instr);
                    cmd.Bind("@Ingredients", ingred);
                    cmd.Bind("@Difficulty", diff);
                    cmd.Bind("@Time", time);
                    cmd.Bind("@PicturePath", picpath);
                    cmd.Bind("@ID", id);
                    int affected = cmd.ExecuteNonQuery();
                    return affected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a recipe from the database with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteRecipe(int id)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    int affected = db.Delete(id);
                    return affected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds a recipe to a list.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <param name="listID"></param>
        /// <returns></returns>
        public static int AddRecipeToList(int recipeID, int listID)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "insert into FavouriteList_Recipe (FavouriteList_id, Recipe_id) values (@listID, @recipeID)";
                    var cmd = db.CreateCommand(sql);
                    cmd.Bind("@listID", listID);
                    cmd.Bind("@recipeID", recipeID);
                    int affected = cmd.ExecuteNonQuery();
                    return affected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Removes a recipe from a list.
        /// </summary>
        /// <param name="recipeID"></param>
        /// <param name="listID"></param>
        /// <returns></returns>
        public static int RemoveRecipeFromList(int recipeID, int listID)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "delete from FavouriteList_Recipe where FavouriteList_id = @listID and Recipe_id = @recipeID";
                    var cmd = db.CreateCommand(sql);
                    cmd.Bind("@listID", listID);
                    cmd.Bind("@recipeID", recipeID);
                    int affected = cmd.ExecuteNonQuery();
                    return affected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return all Difficulties from database.
        /// </summary>
        /// <returns></returns>
        public static List<Difficulty> GetDifficulties()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    var difficulties = db.Table<Difficulty>().ToList();
                    return difficulties;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all favourite lists from the database.
        /// </summary>
        /// <returns></returns>
        public static List<FavouriteList> GetFavouriteLists()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    var lists = db.Table<FavouriteList>().ToList();
                    return lists;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Adds a favourite list to the database.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int AddFavouriteList(FavouriteList list)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "insert into FavouriteList (Name, Description) values (@Name, @Desc)";
                    var cmd = db.CreateCommand(sql);
                    cmd.Bind("@Name", list.Name);
                    cmd.Bind("@Desc", list.Description);
                    int affected = cmd.ExecuteNonQuery();
                    return affected;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get recipes belonging to a specific list.
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public static List<Recipe> GetRecipesOfList(int listID)
        {
            try
            {
                using (var db = MakeConnection())
                {

                    List<Recipe> selectedRecipes = new List<Recipe>();
                    return selectedRecipes;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
