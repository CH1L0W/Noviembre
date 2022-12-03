using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Horario { get; set; }
        public string Referencia { get; set; }
        public Municipio Municipio { get; set; }
        public static List<Modulo> GetALL()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT mo.id, mo.nombre, mo.direccion, mo.horario, mo.referencias, mu.nombre as municipio, e.nombre as estado\r\nFROM modulo mo \r\nINNER JOIN municipio mu ON mo.idMunicipio = mu.id\r\nINNER JOIN estado e ON mu.idEstado = e.id;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Modulo modulo = new Modulo();
                        modulo.Id = int.Parse(dataReader["id"].ToString());
                        modulo.Nombre = dataReader["nombre"].ToString();
                        modulo.Direccion = dataReader["direccion"].ToString();
                        modulo.Horario = dataReader["horario"].ToString();
                        modulo.Referencia = dataReader["referencias"].ToString();
                        Municipio municipio = new Municipio();
                        municipio.Nombre = dataReader["municipio"].ToString();
                        Estado estado = new Estado();
                        estado.Nombre = dataReader["estado"].ToString();
                        municipio.Estado = estado;
                        modulo.Municipio = municipio;
                        modulos.Add(modulo);
                    }

                    dataReader.Close();
                    conexion.CloseConection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return modulos;
        }
    }
}
