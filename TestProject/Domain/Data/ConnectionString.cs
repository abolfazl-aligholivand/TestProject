namespace TestProject.Domain.Data
{
    public static class ConnectionString
    {
        private static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TestDataBase;Integrated Security=True;";
        public static string DbConnectionString
        {
            get => connectionString;
        }
    }
}
