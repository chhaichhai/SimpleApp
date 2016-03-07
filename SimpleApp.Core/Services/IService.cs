using System.Collections;
using System.Collections.Generic;
using TrackerEnabledDbContext.Common.Models;

namespace SimpleApp.Core.Services
{
    public interface IService<T>
    {
        /// <summary>
        /// Add a new record to T table
        /// </summary>
        /// <param name="record"></param>
        void Add(T record);

        /// <summary>
        /// Update T record
        /// </summary>
        /// <param name="record"></param>
        void Update(T record);

        /// <summary>
        /// Delete T record based on id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int? id);

        /// <summary>
        /// Return the count of T table
        /// </summary>
        /// <returns></returns>
        int GetRecordsCount();

        /// <summary>
        /// Find T record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(int? id);

        /// <summary>
        /// Return all records from the table as iqueryable
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllRecords();

        /// <summary>
        /// Return all audit logs for the table
        /// </summary>
        /// <returns></returns>
        IEnumerable<AuditLog> GetAuditLogsById(int? id);
    }
}