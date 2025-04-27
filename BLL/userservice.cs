using System.Collections.Generic;
using TestManagementSystemApp.DAL;

namespace TestManagementSystemApp.BLL
{
    public class UserService
    {
        private Databaseservice dbService = new Databaseservice();

        // Method to fetch users
        public List<(string Username, string Role)> GetUsers()
        {
            return dbService.GetAllUsers();
        }
 


    // NEW:Feature 1 Method to add a component 
    public void AddComponent(string name, int projectId)
        {
            dbService.AddComponent(name, projectId); // Call DAL method
        }
        // NEW:Feature 2 Addition of Test
        public void AddTest(string title, string status, string instructions, int componentId) 
        {
            dbService.AddTest(title, status, instructions, componentId);// Calling DAL

         }
        // Feature 3
        public void AddUser(string username, string role)
        {
            dbService.AddUser(username, role);
        }
        // Feature 4: Get test report (title and status)
        public List<(string Title, string Status)> GetTestReport()
        {
            return dbService.GetAllTests(); // Call DAL method
        }

        // Feature 5: Update test status
        public void UpdateTestStatus(int testId, string newStatus)
        {
            dbService.UpdateTestStatus(testId, newStatus);
        }


    }
}






