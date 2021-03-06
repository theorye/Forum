﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Forum.Repository.DataLayer
{
    public abstract class AdoRepository<T> where T : class
    {
        private static SqlConnection _connection;

        public AdoRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }

        protected IEnumerable<T> GetRecords(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;
            _connection.Open();

            try
            {
                var reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                        list.Add(PopulateRecord(reader));
                }
                finally
                {
                    reader.Close();
                }

            }
            finally
            {
                _connection.Close();
            }

            return list;
        }
        protected T GetRecord(SqlCommand command)
        {
            T record = null;
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader);
                        break;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }

            return record;
        }

        protected void ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = _connection;
            _connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }

        protected IEnumerable<T> ExecuteStoredProc(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;
            command.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var record = PopulateRecord(reader);
                        if (record != null) list.Add(record);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }

            return list;
        }

        protected void ExecuteCommand(SqlCommand command)
        {
            command.Connection = _connection;
            command.CommandType = CommandType.Text;
            _connection.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
