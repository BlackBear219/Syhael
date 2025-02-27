namespace Syhael.Helpers;

using SqlSugar;

public static class SqlSugarHelper
{
    private static SqlSugarScope? s_instance;

    private static readonly object s_lock = new ();

    public static SqlSugarScope GetSqlSugarScope(string? mySqlConnectionString)
    {
        if (mySqlConnectionString == null)
        {
            throw new ArgumentNullException("The connection string for MySql is null. Please check the app settings.");
        }

        if (s_instance == null)
        {
            lock (s_lock)
            {
                if(s_instance == null)
                {
                    s_instance = new SqlSugarScope(
                        new ConnectionConfig
                        {
                            ConfigId = DbType.MySql.ToString(),
                            ConnectionString = mySqlConnectionString,
                            DbType = DbType.MySql,
                            IsAutoCloseConnection = true,
                        },
                        db =>
                        {
                            db.Aop.OnLogExecuting = (sql, pars) => {};
                        });
                }
            }
        }

        return s_instance;
    }

    public static SqlSugarScopeProvider GetMySqlInstance()
    {
        if (s_instance == null)
        {
            throw new NullReferenceException("Cannot get connection to MySql because there was no object for SqlSugarScope being created.");
        }

        return s_instance.AsTenant().GetConnectionScope(DbType.MySql.ToString());
    }
}
