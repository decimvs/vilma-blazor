using Microsoft.AspNetCore.Mvc;
using Vilma.Blazor.Common.FileUploader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vilma.Blazor.Components.FileUploader.LocalStorage.Server.Controllers
{
    [Route("api/vb/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UploadController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/<ValuesController>
        [HttpPost("Store")]
        public async Task<ActionResult<bool>> PostFile([FromForm] IEnumerable<IFormFile> files)
        {
            var clientName = Request.Headers.SingleOrDefault(s => s.Key == "ClientName");
            var paramSection = _configuration.GetSection($"{FileUploaderConstants.APPCONFIG_SERVER_MAIN_SECTION_NAME}:{clientName.Value}");
            ServerParameters serverParams = new ServerParameters();
            paramSection.Bind(serverParams);
            var basePath = serverParams.TemporalFilesPath;

            try
            {
                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);
            }
            catch { }

            foreach (var file in files)
            {
                try
                {
                    var newFileName = Path.GetRandomFileName();
                    var tempFilePath = Path.Combine(basePath, newFileName);

                    await using FileStream fs = new(tempFilePath, FileMode.CreateNew);
                    await file.CopyToAsync(fs);

                    
                }
                catch (Exception ex) { }
            }

            return Ok(true);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
