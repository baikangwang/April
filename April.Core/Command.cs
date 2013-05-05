#region

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

#endregion

namespace April.Core
{
    public class Command : IDisposable
    {
        private readonly SqlCeCommand _command;
        private readonly string _commandName;
        private bool _commit = true;

        public Command(string name = null)
        {
            _command = new SqlCeCommand
                           {
                               Connection =
                                   new SqlCeConnection(ConfigurationManager.ConnectionStrings["April"].ConnectionString),
                               CommandType = CommandType.Text//,
                               //CommandTimeout = 90
                           };
            _commandName = name;
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
                    /*if (string.IsNullOrEmpty(_commandName))*/
                        _command.Transaction.Rollback();
                    /*else
                        _command.Transaction.Rollback(_commandName);
                    */
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

        public SqlCeDataReader ExecuteReader()
        {
            _command.Connection.Open();
            
            return _command.ExecuteReader();
        }

        public int ExecuteNonQuery()
        {
            _command.Connection.Open();

            _command.Transaction = _command.Connection.BeginTransaction();
                /*string.IsNullOrEmpty(_commandName)
                                       ? _command.Connection.BeginTransaction()
                                       : _command.Connection.BeginTransaction(_commandName);
                */
            
            return _command.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            _command.Connection.Open();

            return _command.ExecuteScalar();
        }

        public SqlCeParameter AddParameter(string name, object value)
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