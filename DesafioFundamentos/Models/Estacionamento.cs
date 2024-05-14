using System.Security.Cryptography.X509Certificates;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        List<Tuple<int, string, string>> vagas = new List<Tuple<int, string, string>>();

        string horaInicial = Convert.ToString(DateTime.Now.Hour + ":" + DateTime.Now.Minute);

        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            int indice;
            if (vagas.Count == 0)
            {
                indice = 1;
            }
            else
            {
                indice = vagas[vagas.Count - 1].Item1 + 1;
            }

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            vagas.Add(new Tuple<int, string, string>(indice, Console.ReadLine().ToUpper(), Convert.ToString(horaInicial)));

            Console.WriteLine("Veículo Adicionado ");
        }

        public void RemoverVeiculo()
        {
            if (vagas.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados!");
            }
            else
            {
                Console.WriteLine($"\n{vagas[^1].Item1}");
                foreach (var veiculo in vagas)
                {
                    Console.WriteLine($"-> {veiculo.Item1} Veículo Placa: {veiculo.Item2}, Hora Inicial: {veiculo.Item3}");
                }
                Console.WriteLine("Digite a placa do veículo desejado:");
                string placa = Console.ReadLine().ToUpper();
                int VagaVeiculo = vagas.FindIndex(x => x.Item2 == placa);
                if (VagaVeiculo == -1)
                {
                    Console.WriteLine("Placa não encontrada!");
                    RemoverVeiculo();
                }
                else
                {

                    Console.WriteLine(VagaVeiculo);
                    Console.WriteLine($"Deseja remover o veículo de placa: {placa}?\n + 1 - Sim\n + 2 - Não");
                    if (Console.ReadLine() == "1")
                    {
                        vagas.RemoveAt(VagaVeiculo);
                        Console.WriteLine("Veículo removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Veículo não removido!");
                        RemoverVeiculo();
                    }
                }
            }

        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (vagas.Any())
            {
                foreach (var veiculo in vagas)
                {
                    Console.WriteLine($"{veiculo.Item1} Placa: {veiculo.Item2}, Hora inicial: {veiculo.Item3}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
