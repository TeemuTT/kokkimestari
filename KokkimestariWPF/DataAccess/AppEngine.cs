/*
* Copyright (C) JAMK/IT/Teemu Tuomela
* This file is part of the Kokkimestri project.
*
* Created: 23/03/2016
* Modified: 24/03/2016
* Author: Teemu Tuomela
*/

using KokkimestariWPF.Logic;
//using SQLite;
using System;
using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
            string cs = KokkimestariWPF.Properties.Settings.Default.DBString;
            var db = new SQLiteConnection(cs);
            db.Open();
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
                var cmd = db.CreateCommand();
                cmd.CommandText = @"create table Recipe (ID integer primary key not null, Name text not null, Instructions text not null, Ingredients text not null, Difficulty integer not null, Time integer not null, PicturePath text null);
create table Difficulty (ID integer primary key not null, Name text not null);
create table Ingredient (ID integer primary key not null, Name text not null);
create table FavouriteList(ID integer primary key not null, Name text not null, Description text null);
create table FavouriteList_Recipe (ID integer primary key not null, FavouriteList_id integer not null, Recipe_id integer not null);
create table Recipe_Ingredient (ID integer primary key not null, Recipe_id integer not null, Ingredient_id integer not null, Amount text not null);
insert into Difficulty (Name) values ('Helppo'), ('Keskivaikea'), ('Vaikea'), ('Tosi vaikea');
";
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        /// <summary>
        /// Fetches all recipes from the database.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllRecipes()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "select * from Recipe";
                    var cmd = new SQLiteCommand(sql, db);
                    var da = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Instructions", instr);
                    cmd.Parameters.AddWithValue("@Ingredients", ingred);
                    cmd.Parameters.AddWithValue("@Difficulty", diff);
                    cmd.Parameters.AddWithValue("@Time", time);
                    cmd.Parameters.AddWithValue("@PicturePath", picpath);
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
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Instructions", instr);
                    cmd.Parameters.AddWithValue("@Ingredients", ingred);
                    cmd.Parameters.AddWithValue("@Difficulty", diff);
                    cmd.Parameters.AddWithValue("@Time", time);
                    cmd.Parameters.AddWithValue("@PicturePath", picpath);
                    cmd.Parameters.AddWithValue("@ID", id);
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
                    string sql = "delete from Recipe where ID = @ID";
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@ID", id);
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
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@listID", listID);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);
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
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@listID", listID);
                    cmd.Parameters.AddWithValue("@recipeID", recipeID);
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
        public static DataTable GetDifficulties()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "select * from Difficulty";
                    var cmd = new SQLiteCommand(sql, db);
                    var da = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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
        public static DataTable GetFavouriteLists()
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "select * from FavouriteList";
                    var cmd = new SQLiteCommand(sql, db);
                    var da = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
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
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@Name", list.Name);
                    cmd.Parameters.AddWithValue("@Desc", list.Description);
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
        public static DataTable GetRecipesOfList(int listID)
        {
            try
            {
                using (var db = MakeConnection())
                {
                    string sql = "select * from Recipe where ID in (select Recipe_id from FavouriteList_Recipe where FavouriteList_id = @id);";
                    var cmd = new SQLiteCommand(sql, db);
                    cmd.Parameters.AddWithValue("@id", listID);
                    var da = new SQLiteDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
