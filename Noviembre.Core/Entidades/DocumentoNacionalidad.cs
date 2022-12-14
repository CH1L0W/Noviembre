using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class DocumentoNacionalidad
    {
        public  int Id { get; set; }
        public string Nombre { get; set; }
        public static List<DocumentoNacionalidad> GetALL()
        {
            List<DocumentoNacionalidad> docNacionalidad = new List<DocumentoNacionalidad>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM documento_nacionalidad;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DocumentoNacionalidad documentoNacionalidad = new DocumentoNacionalidad();
                        documentoNacionalidad.Id = int.Parse(dataReader["id"].ToString());
                        documentoNacionalidad.Nombre = dataReader["nombre"].ToString();
                        docNacionalidad.Add(documentoNacionalidad);
                    }

                    dataReader.Close();
                    conexion.CloseConection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return docNacionalidad;
        }
    }
}
