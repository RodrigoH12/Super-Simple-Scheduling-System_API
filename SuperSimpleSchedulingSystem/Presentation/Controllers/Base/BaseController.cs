using Microsoft.AspNetCore.Mvc;
using SuperSimpleSchedulingSystem.Logic.Managers.Base;
using SuperSimpleSchedulingSystem.Presentation.Middleware;

namespace SuperSimpleSchedulingSystem.Presentation.Controllers.Base
{
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IGenericManager<T> _classManager;

        public BaseController(IGenericManager<T> ClassManager)
        {
            _classManager = ClassManager;
        }

        /// <summary>
        /// Returns all Items according to the endpoint.
        /// </summary>
        /// <response code="200">Success or some expected Error</response>
        [HttpGet]
        public virtual async Task<IActionResult> GetAllItems()
        {
            return Ok(new MiddlewareResponse<IEnumerable<T>>(await _classManager.GetAll()));
        }

        /// <summary>
        /// Returns specific Item from the id provided.
        /// </summary>
        /// <param name="id">Id of the specific Item</param>
        /// <response code="200">Success or some expected Error</response>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemById([FromRoute] Guid id)
        {
            T response = await _classManager.GetById(id);
            return Ok(new MiddlewareResponse<T>(response));
        }

        /// <summary>
        /// Creates an Item.
        /// </summary>
        /// <remarks>
        /// When creating the request body you can ignore the value of the Id parameter, it will be generated automatically.
        /// </remarks>
        /// <response code="200">Success or some expected Error</response>
        [HttpPost]
        [Route("")]
        public virtual async Task<IActionResult> Create([FromBody] T itemDto)
        {
            T response = await _classManager.Create(itemDto);
            return Ok(new MiddlewareResponse<T>(response));
        }

        /// <summary>
        /// Updates the Item of the provided id.
        /// </summary>
        /// <param name="id">Id of the Item</param>
        /// <response code="200">Success or some expected Error</response>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] T itemDto)
        {
            T response = await _classManager.Update(id, itemDto);
            return Ok(new MiddlewareResponse<T>(response));
        }

        /// <summary>
        /// Deletes the Item of the provided id.
        /// </summary>
        /// <param name="id">Id of the item</param>
        /// <response code="200">Success or some expected Error</response>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            return Ok(new MiddlewareResponse<bool>(await _classManager.Delete(id)));
        }
    }
}
