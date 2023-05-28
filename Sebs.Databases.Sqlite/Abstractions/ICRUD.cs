namespace Sebs.Toolkit.Databases.Sqlite.Abstractions
{
    /// <summary>
    /// Interface used for Models that will implement CRUD operations.
    /// CRUD operations with Database. (Very useful in Repository Pattern)
    /// CRUD = Create/Read/Update/Delete
    /// </summary>
    /// <typeparam name="T"> RESPONSE: CRUD response object (e.g. DataModelOut) </typeparam>
    /// <typeparam name="U"> REQUEST: CRUD Request object (e.g. DataModelIn) </typeparam>
    public interface ICRUD<T, U>
    {
        /// <summary>
        /// Get data based on id
        /// </summary>
        T GetById(int id);

        /// <summary>
        /// Get a list with all data
        /// </summary>
        IReadOnlyList<T> GetAll();

        /// <summary>
        /// Create new data
        /// </summary>
        T Create(U createData);

        /// <summary>
        /// Update existing data
        /// </summary>
        T Update(U updatedData);

        /// <summary>
        /// Delete data
        /// </summary>
        T Delete(U deleteData);
    }
}
