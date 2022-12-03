﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Noviembre.Core.Database;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<Estado> GetALL()
        {
            List<Estado> estados = new List<Estado>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM estado ORDER BY nombre;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();
                        estados.Add(estado);
                    }

                    dataReader.Close();
                    conexion.CloseConection();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return estados;
        }

        public static bool Guardar(int id, string nombre)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    if(id == 0)
                    {
                        cmd.CommandText = "INSERT INTO estado (nombre) VALUES (@nombre)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        
                    }
                    else
                    {
                        cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@id", id);
                    }
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM estado WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }

        public static Estado GetById(int id)
        {
            Estado estado = new Estado();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM Estado WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.connection);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();
                    }

                    dataReader.Close();
                    conexion.CloseConection();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return estado;
        }
    }
}
