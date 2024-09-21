using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();
            bool isValida = ValidarPlaca(placa);
            if (!isValida)
            {
                Console.WriteLine($"A placa {placa} é válida? {isValida}");
                Console.WriteLine("Placa inválida. Digite uma placa no formato ABC-1234");
                AdicionarVeiculo();
                return;
            }
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = "";
            placa = Console.ReadLine();
            
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pedir para o usuário digitar a quantidade de horas e armazenar na variável horas      
                int horas = 0;
                decimal valorTotal = 0;
                horas = Convert.ToInt32(Console.ReadLine());
                valorTotal = precoInicial + precoPorHora * horas;
                // Remover o veículo da lista e exibir a mensagem de remoção
                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine($"Desculpe, esse veículo com placa {placa} não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public static bool ValidarPlaca(string placa)
        {
            // Define a expressão regular para três letras seguidas por um hífen
            string padrao = @"^[A-Za-z]{3}-\d{4}$";
            
            // Cria uma instância de Regex com o padrão definido
            Regex regex = new Regex(padrao);
            
            // Verifica se a placa corresponde ao padrão
            return regex.IsMatch(placa);
        }
    }
}
