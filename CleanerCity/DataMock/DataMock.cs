using CleanerCity.Models;
using System.Collections.Generic;

namespace CleanerCity.DataMock
{
    public static class DataMock
    {
        public static RequestType ColetaDeLixo = new RequestType(1, "Coleta de Lixo ou Entulho");
        public static RequestType Limpeza= new RequestType(2, "Limpeza de Local ou Espaço Publico");
        public static RequestType Restauracao = new RequestType(3, "Restauração ou Reparo de Patrimonio Publico");
        public static RequestType Pavimentacao = new RequestType(4, "Restauração de Pavimentação");

        static IEnumerable<RequestType> RequestTypes = new List<RequestType>()
        {
            ColetaDeLixo,
            Limpeza,
            Restauracao,
            Pavimentacao
        };
    }
}
