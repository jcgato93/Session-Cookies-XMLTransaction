using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class clsUsuarios
    {
        string stringConnection;
        SqlConnection con = null;
        SqlCommand com = null;
        SqlDataAdapter adapter = null;
        SqlParameter parameter = null;


        public clsUsuarios()
        {
            stringConnection = clsConexion.stGetConexion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stLogin"></param>
        /// <param name="stPassword"></param>
        /// <returns></returns>
        public DataSet dsConsultar(string stLogin,string stPassword)
        {
            try
            {
                DataSet dsConsulta = new DataSet();
                con = new SqlConnection(stringConnection);
                con.Open();

                com = new SqlCommand("spConsultarUsuario", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("cLogin", stLogin));
                com.Parameters.Add(new SqlParameter("cPassword", stPassword));

                com.ExecuteNonQuery();
                adapter = new SqlDataAdapter(com);
                adapter.Fill(dsConsulta);
                return dsConsulta;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
