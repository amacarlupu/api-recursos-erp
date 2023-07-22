namespace SupportPageApi.Models
{
    public class SupportDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string SupportCollectionName { get; set; } = null!;
    }
}
