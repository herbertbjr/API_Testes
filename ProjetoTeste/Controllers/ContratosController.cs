using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoTeste.DTOs;
using ProjetoTeste.DTOs.Mappings;
using ProjetoTeste.Models;
using ProjetoTeste.Pagination;
using ProjetoTeste.Repository;

namespace ProjetoTeste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ContratosController(IUnitOfWork contexto, IMapper mapper)
        {
            _uof = contexto;
            _mapper = mapper;
        }

        // GET: api/Contratos
        [HttpGet]
        public ActionResult<IEnumerable<ContratoDTO>> Get()
        {
            var contratos = _uof.ContratoRepository.GetContratos().ToList();
            var contratosDTO = _mapper.Map<List<ContratoDTO>>(contratos);
            return contratosDTO;
        }

        //public ActionResult<IEnumerable<ContratoDTO>> Get([FromQuery] ContratosParameters contratosParameters)
        //{
        //    var contratos = _uof.ContratoRepository.GetContratos(contratosParameters).ToList();
        //    var contratosDTO = _mapper.Map<List<ContratoDTO>>(contratos);
        //    return contratosDTO;
        //}

        // GET: api/Contratos/5
        [HttpGet("{id}", Name = "ObterContrato")]
        public async Task<ActionResult<ContratoDTO>> GetById(int id)
        {
            var contrato = await _uof.ContratoRepository.GetById(p => p.Id == id);

            if (contrato == null)
            {
                return NotFound();
            }

            var contratoDTO = _mapper.Map<ContratoDTO>(contrato);

            return contratoDTO;
        }

        // POST: api/Contratos
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]ContratoDTO contratoDto)
        {
            var contrato = _mapper.Map<Contrato>(contratoDto);

            _uof.ContratoRepository.Add(contrato);
            await _uof.Commit();

            var contratoDTO = _mapper.Map<ContratoDTO>(contrato);

            return new CreatedAtRouteResult("ObterContrato", 
                new { id = contrato.Id }, contratoDTO);
        }


        // PUT: api/Contratos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContratoDTO contratoDto)
        {
            if (id != contratoDto.Id)
            {
                return BadRequest();
            }

            var contrato = _mapper.Map<Contrato>(contratoDto);

            _uof.ContratoRepository.Update(contrato);
            await _uof.Commit();
            return Ok();
        }

        // DELETE: api/Contratos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContratoDTO>> Delete(int id)
        {
            var contrato = await _uof.ContratoRepository.GetById(p => p.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            _uof.ContratoRepository.Delete(contrato);
            await _uof.Commit();

            var contratoDto = _mapper.Map<ContratoDTO>(contrato);

            return contratoDto;
        }
    }
}
