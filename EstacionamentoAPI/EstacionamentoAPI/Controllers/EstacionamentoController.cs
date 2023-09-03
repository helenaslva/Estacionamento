
using EstacionamentoAPI.Entities;
using EstacionamentoAPI.Handler.Estacionamentos;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repository.Estacionamentos;
using EstacionamentoAPI.Results.Estacionamentos;
using EstacionamentoAPI.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace EstacionamentoAPI.Controllers;

[ApiController, Produces("application/json")]
[Route("[controller]")]
public class EstacionamentoController : ControllerBase
{

    private readonly IEstacionamentoHandler _estacionamentoHandler;
    private readonly IEstacionamentoRepository _estacionamentoRepository;

    public EstacionamentoController(IEstacionamentoHandler repository, IEstacionamentoRepository estacionamentoRepository)
    {
        _estacionamentoHandler = repository;
        _estacionamentoRepository = estacionamentoRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Output>> CadastrarEstacionamento([FromBody] SalvarEstacionamentoModel estacionamento)
    {

        var salvarEstacionamento = await _estacionamentoHandler.SalvarEstacionamentoHandler(estacionamento);

        if (salvarEstacionamento.IsSuccess)
            return Ok(salvarEstacionamento);
        return BadRequest(salvarEstacionamento);
    }

    [HttpPut("{placa}")]
    public async Task<ActionResult<Output>>AtualizarEstacionamento([FromRoute] string placa, [FromBody] DateTime dataSaida)
    {
        var utcDate = dataSaida.AddHours(-3);
        var atualizarModel = new AtualizarEstacionamentoModel { Placa = placa, DataSaida = utcDate};
        var atualizarEstacionamento = await _estacionamentoHandler.AtualizarEstacionamentoHandler(atualizarModel);
        
        if (atualizarEstacionamento.IsSuccess)
            return Ok(atualizarEstacionamento);
        return BadRequest(atualizarEstacionamento);
    }
    //public IActionResult Entrada([FromBody] Estacionamento estacionamento)
    //{
    //    estacionamento.Id = Id++;
    //    estacionamentos.Add(estacionamento);
    //    return CreatedAtAction(nameof(ListaEstacionamentoPorId), new { id = estacionamento.Id }, estacionamento);
    //}
    [HttpGet]
    public async Task<ActionResult<List<ListarEstacionamentoResult>>>ListagemEstacionamento()
    {

        var estacionamentos = await _estacionamentoRepository.ListagemEstacionamentos();
        
        return Ok(estacionamentos);
    }

        //}
        //[HttpGet("{id}")]
        //public IActionResult ListaEstacionamentoPorId(int id)
        //{
        //    var estacionamento = estacionamentos.FirstOrDefault(estacionamento => estacionamento.Id == id);
        //    if (estacionamento == null) return NotFound();
        //    return Ok(estacionamento);
        //}
    }
