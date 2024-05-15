using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        List<Tuple<int, string, TimeOnly>> vagas = new List<Tuple<int, string, TimeOnly>>();
        TimeOnly horaAtual = TimeOnly.FromDateTime(DateTime.Now);
        private int precoInicialCentavos = 0;
        private int precoPorHoraCentavos = 0;


        public Estacionamento(int precoInicialCentavos, int precoPorHoraCentavos)
        {
            this.precoInicialCentavos = precoInicialCentavos;
            this.precoPorHoraCentavos = precoPorHoraCentavos;
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
            vagas.Add(new Tuple<int, string, TimeOnly>(indice, Console.ReadLine().ToUpper(), horaAtual));

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
                    return;
                }
                else
                {
                    TimeOnly horaEntradaVeiculo = vagas[VagaVeiculo].Item3; // Pega o Objeto dentro da lista
                    horaAtual = TimeOnly.FromDateTime(DateTime.Now);

                    if (horaAtual.Hour > horaEntradaVeiculo.Hour && horaAtual.Hour - horaEntradaVeiculo.Hour >= 2) // Se o veiculo passou 1 h estacionado
                    {
                        int QuantidadeHoras = horaAtual.Hour - horaEntradaVeiculo.Hour;
                        int QuantidadeMinutos = horaAtual.Minute - horaEntradaVeiculo.Minute;
                        Console.WriteLine("bilada");
                        Console.WriteLine($"O veículo passou {QuantidadeHoras} Hora(s) e {QuantidadeMinutos} Minuto(s) estacionado");
                        Console.WriteLine($"Cliente irá pagar R$: " + (precoInicialCentavos / 100.0).ToString("F2"));
                        Console.WriteLine($"O Cliente irá pagar R$: " + ((precoInicialCentavos + (precoPorHoraCentavos * QuantidadeHoras)) / 100).ToString("F2"));

                    }
                    else // Se o veículo passou até 1 hora
                    {
                        int QuantidadeHoras = horaAtual.Hour - horaEntradaVeiculo.Hour;
                        int QuantidadeMinutos = horaAtual.Minute - horaEntradaVeiculo.Minute;
                        Console.WriteLine($"O veículo passou {QuantidadeHoras}Hora(s) e {QuantidadeMinutos} Minuto(s) estacionado");
                        Console.WriteLine($"Cliente irá pagar R$: " + (precoInicialCentavos / 100.0).ToString("F2"));
                    }

                    Console.WriteLine($"Deseja remover o veículo de placa: {placa}?\n + 1 - Sim\n + 2 - Não");
                    if (Console.ReadLine() == "1")
                    {
                        vagas.RemoveAt(VagaVeiculo);
                        Console.WriteLine("Veículo removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Veículo não removido!");
                        return;
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
