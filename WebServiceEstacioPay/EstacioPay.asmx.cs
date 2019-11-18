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

                if (leitor.HasRows) {
                    while (leitor.Read()) {
                        Context.Response.ContentType = "application/json; charset=utf-8";
                        Context.Response.Write(new JavaScriptSerializer().Serialize(leitor.GetString(3)));
                    }
                }else {
                    Context.Response.ContentType = "application/json; charset=utf-8";
                    Context.Response.Write(new JavaScriptSerializer().Serialize(res));
                }

               
            }
            catch (Exception e)
            {
                res = false;
                Context.Response.ContentType = "application/json; charset=utf-8";
                Context.Response.Write(new JavaScriptSerializer().Serialize(res));
            }

            if (con.State == ConnectionState.Open)
                con.Close();
            
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void VerificarConta(string email) {
            string res ="";
            SqlConnection con =
                new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
            try {
                con.Open();
                SqlCommand query =
                new SqlCommand("select TipoConta from usuario where email=@email", con);
                query.Parameters.AddWithValue("@email", email);
                SqlDataReader leitor = query.ExecuteReader();

                while (leitor.Read()) {
                    res = leitor["TipoConta"].ToString();
                }
               
                
            } catch (Exception e) {
               res =  "Invalido";
            }

            if (con.State == ConnectionState.Open)
                con.Close();

            //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8 (por causa do navegador)
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(new JavaScriptSerializer().Serialize(res));
        }



        //Metodo para cadastra contas
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Inserir(string email, string senha, string tipoConta)
        {
            bool res = false;

            SqlConnection con =
               new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
            try
            {
                con.Open();
                SqlCommand query =
                    new SqlCommand("INSERT INTO usuario VALUES(@email, @senha, @tipoConta)", con);                                           
                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@senha", senha);
                query.Parameters.AddWithValue("@tipoConta", tipoConta);
                query.ExecuteNonQuery();
                res = true;

            }
            catch (Exception e)
            {
                res = false;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(new JavaScriptSerializer().Serialize(res));

        }

        //Metodo para inseir um cliente
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string InserirClinte(string cpf,byte imagem, string nome,string telefone, DateTime dataNascimento, string cnh, string email)
        {
            string res = "Inserido com sucesso!";
            SqlConnection con =
            new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
 
          
            try
            {
                con.Open();
                SqlCommand query =
                   new SqlCommand("INSERT INTO Cliente VALUES(@cpf,@imagem,@nome, @telefone, @dataNascimento,@cnh,@email)", con);
                   query.Parameters.AddWithValue("@cpf", cpf);
                   query.Parameters.AddWithValue("@imagem", imagem);
                   query.Parameters.AddWithValue("@nome", nome);
                   query.Parameters.AddWithValue("@telefone", telefone);
                   query.Parameters.AddWithValue("@dataNascimento",dataNascimento);
                   query.Parameters.AddWithValue("@cnh", cnh);
                   query.Parameters.AddWithValue("@email", email);
                   query.ExecuteNonQuery();


            }
            catch(Exception e)
            {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return res;

        }

        // Inserir estacionamento////////////////////////////////////////////////////////
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string InserirEstacionamento(string cnpj, string razao, string nomeFantasia, string bairro, string rua, int numero, string cidade, int vagas, string email, float horaUm, float horaDois)
        {
            string res = "Inserido com sucesso!";
            SqlConnection con =
            new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");


           
            try
            {
                con.Open();
                SqlCommand query =
                   new SqlCommand("INSERT INTO Estacionamento VALUES(@cnpj,@razao,@nomeFantasia,@bairro,@rua,@numero,@cidade,@vagas,@email,@horaUm,@horaDois)", con);
                query.Parameters.AddWithValue("@cnpj", cnpj);
                query.Parameters.AddWithValue("@razao", razao);
                query.Parameters.AddWithValue("@nomeFantasia", nomeFantasia);
                query.Parameters.AddWithValue("@bairro", bairro);
                query.Parameters.AddWithValue("@rua", rua);
                query.Parameters.AddWithValue("@numero", numero);
                query.Parameters.AddWithValue("@cidade", cidade);
                query.Parameters.AddWithValue("@vagas", vagas);
                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@horaUm", horaUm);
                query.Parameters.AddWithValue("@horaDois", horaDois);
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
        //Recuperando campo de estacionamento

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void Recuperadados(string email) {
            string res;
            Models.Estacionamento estac;
            SqlConnection con =
                new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
            try {
                con.Open();
                SqlCommand query =
                new SqlCommand("SELECT *FROM Estacionamento WHERE FK_Email=@email;", con);
                query.Parameters.AddWithValue("@email", email);
                SqlDataReader leitor = query.ExecuteReader();

                leitor.Read();

                estac = new Models.Estacionamento(leitor.GetString(1), leitor.GetString(2), leitor.GetString(3), leitor.GetString(4), leitor.GetString(5), leitor.GetInt32(6),
                    leitor.GetString(7), leitor.GetInt32(8), leitor.GetString(9), leitor.GetDecimal(10), leitor.GetDecimal(11));


                //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8 (por causa do navegador)
                Context.Response.ContentType = "application/json; charset=utf-8";
                Context.Response.Write(new JavaScriptSerializer().Serialize(estac));

            } catch (Exception e) {
                res = e.Message.ToString();
                Context.Response.ContentType = "application/json; charset=utf-8";
                Context.Response.Write(new JavaScriptSerializer().Serialize(res));
            }

            if (con.State == ConnectionState.Open)
                con.Close();

        }



        //Recuperando estacionamento
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GerarQrCode(string email) {
            string res;
            SqlConnection con =
                new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
            try {
                con.Open();
                SqlCommand query =
                new SqlCommand("SELECT Cnpj FROM Estacionamento WHERE FK_Email=@email; ", con);
                query.Parameters.AddWithValue("@email", email);
                SqlDataReader leitor = query.ExecuteReader();

                res = email;
            } catch (Exception e) {
                res = "Error geral";
            }

            if (con.State == ConnectionState.Open)
                con.Close();
            return res;

            //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8 (por causa do navegador)
            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(new JavaScriptSerializer().Serialize(res));
        }



        //Metodo para validar pagamento
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void pagamento(string cpfCliente) {

            bool resposta = false;
            SqlConnection con =
                new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");

            try {
                con.Open();
                SqlCommand query =
                new SqlCommand("SELECT *FROM CartaoCredito WHERE FK_cpfCliente =@cpfCliente; ", con);
                query.Parameters.AddWithValue("@cpfCliente", cpfCliente);
                SqlDataReader leitor = query.ExecuteReader();

                resposta = true;

               
               
            } catch(Exception e) {
                resposta = false;
            }

        }
        //Metodo para atualizar pagamentos
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string atualizarPagamento(DateTime horaSaida, string valorPago) {
            string resultado="";
            SqlConnection con =
                new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");

            try {
                con.Open();
                SqlCommand query =
                new SqlCommand("UPDATE Relatorio SET HoraSaida=@horaSaida,ValorPago=@valorPago; ", con);
                query.Parameters.AddWithValue("@horaSaida",horaSaida);
                query.Parameters.AddWithValue("@valorPago", valorPago);
                query.ExecuteNonQuery();

                resultado = "Atualizado com Sucesso!!!";

            } catch (Exception e) {
                resultado = "Não foi atualizado!!!";
            }

            return resultado;
        }

        //Metodo para receber a localização do estacionamento

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string localizacao(float latitude, float longitude,string cnpj) {
            string res = "Inserido com sucesso!";
            SqlConnection con =
            new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");

            try {
                con.Open();
                SqlCommand query =
                   new SqlCommand("INSERT INTO localizacao VALUES(@latitude,@longitude,@cnpj)", con);
                   query.Parameters.AddWithValue("@latitude",latitude);
                   query.Parameters.AddWithValue("@longitude",longitude);
                   query.Parameters.AddWithValue("@cnpj",cnpj); 
                   query.ExecuteNonQuery(); 


            } catch (Exception e) {
                res = e.Message;
            }

            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            return res;

        }

        //Inserir imagem

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void SalvarImagem(string titulo, string cnpj, byte[] imagebytes)
        {

            SqlConnection con = new SqlConnection("Server = ESN509VMSSQL; Database = estaciopay; User Id = Aluno; Password = Senai1234");

            con.Open();

            SqlCommand query = new SqlCommand("Insert into Arquivos VALUES(@img,@titulo,@cnpj)", con);
            query.Parameters.AddWithValue("@img", imagebytes);
            query.Parameters.AddWithValue("@titulo", titulo);
            query.Parameters.AddWithValue("@cnpj", cnpj);
            query.ExecuteNonQuery();
            con.Close();



        }


        //Metodo para cadastrar veiculos

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string Inserirveiculo(string placa, string marca, string modelo, string ano, string cor, string cnpj)
        {
            string res = "Inserido com sucesso!";
            SqlConnection con =
            new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");
            try
            {

                con.Open();
                SqlCommand query =
                   new SqlCommand("INSERT INTO Veiculo VALUES(@placa,@marca, @modelo,@ano,@cor,@cnpj)", con);
                query.Parameters.AddWithValue("@placa", placa);
                query.Parameters.AddWithValue("@marca", marca);
                query.Parameters.AddWithValue("@modelo", modelo);
                query.Parameters.AddWithValue("@ano", ano);
                query.Parameters.AddWithValue("@cor", cor);
                query.Parameters.AddWithValue("@cnpj", cnpj);
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

       /// Inserir cartão de crédito
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string cartaoCredito(string numeroCartao, string nomeCartao, string nomeCliente, string codigoSeguranca, DateTime dataVencimento, string cpfCliente)
        {
            string res = "Inserido com sucesso!";
            SqlConnection con =
            new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");


            try
            {
                con.Open();
                SqlCommand query =
                   new SqlCommand("INSERT INTO CartaoCredito VALUES(@numeroCartao,@nomeCartao, @nomeCliente, @codigoSeguranca,@dataVencimento,@cpfCliente)", con);
                query.Parameters.AddWithValue("@numeroCartao", numeroCartao);
                query.Parameters.AddWithValue("@nomeCartao", nomeCartao);
                query.Parameters.AddWithValue("@nomeCliente", nomeCliente);
                query.Parameters.AddWithValue("@codigoSeguranca", codigoSeguranca);
                query.Parameters.AddWithValue("@dataVencimento", dataVencimento);
                query.Parameters.AddWithValue("@cpfCliente", cpfCliente);
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

        /*
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string cadastrarVeiculo(string placa, string marca, string modelo, string ano,string cor, string cidade, int vagas, string email, float horaUm, float horaDois)
        {
            string res = "Inserido com sucesso!";
            SqlConnection con =
            new SqlConnection("Server=ESN509VMSSQL;Database=estaciopay ;User id=Aluno;Password=Senai1234");


            //Inserir imagem
            try
            {
                con.Open();
                SqlCommand query =
                   new SqlCommand("INSERT INTO Estacionamento VALUES(@cnpj,@razao,@nomeFantasia, @bairro, @rua,@numero,@cidade,@vagas,@email,@horaUm,@horaDois)", con);
                query.Parameters.AddWithValue("@cnpj", cnpj);
                query.Parameters.AddWithValue("@razao", razao);
                query.Parameters.AddWithValue("@nomeFantasia", nomeFantasia);
                query.Parameters.AddWithValue("@bairro", bairro);
                query.Parameters.AddWithValue("@rua", rua);
                query.Parameters.AddWithValue("@numero", numero);
                query.Parameters.AddWithValue("@cidade", cidade);
                query.Parameters.AddWithValue("@vagas", vagas);
                query.Parameters.AddWithValue("@email", email);
                query.Parameters.AddWithValue("@horaUm", horaUm);
                query.Parameters.AddWithValue("@horaDois", horaDois);
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
        */
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
