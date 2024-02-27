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
                /*Console.WriteLine("1. Відобразити всю інформацію про товар.");
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
                Console.WriteLine("12. Показати середню кількість товарів по кожному типу канцтоварів.");*/
                Console.WriteLine("1. Відобразити всю інформацію про товар.");
                Console.WriteLine("2. Вставка нових канцтоварів.");
                Console.WriteLine("3. Вставка нових типів канцтоварів.");
                Console.WriteLine("4. Вставка нових менеджерів з продажу.");
                Console.WriteLine("5. Вставка нових фірм покупців.");
                Console.WriteLine("6. Оновлення інформації про існуючі канцтовари.");
                Console.WriteLine("7. Оновлення інформації про існуючі фірми-покупці.");
                Console.WriteLine("8. Оновлення інформації про існуючих менеджерів з продажу.");
                Console.WriteLine("9. Оновлення інформації про існуючі типи канцтоварів.");
                Console.WriteLine("10. Вилучення канцтоварів.");
                Console.WriteLine("11. Вилучення менеджерів з продажу.");
                Console.WriteLine("12. Видалення типів канцтоварів.");
                Console.WriteLine("13. Вилучення фірм покупців.");
                Console.WriteLine("14. Показати інформацію про менеджерів з найбільшою кількістю продажів за кількістю одиниць.");
                Console.WriteLine("15. Показати інформацію про менеджера з продажу з найбільшою, загальною сумою прибутку.");
                Console.WriteLine("16. Показати інформацію про менеджера з продажу з найбільшою загальною сумою прибутку за вказаний проміжок часу.");
                Console.WriteLine("17. Показати інформацію про фірму-покупця, яка зробила закупку на найбільшу суму.");
                Console.WriteLine("18. Показати інформацію про тип канцтоварів з найбільшою кількістю одиниць продажів.");
                Console.WriteLine("19. Показати інформацію про тип найприбутковіших канцтоварів.");
                Console.WriteLine("20. Показати назву найпопулярніших канцтоварів.");
                Console.WriteLine("21. Показати назву канцтоварів, які не продавалися у задану кількість днів.");
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
                                InsertNewProduct(connection);
                                break;
                            case 3:
                                InsertNewProductType(connection);
                                break;
                            case 4:
                                InsertNewSalesManager(connection);
                                break;
                            case 5:
                                InsertNewCustomer(connection);
                                break;
                            case 6:
                                UpdateProduct(connection);
                                break;
                            case 7:
                                UpdateCustomer(connection);
                                break;
                            case 8:
                                UpdateSalesManager(connection);
                                break;
                            case 9:
                                UpdateProductType(connection);
                                break;
                            case 10:
                                DeleteProduct(connection);
                                break;
                            case 11:
                                DeleteSalesManager(connection);
                                break;
                            case 12:
                                DeleteProductType(connection);
                                break;
                            case 13:
                                DeleteCustomer(connection);
                                break;
                            case 14:
                                ShowManagerWithMostSalesQuantity(connection);
                                break;
                            case 15:
                                ShowManagerWithHighestProfit(connection);
                                break;
                            case 16:
                                ShowManagerWithHighestProfitInTimeRange(connection);
                                break;
                            case 17:
                                ShowTopPurchasingCustomer(connection);
                                break;
                            case 18:
                                DisplayProductTypeWithMostSales(connection);
                                break;
                            case 19:
                                DisplayMostProfitableProductTypes(connection); 
                                break;
                            case 20:
                                DisplayMostPopularProducts(connection);
                                break;
                            case 21:
                                DisplayProductsNotSoldForDays(connection);
                              break;
                            case 0:
                                Console.WriteLine("Poka!");
                                break;
                            default:
                                Console.WriteLine("Неправильний вибір.");
                                break;

                                /*case 1:
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
                                    break;*/
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка: {ex.Message}");
                    }
                }
                Thread.Sleep(5000);
            } while (choice != 0);


            static void InsertNewProduct(SqlConnection connection)
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Products (ProductName, ProductType, Quantity, Cost) VALUES ('Penal', 'SchoolItem', 150, 24.99)", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Додано {rowsAffected} записів.");
                }


            }

            static void InsertNewProductType(SqlConnection connection)
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Products (ProductType) VALUES ('SchoolItem')", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Додано {rowsAffected} записів.");

                }



            }

            static void InsertNewSalesManager(SqlConnection connection)
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO SalesManagers (ManagerName) VALUES ('Oleg Olegovich')", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Додано {rowsAffected} записів.");
                }


            }

            static void InsertNewCustomer(SqlConnection connection)
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Sales (ProductID, ManagerID, CustomerCompany, SoldQuantity, UnitPrice, SaleDate) VALUES (4, 4, 'Company KEK', 20, 60.00, '2024-02-15')", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Додано {rowsAffected} записів.");
                }
            }




            static void UpdateProduct(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE Products SET Quantity = 150, Cost = 15.99 WHERE ProductID = 1", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Оновлено {rowsAffected} записів.");
                }
            }

            static void UpdateCustomer(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE Sales SET CustomerCompany = 'Company LOL' WHERE SaleID = 4", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Оновлено {rowsAffected} записів.");
                }
            }

            static void UpdateSalesManager(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE SalesManagers SET ManagerName = 'Valera Valerovich' WHERE ManagerID = 4", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Оновлено {rowsAffected} записів.");
                }
            }

            static void UpdateProductType(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE Products SET ProductType = 'ALABAY' WHERE ProductID = 7", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Оновлено {rowsAffected} записів.");
                }
            }


            static void DeleteProduct(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductID = 7", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Видалено {rowsAffected} записів.");
                }
            }

            static void DeleteSalesManager(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM SalesManagers WHERE ManagerID = 4", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Видалено {rowsAffected} записів.");
                }
            }

            static void DeleteProductType(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductType = 'ALABAY'", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Видалено {rowsAffected} записів.");
                }
            }

            static void DeleteCustomer(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Sales WHERE SaleID = 4", connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"Видалено {rowsAffected} записів.");
                }
            }





            static void ShowManagerWithMostSalesQuantity(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT sm.ManagerID, sm.ManagerName, SUM(s.SoldQuantity) AS TotalSoldQuantity FROM Sales s INNER JOIN SalesManagers sm ON s.ManagerID = sm.ManagerID GROUP BY sm.ManagerID, sm.ManagerName ORDER BY TotalSoldQuantity DESC", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Manager ID: {reader["ManagerID"]}, Manager Name: {reader["ManagerName"]}, Total Sold Quantity: {reader["TotalSoldQuantity"]}");
                    }
                }
            }

            static void ShowManagerWithHighestProfit(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT sm.ManagerID, sm.ManagerName, SUM(s.SoldQuantity * s.UnitPrice) AS TotalProfit FROM Sales s INNER JOIN SalesManagers sm ON s.ManagerID = sm.ManagerID GROUP BY sm.ManagerID, sm.ManagerName ORDER BY TotalProfit DESC", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Manager ID: {reader["ManagerID"]}, Manager Name: {reader["ManagerName"]}, Total Profit: {reader["TotalProfit"]}");
                    }
                }
            }

            static void ShowManagerWithHighestProfitInTimeRange(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("    SELECT sm.ManagerID, sm.ManagerName, SUM(s.SoldQuantity * s.UnitPrice) AS TotalProfit FROM Sales s INNER JOIN SalesManagers sm ON s.ManagerID = sm.ManagerID WHERE s.SaleDate BETWEEN '2024-02-15' AND '2024-02-17' GROUP BY sm.ManagerID, sm.ManagerName ORDER BY TotalProfit DESC", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Manager ID: {reader["ManagerID"]}, Manager Name: {reader["ManagerName"]}, Total Profit: {reader["TotalProfit"]}");
                    }
                }
            }

            static void ShowTopPurchasingCustomer(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT s.CustomerCompany, SUM(s.SoldQuantity * s.UnitPrice) AS TotalPurchaseAmount FROM Sales s GROUP BY s.CustomerCompany ORDER BY TotalPurchaseAmount DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Top Purchasing Customer: {reader["CustomerCompany"]}, Total Purchase Amount: {reader["TotalPurchaseAmount"]}");
                    }
                }
            }



            static void DisplayProductTypeWithMostSales(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT p.ProductType, SUM(s.SoldQuantity) AS TotalSales FROM Sales s INNER JOIN Products p ON s.ProductID = p.ProductID GROUP BY p.ProductType ORDER BY TotalSales DESC", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Інформація про тип канцтоварів з найбільшою кількістю одиниць продажів:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Тип: {reader["ProductType"]}, Загальна кількість проданих одиниць: {reader["TotalSales"]}");
                    }
                }
            }

            static void DisplayMostProfitableProductTypes(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT p.ProductType, SUM(s.SoldQuantity * s.UnitPrice) AS TotalProfit FROM Sales s INNER JOIN Products p ON s.ProductID = p.ProductID GROUP BY p.ProductType ORDER BY TotalProfit DESC", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Інформація про тип найприбутковіших канцтоварів:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Тип: {reader["ProductType"]}, Загальний прибуток: {reader["TotalProfit"]}");
                    }
                }
            }

            static void DisplayMostPopularProducts(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT TOP 5 ProductName, SUM(SoldQuantity) AS TotalSales FROM Sales s INNER JOIN Products p ON s.ProductID = p.ProductID GROUP BY ProductName ORDER BY TotalSales DESC", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("Найпопулярніші канцтовари:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Назва: {reader["ProductName"]}, Загальна кількість проданих одиниць: {reader["TotalSales"]}");
                    }
                }
            }

            static void DisplayProductsNotSoldForDays(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT ProductName FROM Products WHERE ProductID NOT IN (SELECT ProductID FROM Sales WHERE SaleDate >= DATEADD(day, -2, GETDATE()))", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine($"Назва канцтоварів, які не продавалися протягом останніх 2 днів:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Назва: {reader["ProductName"]}");
                    }
                }
            }










            static void DisplayAllProductData(SqlConnection connection)
            {
                using (SqlCommand command = new SqlCommand("SELECT p.ProductName, p.ProductType, p.Quantity, p.Cost FROM Products p", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["ProductName"]}, Product Type: {reader["ProductType"]}, Quantity: {reader["Quantity"]}, Cost: {reader["Cost"]}");
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