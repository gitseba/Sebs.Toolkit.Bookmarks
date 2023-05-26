namespace Sebs.Toolkit.Databases.Sqlite.Abstractions
{
    /// <summary>
    /// Purpose: Interface with Sqlite database
    /// Created by: sebde
    /// Created at: 5/22/2023 4:23:10 PM
    /// </summary>
    public interface ISqliteService
    {
        //Task<IEnumerable<T>> QueryDatabaseAsync<T>(string connectionString, string sqlQuery);
        IEnumerable<T> QueryDatabase<T>(string connectionString, string sqlQuery);
    }
}

