using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class ComprobanteDomicilio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public static List<ComprobanteDomicilio> GetALL()
        {
            List<ComprobanteDomicilio> compDomicilio = new List<ComprobanteDomicilio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM comprobante_domicilio;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ComprobanteDomicilio comprobanteDomicilio = new ComprobanteDomicilio();
                        comprobanteDomicilio.Id = int.Parse(dataReader["id"].ToString());
                        comprobanteDomicilio.Nombre = dataReader["nombre"].ToString();
                        compDomicilio.Add(comprobanteDomicilio);
                    }

                    dataReader.Close();
                    conexion.CloseConection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return compDomicilio;
        }
    }
}
