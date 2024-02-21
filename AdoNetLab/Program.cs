using System.Data.SqlClient;
using System.Text;

namespace AdoNetLab
{
    internal class Program
    {
        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StationeryFirm;Integrated Security=True;Connect Timeout=30;";
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Відобразити всю інформацію про товар.");
                Console.WriteLine("2. Відображення всіх типів канцтоварів.");
                Console.WriteLine("3. Відображення всіх менеджерів з продажу");
                Console.WriteLine("4. Показати канцтовари з максимальною кількістю одиниць.");
                Console.WriteLine("5. Показати канцтовари з мінімальною кількістю одиниць.");
                Console.WriteLine("6. Показати канцтовари з мінімальною собівартістю одиниці.");
                Console.WriteLine("7. Показати канцтовари з максимальною собівартістю одиниці.");
                Console.WriteLine("8. Показати канцтовари заданого типу.");
                Console.WriteLine("9. Показати канцтовари, які продав певний менеджер з продажу.");
                Console.WriteLine("10. Показати канцтовари, які закупила певна фірма-покупець.");
                Console.WriteLine("11. Показати інформацію про нещодавній продаж.");
                Console.WriteLine("12. Показати середню кількість товарів по кожному типу канцтоварів.");
                Console.WriteLine("0. Вийти з програми");

                Console.Write("Виберіть опцію: ");
                choice = int.Parse(Console.ReadLine());

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        connection.Open();

                        switch (choice)
                        {
                            case 1:
                                DisplayAllProductData(connection);
                                break;
                            case 2:
                                DisplayAllProductTypes(connection);
                                break;
                            case 3:
                                DisplayAllSalesManagers(connection);
                                break;
                            case 4:
                                DisplayProductsWithMaxQuantity(connection);
                                break;
                            case 5:
                                DisplayProductsWithMinQuantity(connection);
                                break;
                            case 6:
                                DisplayProductsWithMinCost(connection);
                                break;
                            case 7:
                                DisplayProductsWithMaxCost(connection);
                                break;
                            case 8:
                                DisplayProductsWithSpecifiedType(connection);
                                break;
                            case 9:
                                DisplayProductsWithSpecificManager(connection);
                                break;
                            case 10:
                                DisplayProductsWithSpecificCustomer(connection);
                                break;
                            case 11:
                                DisplayRecentSalesInfo(connection);
                                break;
                            case 12:
                                DisplayAverageQuantityPerProductType(connection);
                                break;
                            case 0:
                                Console.WriteLine("До побачення!");
                                break;
                            default:
                                Console.WriteLine("Неправильний вибір.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }
                Thread.Sleep(5000);
            } while (choice != 0);



            static void DisplayAllProductData(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT p.ProductName, p.ProductType, p.Quantity, p.Cost, s.ManagerID, s.CustomerCompany, s.SoldQuantity, s.UnitPrice, s.SaleDate FROM Products p INNER JOIN Sales s ON p.ProductID = s.ProductID", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]}, Product Type: {reader["ProductType"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}, Manager ID: {reader["ManagerID"]}, Customer Company: {reader["CustomerCompany"]}, Sold Quantity: {reader["SoldQuantity"]}, Unit Price: {reader["UnitPrice"]}, Sale Date: {reader["SaleDate"]}");
                        Console.WriteLine("------------------------------");
                    }
                }
            }
            static void DisplayAllProductTypes(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT ProductType FROM Products", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Type: {reader["ProductType"]}");
                    }
                }
            }
            static void DisplayAllSalesManagers(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT ManagerName FROM SalesManagers", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Manager Name: {reader["ManagerName"]}");
                    }
                }
            }

            static void DisplayProductsWithMaxQuantity(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Quantity = (SELECT MAX(Quantity) FROM Products)", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]} Quantity: {reader["Quantity"]} Product Type: {reader["ProductType"]}");

                    }
                }
            }

            static void DisplayProductsWithMinQuantity(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Quantity = (SELECT MIN(Quantity) FROM Products)", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]} Quantity: {reader["Quantity"]} Product Type: {reader["ProductType"]}");
                    }
                }
            }
            static void DisplayProductsWithMinCost(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Cost = (SELECT MIN(Cost) FROM Products)", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]} Cost: {reader["Cost"]}");
                    }
                }
            }
            static void DisplayProductsWithMaxCost(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Cost = (SELECT MAX(Cost) FROM Products)", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]}, Cost: {reader["Cost"]}");
                    }
                }
            }




            static void DisplayProductsWithSpecifiedType(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE ProductType = 'Paper'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]}, Quantity: {reader["Quantity"]}, Product Type: {reader["ProductType"]}");
                    }
                }
            }

            static void DisplayProductsWithSpecificManager(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand($"SELECT p.* FROM Products p INNER JOIN Sales s ON p.ProductID = s.ProductID INNER JOIN SalesManagers m ON s.ManagerID = m.ManagerID WHERE m.ManagerName = 'Ivanov Ivan'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]}, Quantity: {reader["Quantity"]}, Product Type: {reader["ProductType"]}");
                    }
                }
            }

            static void DisplayProductsWithSpecificCustomer(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand($"SELECT p.* FROM Products p INNER JOIN Sales s ON p.ProductID = s.ProductID WHERE s.CustomerCompany LIKE '%Rainbow% LLC'", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]}, Quantity: {reader["Quantity"]}, Product Type: {reader["ProductType"]}");
                    }
                }
            }


            static void DisplayRecentSalesInfo(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Sales WHERE SaleDate >= DATEADD(day, -7, GETDATE())", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Sale ID: {reader["SaleID"]}, Product ID: {reader["ProductID"]}, Manager ID: {reader["ManagerID"]}, Customer Company: {reader["CustomerCompany"]}, Sold Quantity: {reader["SoldQuantity"]}, Unit Price: {reader["UnitPrice"]}, Sale Date: {reader["SaleDate"]}");
                    }
                }
            }

            static void DisplayAverageQuantityPerProductType(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT ProductType, AVG(Quantity) AS AverageQuantity FROM Products GROUP BY ProductType", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Type: {reader["ProductType"]}, Average Quantity: {reader["AverageQuantity"]}");
                    }
                }
            }


        }
    }
}