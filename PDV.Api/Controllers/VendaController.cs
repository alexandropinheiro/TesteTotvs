using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PDV.Api.ViewModels;
using PDV.Dominio;
using PDV.Dominio.ValorMonetario;
using PDV.Dominio.Venda;
using System;
using System.Collections.Generic;

namespace PDV.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VendaController : Controller
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly IValorRepository _valorRepository;
        private readonly IVendaService _vendaService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly List<Valor> valoresParaTroco = new List<Valor>();

        public VendaController(IVendaRepository vendaRepository,
                               IValorRepository valorRepository,
                               IVendaService vendaService,
                               IUnitOfWork uow,
                               IMapper mapper)
        {
            _vendaRepository = vendaRepository;
            _valorRepository = valorRepository;
            _vendaService = vendaService;
            _uow = uow;
            _mapper = mapper;

            valoresParaTroco = _valorRepository.ObterTodos();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Venda> Get()
        {
            return _vendaRepository.ObterTodos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Venda Get(Guid id)
        {            
            return _vendaRepository.ObterPorId(id);
        }

        // GET api/venda/gravar
        [HttpPost]
        [Route("gravar")]
        public IActionResult Gravar([FromBody]VendaViewModel vendaViewModel)
        {
            try
            {
                var vendaFactory = _mapper.Map<VendaFactory>(vendaViewModel);
                var venda = vendaFactory.Criar();
                
                _vendaService.CalcularTroco(venda, valoresParaTroco);
                _vendaRepository.Gravar(venda);

                _uow.Commit();

                return Ok(venda.DescricaoTroco());

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/venda/atualizar/id:guid
        [HttpPut]
        [Route("atualizar/{id:guid}")]
        public IActionResult Atualizar(Guid id, [FromBody]VendaViewModel vendaViewModel)
        {
            try
            {
                var venda = _vendaRepository.ObterPorId(id);
                venda.AlterarValores(vendaViewModel.ValorTotal, vendaViewModel.ValorRecebido);

                _vendaService.CalcularTroco(venda, valoresParaTroco);

                _vendaRepository.Atualizar(venda);
                _uow.Commit();

                return Ok(venda.DescricaoTroco());
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/venda/excluir/1
        [HttpDelete]
        [Route("excluir/{id}")]
        public IActionResult Excluir(Guid id)
        {
            try
            {
                var venda = _vendaRepository.ObterPorId(id);

                _vendaRepository.Excluir(venda);
                _uow.Commit();

                return Ok("Exclusão realizada com sucesso!");

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}