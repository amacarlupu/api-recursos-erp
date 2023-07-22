namespace SupportPageApi.Models
{
    // Para acceder a los valores de FlujosNowDatabase en appsetings.json
    public class FlujosNowDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string SupportCollectionName { get; set; } = null!;
    }
}
