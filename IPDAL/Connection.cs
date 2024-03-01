using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDAL
{
    /// <summary>
    /// This class is used to connect to the database.
    /// </summary>
    internal static class Connection
    {
        /// <summary>
        /// This is the connection string to the database.
        /// </summary>
        public static readonly string connectionString = "Data Source=MARCELO-LAPTOP-\\MSSQLSERVER01;Initial Catalog=ERS;Integrated Security=True;Encrypt=False";
    }
}
