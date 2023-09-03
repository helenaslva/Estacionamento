using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repository.Estacionamentos;
using EstacionamentoAPI.Repository.Preco;
using EstacionamentoAPI.Shared;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace EstacionamentoAPI.Handler.Estacionamentos
{
    public class EstacionamentoHandler : IEstacionamentoHandler
    {
        IEstacionamentoRepository _estacionamentoRepository;
        IPrecoRepository _precoRepository;

        public EstacionamentoHandler(IEstacionamentoRepository estacionamentoRepository, IPrecoRepository precoRepository)
        {
             _estacionamentoRepository = estacionamentoRepository;   
             _precoRepository = precoRepository;
        }

     

        public async Task<Output> SalvarEstacionamentoHandler(SalvarEstacionamentoModel salvarEstacionamentoModel)
        {
            try
            {
                var preco = await _precoRepository.ObterPrecoPorData(salvarEstacionamentoModel.DataEntrada);
                if (preco != null)
                {
                    var estacionamentoExiste = await _estacionamentoRepository.ObterEstacionamentoPorPlaca(salvarEstacionamentoModel.Placa);
                    if(estacionamentoExiste == null)
                    {
                        var estacionamento = new Estacionamento()
                        {
                            Placa = salvarEstacionamentoModel.Placa,
                            DataEntrada = salvarEstacionamentoModel.DataEntrada.AddHours(-3),
                            PrecoId = preco.Id,
                            DataInsert = DateTime.Now
                        };

                        var estacionamentoSalvo = await _estacionamentoRepository.SalvarEstacionamento(estacionamento);
                        if (estacionamentoSalvo != 0)
                        {
                            return new Output() { IsSuccess = true, Message = "Salvo com sucesso" };
                        }
                    }
                    else
                    {
                        return new Output() { IsSuccess = false, Message = "A placa já existe" };
                    }
                    
                }
                else
                {
                    return new Output() { IsSuccess = false, Message = "O preço da data inserida é inválido" };

                }

            } catch (Exception ex)
            {
                return new Output() { IsSuccess = false, Message = "Um erro inesperado ocorreu" };
            }

            return new Output() { IsSuccess = false };

        }

        public async Task<Output>AtualizarEstacionamentoHandler(AtualizarEstacionamentoModel atualizarEstacionamentoModel)
        {
            try
            {


                var estacionamento = await _estacionamentoRepository.ObterEstacionamentoPorPlaca(atualizarEstacionamentoModel.Placa);

             
                if (estacionamento != null)
                {
                    if (!IsValid(estacionamento.DataEntrada, atualizarEstacionamentoModel.DataSaida))
                    {
                        return new Output()
                        {
                            IsSuccess = false,
                            Message = "A data de saída deve ser maior que a data de entrada"
                        };
                    }

                    var duracao = atualizarEstacionamentoModel.DataSaida.Subtract(estacionamento.DataEntrada);
                    var tempoCobrado = CalcularTempoCobrado(duracao);
                    var valorTotal = CalcularValorTotal(tempoCobrado, estacionamento.Preco.Valor);


                    var estacaionamentoAtualizar = new Estacionamento()

                    {
                        Id = estacionamento.Id,
                        Placa = estacionamento.Placa,
                        DataSaida = atualizarEstacionamentoModel.DataSaida,
                        Duracao = duracao,
                        TempoCobrado = tempoCobrado,
                        DataAlteracao = DateTime.Now,
                        DataInsert = estacionamento.DataInsert,
                        DataEntrada = estacionamento.DataEntrada,
                        Preco = estacionamento.Preco,
                        ValorTotal = valorTotal

                    };

                    //estacaionamentoAtualizar.DataAlteracao = DateTime.Now.AddHours(-3);
                   // estacaionamentoAtualizar.DataSaida = DateTime.Now.AddHours(-3);

                    _estacionamentoRepository.AtualizarEstacionamento(estacaionamentoAtualizar);

                    return new Output()
                    {
                        IsSuccess = true,
                        Message = "Atualizado com sucesso"
                    };
                }
                else
                {
                    return new Output()
                    {
                        IsSuccess = false,
                        Message = "A placa indicada não existe"
                    };
                }
            }catch(Exception ex)
            {
                return new Output() { IsSuccess = false , Message = "Um erro inesperado aconteceu"};
            }
         
                return new Output() { IsSuccess = false };


        }

        private int CalcularTempoCobrado(TimeSpan duracao)
        {
            var horas = duracao.TotalHours;
           
            var horasAPagar = (int)Math.Floor(horas);
            if (horas <= 1)
            {
                horasAPagar = 1;
            }
            else
            {
                var minutos = (horas - horasAPagar) * 60;
                TimeSpan tolerancia = TimeSpan.FromMinutes(10);
                if (minutos > 0 && minutos <= 60)
                {
                    if (minutos <= 10)
                    {
                        horasAPagar = horasAPagar;
                    }
                    else
                    {
                        horasAPagar += 1;
                    }
                }
             

            }
           


            return horasAPagar;
        }

        private double CalcularValorTotal(int tempo, double valor)
        {
            double valorTotal = tempo * valor;

            return valorTotal;
        }

        public bool IsValid(DateTime dataEntrada, DateTime dataSaida)
        {
            return dataEntrada < dataSaida;
        }
    }

   
}
