using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebServiceEstacioPay.Models {
    public class Relatorios {

        public DateTime DataRelatorio { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public decimal ValorPago { get; set; }
        public string PlacaVeiculo { get; set; }
        public string cnpjEstacionamento { get; set; }

        public Relatorios(DateTime data,DateTime horaEntrada,DateTime horaSaida, decimal valorPago,string placa, string cnpjEstacionamento) {
            this.DataRelatorio = data;
            this.HoraEntrada = HoraEntrada;
            this.HoraSaida = horaSaida;
            this.ValorPago = valorPago;
            this.PlacaVeiculo = placa;
            this.cnpjEstacionamento = cnpjEstacionamento;
        }


    }
}