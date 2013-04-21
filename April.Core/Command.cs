#region

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

#endregion

namespace April.Core
{
    public class Command : IDisposable
    {
        private readonly SqlCommand _command;
        private readonly string _commandName;
        private bool _commit = true;

        public Command(string name = null)
        {
            _command = new SqlCommand
                           {
                               Connection =
                                   new SqlConnection(ConfigurationManager.ConnectionStrings["April"].ConnectionString),
                               CommandType = CommandType.Text,
                               CommandTimeout = 90
                           };
            _commandName = name;

            _command.Connection.Open();

            _command.Transaction = string.IsNullOrEmpty(_commandName)
                                       ? _command.Connection.BeginTransaction()
                                       : _command.Connection.BeginTransaction(_commandName);
        }

        public string CommandText
        {
            get { return _command.CommandText; }
            set { _command.CommandText = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (_command == null) return;

            if (_command.Transaction != null)
            {
                if (_commit)
                    _command.Transaction.Commit();
                else
                {
                    if (string.IsNullOrEmpty(_commandName))
                        _command.Transaction.Rollback();
                    else
                        _command.Transaction.Rollback(_commandName);
                }
                //_command.Transaction.Dispose();
            }

            if (_command.Connection != null && _command.Connection.State != ConnectionState.Closed)
            {
                _command.Connection.Close();
                //_command.Connection.Dispose();
            }

            _command.Dispose();
        }

        #endregion

        public SqlDataReader ExecuteReader()
        {
            return _command.ExecuteReader();
        }

        public int ExecuteNonQuery()
        {
            return _command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            return _command.ExecuteScalar();
        }

        public SqlParameter AddParameter(string name, object value)
        {
            return _command.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }


        public void Commint()
        {
            _commit = true;
        }

        public void RollBack()
        {
            _commit = false;
        }
    }
}