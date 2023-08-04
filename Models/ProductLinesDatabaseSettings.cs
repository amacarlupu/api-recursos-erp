namespace SupportPageApi.Models
{
    // Para acceder a los valores de ProductLine en appsetings.json
    public class ProductLinesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ProductCollectionName { get; set; } = null!;
    }
}
