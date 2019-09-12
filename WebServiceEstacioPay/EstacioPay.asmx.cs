using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebServiceEstacioPay
{
    /// <summary>
    /// Summary description for EstacioPay
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EstacioPay : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Logar(string email, string senha)
        {
            bool res = false;
            SqlConnection con =
                new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
            try
            {
                con.Open();
                SqlCommand query =
                new SqlCommand("SELECT * FROM usuario WHERE email = @email AND senha = @senha", con);
                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@senha", senha);
                SqlDataReader leitor = query.ExecuteReader();

                res = leitor.HasRows;
            }
            catch (Exception e)
            {
                res = false;
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8 (por causa do navegador)
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(new JavaScriptSerializer().Serialize(res));
        }





        //Metodo para cadastra os usuarios
        public string Inserir(string cpf, string img, string nome, string telefone, string data_nascimento, string cnh, string email)
        {
            string res = "Inserido com sucesso!";
            SqlConnection con =
                new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("INSERT INTO Cliente VALUES(@cpf, @img, @nome, @telefone, @data_nascimento,@cnh,@email)", con);
                query.Parameters.AddWithValue("@cpf", cpf);
                query.Parameters.AddWithValue("@img",img );
                query.Parameters.AddWithValue("@nome", nome);
                query.Parameters.AddWithValue("@telefone", telefone);
                query.Parameters.AddWithValue("@data_nascimento", data_nascimento);
                query.Parameters.AddWithValue("@cnh", cnh);
                query.Parameters.AddWithValue("@email", email);
                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            return res;
        }




        //Login para estacionamento

        //[WebMethod]
        //public bool Logar2(string email, string senha)
        //{
        //    bool res = false;
        //    SqlConnection con =
        //        new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
        //    try
        //    {
        //        con.Open();
        //        SqlCommand query =
        //            new SqlCommand("SELECT * FROM Cliente WHERE email = @email AND senha = @senha", con);
        //        query.Parameters.AddWithValue("@email", email);
        //        query.Parameters.AddWithValue("@senha", senha);
        //        SqlDataReader leitor = query.ExecuteReader();

        //        res = leitor.HasRows;
        //    }
        //    catch (Exception e)
        //    {
        //        res = false;
        //    }

        //    if (con.State == ConnectionState.Open)
        //        con.Close();

        //    return res;
        //}
    }
}
