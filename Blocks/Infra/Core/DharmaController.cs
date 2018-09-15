using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Dharma.Core
{
    /// <inheritdoc />
    /// <summary>
    /// Base class for controllers used on the project. To avoid repeating code and introducing possible bugs
    /// </summary>
    public class DharmaController : ControllerBase
    {
        /// <summary>
        /// Method to handle default steps to make a get request
        /// </summary>
        /// <param name="models">Result of some implementation</param>
        /// <param name="T">Model that inherits from BaseModel</param>
        /// <returns>A proper IActionResult</returns>
        protected IActionResult GenericGet<T>(IEnumerable<T> models) where T : BaseViewModel
        {
            if (!models.Any())
                return Ok();

            if (!models.All(t => t.IsValid()))
                return BadRequest(models.First().ListAllErrors());
            
            return Ok(models);
        }
    }
}