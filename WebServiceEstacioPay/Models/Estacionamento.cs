using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebServiceEstacioPay.Models {
    public class Estacionamento {

     
        public string cnpj { get; set; }
        public string razao { get; set; }
        public string fantasia { get; set; }
        public string bairro { get; set; }
        public string rua { get; set; }
        public int numero { get; set; }
        public string cidade { get; set; }
        public int vagas { get; set; }
        public string email { get; set; }
        public decimal horaUm { get; set; }
        public decimal horaDois { get; set; }

        public Estacionamento(string cnpj, string razao, string fantasia, string bairro, 
            string rua, int numero, string cidade, int vagas, string email, decimal horaUm, decimal horaDois) {

            this.cnpj = cnpj;
            this.razao = razao;
            this.fantasia = fantasia;
            this.bairro = bairro;
            this.rua = rua;
            this.numero = numero;
            this.cidade = cidade;
            this.vagas = vagas;
            this.email = email;
            this.horaUm = horaUm;
            this.horaDois = horaDois;

        }
    }
    
}