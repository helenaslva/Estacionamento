
using EstacionamentoAPI.Handler.Estacionamentos;
using EstacionamentoAPI.Handler.Precos;
using EstacionamentoAPI.Models;
using EstacionamentoAPI.Repository.Estacionamentos;
using EstacionamentoAPI.Repository.Precos;
using EstacionamentoAPI.Results.Estacionamentos;
using EstacionamentoAPI.Results.Precos;
using EstacionamentoAPI.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EstacionamentoAPI.Controllers;

[ApiController, Produces("application/json")]
[Route("[controller]")]
public class PrecoController : ControllerBase
{

    private readonly IPrecoHandler _precoHandler;
    private readonly IPrecoRepository _precoRepository;

    public PrecoController(IPrecoRepository repository, IPrecoHandler estacionamentoHandler)
    {
        _precoHandler = estacionamentoHandler;
        _precoRepository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<Output>> CadastrarPreco([FromBody] AdicionarPrecoModel preco)
    {

        var salvarPreco = await _precoHandler.AdicionarPrecoHandler(preco);

        if (salvarPreco.IsSuccess)
            return Ok(salvarPreco);
        return BadRequest(salvarPreco);
    }

    [HttpGet]
    public async Task<ActionResult<List<ListarPrecosResult>>> ListarPrecos()
    {
        var precos = await _precoRepository.ListarPrecos();

        return Ok(precos);
    }
}

    
