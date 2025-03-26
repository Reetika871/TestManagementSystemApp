using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace TestManagementSystemApp.DAL
{
    public class Databaseservice
    {
        private readonly string connectionString = "server=127.0.0.1;port=3307;database=TestManagementSystem;user=root;password=@December012;";

        //  Feature: Get all users (used in login/display)
        public List<(string Username, string Role)> GetAllUsers()
        {
            List<(string, string)> users = new List<(string, string)>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT username, role FROM Users;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add((reader["username"].ToString(), reader["role"].ToString()));
                }
            }

            return users;
        }

        // ✅ Feature 1: Add new component for a project
        public void AddComponent(string name, int projectId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Component (name, project_id) VALUES (@name, @projectId)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.ExecuteNonQuery();
            }
       
        }
        // Feature 2: Adding new test for a project
        public void AddTest(string title,string status,string instructions, int componentId )
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Test(title, status, instructions, component_id) VALUES (@title, @status, @instructions,@componentId)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@instructions", instructions);
                cmd.Parameters.AddWithValue("@componentId", componentId);

                cmd.ExecuteNonQuery();
            }
        }
        // ✅ Feature 4: View all test cases with status
        public List<(string Title, string Status)> GetAllTests()
        {
            List<(string, string)> tests = new List<(string, string)>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT title, status FROM Test;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tests.Add((reader["title"].ToString(), reader["status"].ToString()));
                }
            }

            return tests;
        }
  



}
}

