using System;
using TestManagementSystemApp.BLL; 

class Program
{
    static void Main()
    {
        UserService userService = new UserService();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Software Test Management System");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. Add a new component (Feature 1)");
            Console.WriteLine("3. Add a new test (Feature 2)");
            Console.WriteLine("4. Add a new user (Feature 3)");
            Console.WriteLine("5. View test report (Feature 4)");
            Console.WriteLine("6. Update a test's status (Feature 5)");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var users = userService.GetUsers();
                    Console.WriteLine("\nConnected to MySQL Successfully!");
                    foreach (var user in users)
                    {
                        Console.WriteLine($"User: {user.Username} – Role: {user.Role}");
                    }
                    break;

                case "2":
                    Console.Write("\nEnter component name: ");
                    string compName = Console.ReadLine();
                    Console.Write("Enter project ID to link this component to: ");
                    if (int.TryParse(Console.ReadLine(), out int projectId))
                    {
                        try
                        {
                            userService.AddComponent(compName, projectId);
                            Console.WriteLine("✅ Component added successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid project ID!");
                    }
                    break;

                case "3":
                    Console.Write("\nEnter test title: ");
                    string testTitle = Console.ReadLine();

                    Console.Write("Enter test status (e.g., 'To be tested'): ");
                    string testStatus = Console.ReadLine();

                    Console.Write("Enter test instructions: ");
                    string testInstructions = Console.ReadLine();

                    Console.Write("Enter component ID to link this test to: ");
                    if (int.TryParse(Console.ReadLine(), out int componentId))
                    {
                        try
                        {
                            userService.AddTest(testTitle, testStatus, testInstructions, componentId);
                            Console.WriteLine("✅ Test added successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid component ID!");
                    }
                    break;

                    case "4":
                    Console.Write("\nEnter username: ");
                    string newUsername = Console.ReadLine();

                    Console.Write("Enter role (e.g., Admin, Developer, Tester): ");
                    string newRole = Console.ReadLine();

                    try
                    {
                        userService.AddUser(newUsername, newRole);
                        Console.WriteLine("User added successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    break;


                case "5":
                    var report = userService.GetTestReport();
                    Console.WriteLine("\n Test Report:");
                    foreach (var test in report)
                    {
                        Console.WriteLine($"Title: {test.Title} – Status: {test.Status}");
                    }
                    break;

                case "6":
                    Console.Write("\nEnter the Test ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out int testIdToUpdate))
                    {
                        Console.Write("Enter new status (To be tested / Under Testing / Completed): ");
                        string newStatus = Console.ReadLine();

                        try
                        {
                            userService.UpdateTestStatus(testIdToUpdate, newStatus);
                            Console.WriteLine("✅ Test status updated successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Invalid Test ID.");
                    }
                    break;

                case "0":
                    Console.WriteLine("👋 Exiting...");
                    return;

                default:
                    Console.WriteLine("❌ Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
