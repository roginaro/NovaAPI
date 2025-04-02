namespace NovaAPI.Repositories.Settings;

public sealed class AppSettings
{
    public DatabaseSettings DatabaseSettings { get; set; }
}
public sealed class DatabaseSettings
{
    public string ConnectionStringNovaAPI { get; set; }
}



