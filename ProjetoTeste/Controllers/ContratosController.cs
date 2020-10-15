using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public ContratosController(IUnitOfWork contexto, IMapper mapper)
        {
            _uof = contexto;
            _mapper = mapper;
            // _cache = cache;
        }

        // GET: api/Contratos
        [HttpGet]
        public ActionResult<IEnumerable<ContratoDTO>> Get()
        {
            try
            {
                var contratos =
                  _uof.ContratoRepository.GetContratos().ToList();
                var contratosDTO = _mapper.Map<List<ContratoDTO>>(contratos);
                //para testar (forçar) BadRequest .. descomentar lin abaixo ..
                //throw new Exception();
                return contratosDTO;
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/Contratos/5
        [HttpGet("{id}", Name = "ObterContrato")]
        public ActionResult<ContratoDTO> GetById(int id)
        {
            try
            {
                //System.TimeSpan dtAte = DateTime.Now - DateTime.MaxValue;
                //var cacheEntry = _cache.GetOrCreate("MeuCacheKey", entry =>
                //{
                //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(dtAte.TotalMinutes);
                //    entry.SetPriority(CacheItemPriority.High);
                //});

                var contrato =
                    _uof.ContratoRepository.GetById(p => p.Id == id);

                if (contrato == null)
                {
                    return NotFound();
                }

                var contratoDTO = _mapper.Map<ContratoDTO>(contrato);

                // forçar um BadRequest para testes..
                //throw new Exception();
                return contratoDTO;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Contratos
        [HttpPost]
        public ActionResult Post([FromBody] ContratoDTO contratoDto)
        {
            try
            {
                var contrato = _mapper.Map<Contrato>(contratoDto);

                _uof.ContratoRepository.Add(contrato);
                _uof.Commit();

                var contratoDTO = _mapper.Map<ContratoDTO>(contrato);

                return new CreatedAtRouteResult("ObterContrato",
                    new { id = contrato.Id }, contratoDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // PUT: api/Contratos/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ContratoDTO contratoDto)
        {
            if (id != contratoDto.Id)
            {
                return BadRequest();
            }

            var contrato = _mapper.Map<Contrato>(contratoDto);

            _uof.ContratoRepository.Update(contrato);
            _uof.Commit();
            return Ok();
        }

        // DELETE: api/Contratos/5
        [HttpDelete("{id}")]
        public ActionResult<ContratoDTO> Delete(int id)
        {
            var contrato = _uof.ContratoRepository.GetById(p => p.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            _uof.ContratoRepository.Delete(contrato);
            _uof.Commit();

            var contratoDto = _mapper.Map<ContratoDTO>(contrato);

            return contratoDto;
        }
    }
}
