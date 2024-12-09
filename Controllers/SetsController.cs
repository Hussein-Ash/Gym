using EvaluationBackend.DATA.DTOs.Sets;
using EvaluationBackend.Interface;
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Authorization;
>>>>>>> 6c75216 (Initial commit)
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers
{

    public class SetsController : BaseController
    {
        private readonly ISetsService _service;

        public SetsController(ISetsService service)
        {
            _service = service;
        }

<<<<<<< HEAD
        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
=======
        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
>>>>>>> 6c75216 (Initial commit)
        [HttpGet]
        public async Task<ActionResult<Respons<SetsDto>>> GetAll([FromQuery] SetsFilter filter) => Ok(await _service.GetAll(filter), filter.PageNumber);


<<<<<<< HEAD
        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
=======
        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
>>>>>>> 6c75216 (Initial commit)
        [HttpPost]
        public async Task<ActionResult<SetsDto>> Add([FromBody] SetsForm form) => Ok(await _service.Add(form));



<<<<<<< HEAD
        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) => OkObject(await _service.GetById(id));

        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) => Ok(await _service.Delete(id));

        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
=======
        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id) => OkObject(await _service.GetById(id));

        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id) => Ok(await _service.Delete(id));

        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
>>>>>>> 6c75216 (Initial commit)
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(SetsUpdate Update, Guid id) => Ok(await _service.Update(Update, id));

    }
}
