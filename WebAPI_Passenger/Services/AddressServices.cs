using MongoDB.Bson.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI_Passenger.Models;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace WebAPI_Passenger.Services {
    public class AddressServices {

        public AddressServices() {

        }


        public  async Task<Address> GetAddress(string cep) {
            Address address;
            using (HttpClient _adressClient = new HttpClient()) {
                HttpResponseMessage response = await _adressClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                var adressJson = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode) return address = JsonConvert.DeserializeObject<Address>(adressJson);
                else return null;
            }
        }

        //// A classe Task representa uma operação assíncrona.
        //public async Task<string> Main(string zipCode) {
        //    // A HttpClient Fornece uma classe para enviar solicitações HTTP e receber respostas HTTP de um recurso identificado por uma URI.
        //    using (HttpClient client = new HttpClient()) {
        //        // A Classe HttpResponseMensage representa uma mensagem de resposta HTTP incluindo o código de status e os dados.
        //        // O GetAsync envia uma solicitação GET para o URI especificado como uma operação assíncrona.
        //        HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + zipCode + "/json/");

        //        // O EnsureSuccessStatusCode gera uma exceção se a propriedade IsSuccessStatusCode da resposta HTTP for false
        //        response.EnsureSuccessStatusCode();

        //        // O ReadAsStringAsync serializa o conteúdo HTTP em uma cadeia de caracteres como uma operação assíncrona.
        //        return await response.Content.ReadAsStringAsync();
        //    }


        //}


    }
}
