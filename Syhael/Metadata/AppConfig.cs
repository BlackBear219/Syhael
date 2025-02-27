namespace Syhael.Metadata;

public class AppConfig
{
    public string? MySqlConnectionString { get; init; }

    private AppConfig() { }

    private static AppConfig? s_instance;

    private static readonly object s_lock = new();

    public static AppConfig Instance()
    {
        if (s_instance == null)
        {
            lock (s_lock)
            {
                if (s_instance == null)
                {
                    s_instance = new AppConfig();
                }
            }
        }

        return s_instance;
    }
}
