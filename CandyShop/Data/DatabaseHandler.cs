using MySqlConnector;
using DotNetEnv;

internal class DatabaseHandler
{
    public string ConnectionString { get; }

    public DatabaseHandler()
    {
        Env.Load();
        string host = Environment.GetEnvironmentVariable("DB_HOST")!;
        string database = Environment.GetEnvironmentVariable("DB_NAME")!;
        string user = Environment.GetEnvironmentVariable("DB_USER")!;
        string password = Environment.GetEnvironmentVariable("DB_PASSWORD")!;
        string port = Environment.GetEnvironmentVariable("DB_PORT")!;

        ConnectionString = $"Server={host};Database={database};User={user};Password={password};Port={port};";
    }

    internal void CreateDatabase()
    {
        using var connection = new MySqlConnection(ConnectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Database connection established.");

            string checkTableExistsQuery = @"
                    SELECT COUNT(*)
                    FROM information_schema.tables
                    WHERE table_schema = DATABASE() AND table_name = 'Product';";

            using var checkCommand = new MySqlCommand(checkTableExistsQuery, connection);
            bool tableExists = Convert.ToInt32(checkCommand.ExecuteScalar()) > 0;

            if (!tableExists)
            {
                string createTableQuery = @"
                        CREATE TABLE Product (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(20) NOT NULL,
                        Price DECIMAL(10, 2) NOT NULL,
                        CocoaPercentage INT NULL,
                        Shape VARCHAR(20) NULL,
                        Type INT NOT NULL
                    );";

                using var createCommand = new MySqlCommand(createTableQuery, connection);
                createCommand.ExecuteNonQuery();

                Console.WriteLine("Table 'Product' created successfully.\n");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while creating the table: {ex.Message}\n");
        }
    }
}
