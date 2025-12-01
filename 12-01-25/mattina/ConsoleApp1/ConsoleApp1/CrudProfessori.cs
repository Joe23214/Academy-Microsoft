using System.Data.SqlClient;

namespace MyApp
{
    public class CrudProfessori
    {
        public List<Professore> GetAll()
        {
            var list = new List<Professore>();

            using var conn = DBConnection.Instance.CreateConnection();
            using var cmd = new SqlCommand("SELECT * FROM Professori", conn);

            conn.Open();
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                list.Add(new Professore
                {
                    Id = rd.GetInt32(0),
                    Nome = rd.GetString(1),
                    Cognome = rd.GetString(2),
                    Materia = rd.IsDBNull(3) ? null : rd.GetString(3)
                });
            }
            return list;
        }
    }
}
