using GetAllBooksAPI;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using BookOwnnerService;
//using GetAllBooksAPI.DatasetHelper;
//using BookOwner;
using System.Data;
using Newtonsoft.Json;


namespace BookOwnersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookOwnnerService _bookOwnerService;

        public BooksController(BookOwnnerService bookOwnerService)
        {
            _bookOwnerService = bookOwnerService;
        }

        [HttpGet]
        [Route("GetDataSet")]
        public async Task<IActionResult> GetDataSetAsync()
        {
            try
            {
                var bookOwners = await _bookOwnerService.GetBookOwnersAsync();
                var dataSet = DataSetHelper.ConvertToDataSet(bookOwners);

                // Convert the DataSet to JSON
                var jsonResult = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

                // Return as JSON
                return Content(jsonResult, "application/json");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
