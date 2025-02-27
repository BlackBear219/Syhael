using Syhael.Helpers;
using Syhael.Metadata;

namespace Syhael.Extensions;

public static class WebApplicationBuilderExtension
{
    public static void ApplicationInit(this WebApplicationBuilder builder)
    {
        var appConfig = builder.InitSystemConfiguration();

        // Get the object of SqlSugarScope
        var sqlSugarScope = SqlSugarHelper.GetSqlSugarScope(appConfig.MySqlConnectionString);

        // Add singletons
        builder.Services.AddSingleton(appConfig);
        builder.Services.AddSingleton(sqlSugarScope);
    }

    private static AppConfig InitSystemConfiguration(this WebApplicationBuilder builder)
    {
        var appConfig = AppConfig.Instance();
        builder.Configuration.Bind(nameof(AppConfig), appConfig);
        return appConfig;
    }
}
