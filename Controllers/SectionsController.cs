<<<<<<< HEAD
using EvaluationBackend.DATA.DTOs.Section;
=======
using EvaluationBackend.DATA.DTOs.Sections;
>>>>>>> 6c75216 (Initial commit)
using EvaluationBackend.Services;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers
{

    public class SectionsController : BaseController
    {

        private readonly ISectionsService _service;

        public SectionsController(ISectionsService service)
        {
            _service = service;
        }

<<<<<<< HEAD
        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
=======
        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
>>>>>>> 6c75216 (Initial commit)
        [HttpGet]
        public async Task<ActionResult<Respons<SectionDto>>> GetAll([FromQuery] SectionFilter filter) => Ok(await _service.GetAll(filter), filter.PageNumber);


<<<<<<< HEAD
        // [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
=======
        [Authorize(Roles = "Publisher,Admin,SuperAdmin")]
>>>>>>> 6c75216 (Initial commit)
        [HttpPost]
        public async Task<ActionResult<SectionDto>> Add([FromBody] SectionForm form) => Ok(await _service.Add(form));



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
        public async Task<ActionResult> Update(SectionUpdate Update, Guid id) => Ok(await _service.Update(Update, id));

    }
}
