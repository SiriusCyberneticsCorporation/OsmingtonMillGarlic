using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OsmingtonMillGarlic
{
	public class DatabaseAccess
	{
		/// <summary>
		/// DatabaseAccess provides all database access functionality for the GMS.
		/// Connection to the database is automatic and is checked and re-established
		/// whenever a database activity is requested. Connection parameters are 
		/// obtained from the registry (for the current user) and also from the
		/// sql.config file (which must be co-located with the GMS Library dll.
		/// </summary>
		/// <param name="hideErrorMessages">By default, all DatabaseAccess operations 
		/// show a MessageBox if an error occurs. Setting this value to true will cause 
		/// DatabaseAccess not to show any error messages.</param>
		public DatabaseAccess(bool hideErrorMessages = false)
		{
			m_hideErrorMessages = hideErrorMessages;
		}

		/// <summary>
		/// If any command fails to complete successfully then the text associated with the last error
		/// will be available here.
		/// </summary>
		public string LastError { get { return m_lastError; } }

		/// <summary>
		/// By default, all DatabaseAccess operations show a MessageBox if an error occurs. Setting
		/// this value to true will cause DatabaseAccess not to show any error messages.
		/// </summary>
		public bool HideErrorMessages { get { return m_hideErrorMessages; } set { m_hideErrorMessages = value; } }

		/// <summary>
		/// Provides the current database connection details.
		/// </summary>
		public static string DatabaseInformation { get { return DatabaseAccess.m_databaseInformation; } }

		public static System.Drawing.Color MenuBackgroundColour { get { return DatabaseAccess.m_menuBackgroundColour; } }

		#region Private Variables 

		private const int NO_RECORD_NUMBER = -1;
		public const string DATABASE_DATE_FORMAT = "\"'\"yyyy-MM-dd\"'\"";
		public const string DATABASE_TIME_FORMAT = "\"'\"HH:mm\"'\"";
		private const string DATABASE_DATE_TIME_FORMAT = "\"'\"yyyy-MM-dd HH:mm:ss\"'\"";

		private static string m_databaseUser = string.Empty;
		private static string m_databasePassword = string.Empty;
		private static string m_databaseConnectionString = string.Empty;
		private static string m_databaseInformation = string.Empty;
		private static System.Drawing.Color m_menuBackgroundColour = System.Drawing.SystemColors.Control;

		private bool m_hideErrorMessages = false;
		private string m_lastError = string.Empty;
		private MySqlConnection m_databaseConnection = null;
		private MySqlTransaction m_transaction = null;

		#endregion

		#region Common formatting methods for the construction of SQL queries.

		/// <summary>
		/// Formats a DateTime instance into a date string that can be used within an SQL query.
		/// </summary>
		/// <param name="iDateTime">The DateTime instance to format.</param>
		/// <returns>A string containing the date formatted for SQL.</returns>
		public static string FormatDate(DateTime iDateTime)
		{
			return iDateTime.ToString(DATABASE_DATE_FORMAT);	// This formatting should work regardless of database date format.
		}

		/// <summary>
		/// Formats a DateTime instance into a date and time string that can be used within an SQL query.
		/// </summary>
		/// <param name="iDateTime">The DateTime instance to format.</param>
		/// <returns>A string containing the date and time formatted for SQL.</returns>
		public static string FormatDateTime(DateTime iDateTime)
		{
			return iDateTime.ToString(DATABASE_DATE_TIME_FORMAT);	// This formatting should work regardless of database date format.
		}
		
		/// <summary>
		/// Formats text into a string that can be used within an SQL query. All single
		/// quotes are converted to double single quotes.
		/// </summary>
		/// <param name="iTextBox">The text to format.</param>
		/// <returns>A string containing the text formatted for SQL.</returns>
		public static string FormatText(string iString)
		{
			if (iString != null)
			{
				return "'" + iString.Replace("'", "''") + "'";
			}
			else
			{
				return "''";
			}
		}

		/// <summary>
		/// Formats a number in text form into a string that can be used within an SQL query.
		/// NOTE: No check is made that the text is actually a valid number.
		/// </summary>
		/// <param name="iString">The text containing the number.</param>
		/// <returns>A string containing the number formatted for SQL.</returns>
		public static string FormatNumber(string iString)
		{
			return iString;
		}

		/// <summary>
		/// Formats an integer into a string that can be used within an SQL query.
		/// </summary>
		/// <param name="iValue">The integer value to be formatted.</param>
		/// <returns>A string containing the number formatted for SQL.</returns>
		public static string FormatNumber(int iValue)
		{
			return iValue.ToString();
		}

		/// <summary>
		/// Formats a float into a string that can be used within an SQL query.
		/// </summary>
		/// <param name="fValue">The float value to be formatted.</param>
		/// <returns>A string containing the number formatted for SQL.</returns>
		public static string FormatNumber(float fValue)
		{
			return fValue.ToString();
		}

		/// <summary>
		/// Formats a double into a string that can be used within an SQL query.
		/// </summary>
		/// <param name="dValue">The double value to be formatted.</param>
		/// <returns>A string containing the number formatted for SQL.</returns>
		public static string FormatNumber(double dValue)
		{
			return dValue.ToString();
		}

		/// <summary>
		/// Formats a Decimal into a string that can be used within an SQL query.
		/// </summary>
		/// <param name="dValue">The double value to be formatted.</param>
		/// <returns>A string containing the number formatted for SQL.</returns>
		public static string FormatNumber(Decimal dValue)
		{
			return dValue.ToString();
		}

		/// <summary>
		/// Formats a boolean value into a string that can be used within an SQL query.
		/// </summary>
		/// <param name="trueFalse">The boolean value to be formatted.</param>
		/// <param name="useYesNo">Causes the value to be formatted as 'Y' and 'N' rather than '1' and '0'.</param>
		/// <returns>A string containing the boolean value formatted for SQL.</returns>
		public static string FormatBoolean(bool trueFalse, bool useYesNo = false)
		{
			if (useYesNo)
			{
				return trueFalse ? "'Y'" : "'N'";
			}
			else
			{
				return trueFalse ? "'1'" : "'0'";
			}
		}

		/// <summary>
		/// Formats the value provided using the data type provided.
		/// NOTE: Boolean data types are formatted as 'Y' and 'N'.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="dataType"></param>
		/// <returns></returns>
		public static string FormatToDataType(object value, Type dataType)
		{
			string result = string.Empty;

			if (value == null || Convert.IsDBNull(value))
			{
				result = "NULL";
			}
			else
			{
				switch (Type.GetTypeCode(dataType))
				{
					case TypeCode.Boolean:
						result = FormatBoolean((bool)value, false);
						break;
					case TypeCode.DateTime:
						DateTime convertedValue = (DateTime)value;
						if (convertedValue.Hour == 0 && convertedValue.Minute == 0 && convertedValue.Second == 0)
						{
							result = FormatDate(convertedValue);
						}
						else
						{
							result = FormatDateTime(convertedValue);
						}
						break;
					case TypeCode.Decimal:
					case TypeCode.Double:
					case TypeCode.Int16:
					case TypeCode.Int32:
						result = FormatNumber(value.ToString());
						break;
					case TypeCode.String:
					default:
						result = FormatText(value.ToString());
						break;
				}
			}

			return result;
		}

		#endregion

		#region Common DataType conversion for returned DataTable values

		public static int NULL_INT = 0;
		public static byte[] NULL_BYTE_ARRAY = null;
		public static string NULL_STRING = string.Empty;
		public static decimal NULL_DECIMAL = 0;
		public static DateTime NULL_DATETIME = DateTime.MinValue;

		public static bool GetBool(object dataTableValue)
		{
			bool result = false;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				int dummy = -1;

				// Check to see if the database entry is numeric (i.e. 0/1).
				if (int.TryParse(dataTableValue.ToString(), out dummy))
				{
					result = (dummy == 1);
				}
				// Otherwise assume that it is "true"/"false".
				else
				{
					bool.TryParse(dataTableValue.ToString(), out result);
				}
			}

			return result;
		}

		public static int GetInt(object dataTableValue)
		{
			int result = NULL_INT;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				int.TryParse(dataTableValue.ToString(), out result);
			}

			return result;
		}

		public static decimal GetDecimal(object dataTableValue)
		{
			decimal result = NULL_DECIMAL;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				decimal.TryParse(dataTableValue.ToString(), out result);
			}

			return result;
		}

		public static string GetString(object dataTableValue)
		{
			string result = NULL_STRING;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				result = dataTableValue.ToString();
			}

			if (result == null)
			{
				result = string.Empty;
			}

			return result;
		}

		public static DateTime GetDateTime(object dataTableValue)
		{
			DateTime result = NULL_DATETIME;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				DateTime.TryParse(dataTableValue.ToString(), out result);
			}

			return result;
		}

		public static byte[] GetByteArray(object dataTableValue)
		{
			byte[] result = NULL_BYTE_ARRAY;

			if (dataTableValue != null && !Convert.IsDBNull(dataTableValue))
			{
				result = (byte[])(dataTableValue);
			}

			return result;
		}


		#endregion

		#region Public Database Functionality

		/// <summary>
		/// This method is designed for use with SQL SELECT statements.
		/// </summary>
		/// <remarks>Connection to the database is automatic.</remarks>
		/// <param name="sqlQuery">The SQL SELECT statement.</param>
		/// <returns>Returns the results of the query as a single DataTable. If an error occurs
		/// then null will be returned.</returns>
		public DataTable ExecuteSelect(string sqlQuery)
		{
			DataTable resultsDataTable = null;

			if (ConfirmConnection())
			{
				try
				{
					MySqlCommand iSqlCommand = new MySqlCommand(sqlQuery, m_databaseConnection);
					MySqlDataReader dataReader = iSqlCommand.ExecuteReader();

					resultsDataTable = new DataTable();

					resultsDataTable.Load(dataReader);
					dataReader.Close();
					iSqlCommand.Dispose();

					if (m_transaction == null)
					{
						Disconnect();
					}
					m_lastError = string.Empty;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "SQL Select Error");
					}
				}
			}

			return resultsDataTable;
		}

		/// <summary>
		/// This method is designed for use with SQL statements, both transactional and stand alone, that
		/// return a single value.
		/// </summary>
		/// <remarks>Connection to the database is automatic.</remarks>
		/// <param name="sqlQuery">The SQL statement.</param>
		/// <returns>Returns the object that was found or null if nothing is found.</returns>
		public object ExecuteScalar(string sqlQuery)
		{
			object result = null;

			if (ConfirmConnection())
			{
				try
				{
					MySqlCommand iSqlCommand = new MySqlCommand(sqlQuery, m_databaseConnection);

					iSqlCommand.Transaction = m_transaction;
					result = iSqlCommand.ExecuteScalar();

					if (m_transaction == null)
					{
						Disconnect();
					}
					m_lastError = string.Empty;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "SQL Select Scalar Error");
					}
				}
			}

			return result;
		}

		/// <summary>
		/// This method is designed for use with SQL statements, both transactional and stand alone, that
		/// do not return data. Typically used with INSERT, UPDATE and DELETE.
		/// </summary>
		/// <remarks>Connection to the database is automatic.</remarks>
		/// <param name="sqlQuery">The SQL statement.</param>
		/// <returns>Returns true if the operation completed without error.</returns>
		public bool ExecuteSQL(string sqlQuery)
		{
			bool result = false;

			if (ConfirmConnection())
			{
				try
				{
					MySqlCommand iSqlCommand = new MySqlCommand(sqlQuery, m_databaseConnection);

					iSqlCommand.Transaction = m_transaction;
					iSqlCommand.ExecuteNonQuery();

					if (m_transaction == null)
					{
						Disconnect();
					}
					m_lastError = string.Empty;
					result = true;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "SQL Query Error");
					}
				}
			}

			return result;
		}
		
		/// <summary>
		/// When performing one or more operations that may need to be rolled back or committed
		/// as a group, it is necessary to begin a transaction.
		/// </summary>
		/// <returns>Returns true if the transaction is started successfully.</returns>
		public bool BeginTransaction()
		{
			bool result = false;

			if (ConfirmConnection())
			{
				try
				{
					m_transaction = m_databaseConnection.BeginTransaction();

					m_lastError = string.Empty;
					result = true;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "Error Beginning Transaction");
					}
				}
			}

			return result;
		}

		/// <summary>
		/// This method must be called once all grouped (transactional) operations have
		/// been performed in order to finalise the operations.
		/// If BeginTransaction() has not been called prior to this method being called 
		/// then no actions will be performed.
		/// </summary>
		/// <returns>Returns true if the commit operation is successful.</returns>
		public bool CommitTransaction()
		{
			bool result = false;

			if (m_transaction != null)
			{
				try
				{
					m_transaction.Commit();
					m_transaction = null;

					Disconnect();
					m_lastError = string.Empty;
					result = true;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "Error Committing Transaction");
					}
				}
			}

			return result;
		}

		/// <summary>
		/// If during a group of transactional operations there is a failure, then
		/// this method should be called to roll back any pending actions.
		/// </summary>
		/// <returns>Returns true if the rollback operation is successful.</returns>
		public bool RollbackTransaction()
		{
			bool result = false;

			if (m_transaction != null)
			{
				try
				{
					m_transaction.Rollback();
					m_transaction = null;

					Disconnect();
					m_lastError = string.Empty;
					result = true;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "Error Rolling Back Transaction");
					}
				}
			}

			return result;
		}
				
		/// <summary>
		/// Saves all changes, inserts and deletions for a "standard" table - which is a table containing a ID, RECORD_NUM
		/// and the remainder of the columns being pure data.
		/// </summary>
		/// <param name="sourceTable"></param>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public bool SaveSimpleTableWithID(DataTable sourceTable, string tableName)
		{			
			bool successful = true;
			List<string> inserts = new List<string>();
			List<string> updates = new List<string>();
			List<string> deletes = new List<string>();

			// For every row in the table determine if it has been added, deleted or changed.
			foreach (DataRow row in sourceTable.Rows)
			{
				string insertSQLColumns = string.Empty;
				string insertSQLValues = string.Empty;
				string insertSQL = "INSERT INTO " + tableName + " ({0}) VALUES ({1})";
				string updateSQL = "UPDATE " + tableName + " SET ";
				string deleteSQL = "DELETE FROM " + tableName + " WHERE ID = ";

				if (row.RowState == DataRowState.Added)
				{
					foreach (DataColumn column in sourceTable.Columns)
					{
						// Ignore the ID column (since it is generated by the database) and those that are null unless they 
						// are the columns that need to be filled programmatically (like RECORD_NUM and the sequence number).
						if (column.ColumnName == "ID")
						{
							continue;
						}
						else
						{
							// Add the column name to the list of names.
							if (insertSQLColumns != string.Empty)
							{
								insertSQLColumns += ", ";
							}
							insertSQLColumns += column.ColumnName;

							// Add the column value to the list of values.
							if (insertSQLValues != string.Empty)
							{
								insertSQLValues += ", ";
							}
							insertSQLValues += FormatToDataType(row[column], column.DataType);
						}
					}

					// Add the generated insert statement to the list.
					inserts.Add(string.Format(insertSQL, insertSQLColumns, insertSQLValues));
				}
				else if (row.RowState == DataRowState.Deleted)
				{
					int rowIndex = sourceTable.Rows.IndexOf(row);
					deletes.Add(deleteSQL + FormatNumber((int)sourceTable.Rows[rowIndex]["ID", DataRowVersion.Original]));
				}
				else if (row.RowState == DataRowState.Modified)
				{
					bool changesDetected = false;
					foreach (DataColumn column in sourceTable.Columns)
					{
						// Ignore the ID column (since it is generated by the database) and those who's values have not been changed..
						if (column.ColumnName != "ID" &&
							row[column, DataRowVersion.Original].ToString() != row[column, DataRowVersion.Current].ToString())
						{
							if (changesDetected)
							{
								updateSQL += ", ";
							}
							if (row.IsNull(column))
							{
								updateSQL += column.ColumnName + " = NULL";
							}
							else
							{
								updateSQL += column.ColumnName +
											 " = " +
											 FormatToDataType(row[column], column.DataType);
							}
							changesDetected = true;
						}
					}

					// If no changes are detected then do not perform the update, even if the row is marked as
					// Modified. This can happen if the user enters a value that is identical to the previous value.
					if (changesDetected)
					{
						updateSQL += " WHERE ID = " + FormatNumber((int)row["ID"]);
						updates.Add(updateSQL);
					}
				}
			}

			// Perform all delete operations first.
			if (deletes.Count > 0)
			{
				foreach (string sql in deletes)
				{
					successful = ExecuteSQL(sql);
					if (!successful)
					{
						break;
					}
				}
			}
			if (successful)
			{
				// Perform all update operations second.
				if (updates.Count > 0)
				{
					foreach (string sql in updates)
					{
						successful = ExecuteSQL(sql);
						if (!successful)
						{
							break;
						}
					}
				}
				if (successful)
				{
					// Finally perform insert operations incrementing the sequence number before each insert.
					if (inserts.Count > 0)
					{
						foreach (string sql in inserts)
						{
							successful = ExecuteSQL(sql);
							if (!successful)
							{
								break;
							}
						}
					}
				}
			}

			return successful;
		}

		#endregion

		#region Connection and Disconnection

		/// <summary>
		/// Attempts to make a connection to the database. It is not essential to call this method
		/// as all commands that require database access will attempt to connect if no connection 
		/// exists at their time of execution.
		/// </summary>
		/// <returns>Returns true if connected.</returns>
		private bool Connect()
		{
			bool result = false;

			if (GetConnectionParameters())
			{
				try
				{
					m_databaseConnection = new MySqlConnection(m_databaseConnectionString);

					m_databaseConnection.Open();
					m_lastError = string.Empty;
					m_databaseInformation = string.Format("User '{0}'\ris connected to Database '{1}' \rusing Data Source '{2}'",
														  m_databaseUser,
														  m_databaseConnection.Database,
														  m_databaseConnection.DataSource);

					result = true;
				}
				catch (Exception ex)
				{
					m_lastError = ex.Message;
					if (!m_hideErrorMessages)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "Error Connecting to Database");
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Disconnects from the database.
		/// </summary>
		private void Disconnect()
		{
			if (m_databaseConnection != null)
			{
				if (m_databaseConnection.State != ConnectionState.Closed)
				{
					m_databaseConnection.Close();
				}
				m_databaseConnection = null;
			}
		}

		/// <summary>
		/// Determines if there is currently a connection to the database.
		/// </summary>
		/// <returns>Returns true is the connection is open, otherwise false.</returns>
		private bool IsConnected()
		{
			bool result = false;

			if (m_databaseConnection == null || m_databaseConnection.State == System.Data.ConnectionState.Broken
											 || m_databaseConnection.State == System.Data.ConnectionState.Closed)
			{
				result = false;
			}
			else
			{
				result = true;
			}

			return result;
		}

		/// <summary>
		/// If not connected to the database then a connection is established.
		/// </summary>
		/// <returns>Returns true if connected.</returns>
		private bool ConfirmConnection()
		{
			bool result = true;

			if (!IsConnected())
			{
				result = Connect();
			}

			return result;
		}
		
		/// <summary>
		/// Retrieves the database connection parameters from the registry and sql.config file.
		/// </summary>
		/// NOTE: This should be changed so that the registry holds the database server, name, user and password.
		/// No other configuration information should then be required. It should also be possible to hold only an
		/// encrypted version of the username and password in the registry so that hackers cannot get at this information.
		/// A separate configuration application would be required to set the registry information.
		/// <returns>Returns true if parameters have been found without error.</returns>
		private bool GetConnectionParameters()
		{
			// Since it is unreasonable to expect that the application should detect a change in database connection
			// parameters once the application is running, these parameters have been made static and are only fetched
			// the first time this method is called.
			// The process of retrieving the parameters is not onerous but why waste the time when there is no need?
			if (m_databaseConnectionString.Length > 0 && m_databaseUser.Length > 0 && m_databasePassword.Length > 0)
			{
				return true;
			}
			else
			{
				m_databaseConnectionString = "SERVER=SiriusServer;" +
											 "DATABASE=OsmingtonMillGarlic;" +
											 "UID=richard;" +
											 "PASSWORD=richard; " +
											 "Encrypt = true; ";

				return m_databaseConnectionString.Length > 0;
			}
		}

		#endregion
	}
}
