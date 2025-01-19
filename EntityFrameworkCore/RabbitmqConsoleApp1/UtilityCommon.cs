using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp
{
    public class UtilityCommon
    {
        string filePath = @"D:\Application\Entityframework\APIServices\Company.csv";
        // Define your SQL Server connection string
        string connectionString = @"Server=localhost\SQLEXPRESS;Initial Catalog=EF_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";



        void LoadDataFromExcel(string filePath, string connectionString)
        {
            // Initialize Excel application object
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false; // Make Excel visible (set to true for debugging)

            // Open the Excel workbook
            var workbook = excelApp.Workbooks.Open(filePath);

            // Access the first worksheet in the workbook
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1]; // 1 for the first sheet

            // Get the used range (the part of the sheet that contains data)
            var range = worksheet.UsedRange;

            // Get the number of rows and columns in the used range
            var rowCount = range.Rows.Count;
            var colCount = range.Columns.Count;

            //// Loop through each row and column
            //for (int row = 1; row <= rowCount; row++) // Excel Interop uses 1-indexing
            //{
            //    for (int col = 1; col <= colCount; col++)
            //    {
            //        // Access the value of the cell
            //        var cellValue = range.Cells[row, col].Value2;

            //        // Print the value to the console
            //        Console.WriteLine($"Row {row}, Column {col}: {cellValue}");
            //    }
            //}
            // Loop through each row in the range
            int rowIndex = 1; // Start index (1-based for Excel)


            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        Console.WriteLine("Connection successful!");

            //        // Your database interaction code here
            //    }
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine("SQL Error: " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("General Error: " + ex.Message);
            //}



            // Set up SQL connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Loop through each row in the range
                for (int row = 2; row <= range.Rows.Count; row++) // Skipping header row
                {
                    //// Skip the first row (header)
                    //if (rowIndex == 1)
                    //{
                    //    rowIndex++;
                    //    continue; // Skip processing for the first row
                    //}

                    var OrgName = range.Cells[row, 1].Value2?.ToString();
                    var Town = range.Cells[row, 2].Value2?.ToString();
                    var County = range.Cells[row, 3].Value2?.ToString();
                    var Rating = range.Cells[row, 4].Value2?.ToString();
                    var Route = range.Cells[row, 5].Value2?.ToString();

                    //var age = range.Cells[row, 2].Value2 != null ? Convert.ToInt32(range.Cells[row, 2].Value2) : (int?)null;
                    //var department = range.Cells[row, 3].Value2?.ToString();

                    // Insert data into the database
                    string insertQuery = "INSERT INTO licensedsponsors (OrganisationName, TownCity, County,TypeRating,Route) VALUES (@OrgName, @TownCity, @County,@TypeRating, @Route)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@OrgName", OrgName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TownCity", Town ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@County", County ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TypeRating", Rating ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Route", Route ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }


                    // Access the value of the cell using a null-conditional operator
                    //  var cellValue = cell.Value2?.ToString() ?? "Empty";

                    // Print the value to the console
                    // Console.WriteLine($"Row {row.Row}, Column {cell.Column}: {cellValue}");
                }
            }

            // Close the workbook and Excel application
            workbook.Close(false);
            excelApp.Quit();

            // Release COM objects to avoid memory leaks
            System.Runtime.InteropServices.Marshal.ReleaseComObject(range);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}
