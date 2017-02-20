namespace Repository.Repositories
{
    public class DataSource
    {
        public static string getConnectionString(string name)
        {
            return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
