using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Data;
using UserAPI.Abstractions;
using UserAPI.DTOs;
using UserAPI.Entities;
using UserAPI.Models;
namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usService;
        private readonly ILogger<UserController> _logger;
        //private readonly ILogger _logger1;
        public UserController(IUserService usService, ILogger<UserController> logger)
        {
            _usService = usService;
            _logger = logger;
        }
        [HttpGet("Get")]
        public ResponseModel<IEnumerable<User>> Get()
        {
            _logger.LogInformation("Seri Log is working");
            var data = _usService.Get();
            return data;
        }
        [HttpPost("Post")]
        public ResponseModel<User> Post([FromBody] UserDTO model)
        {
            _logger.LogInformation("Seri Log is working");
            var data = _usService.Post(model);
            return data;
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public ResponseModel<User> Delete([FromRoute] int id)
        {
            _logger.LogInformation("Seri Log is working");
            var data = _usService.Delete(id);
            return data;
        }
        [HttpPut]
        [Route("Put/{id}")]
        public ResponseModel<User> Put([FromRoute] int id, UserDTO model)
        {
            _logger.LogInformation("Seri Log is working");
            var data = _usService.Update(id, model);
            return data;
        }
        [HttpGet("GetById")]
        public ResponseModel<User> GetById([FromQuery] int id)
        {
            _logger.LogInformation("Seri Log is working");
            ResponseModel<User> rm = new ResponseModel<User>();
            try
            {
                var data = _usService.GetById(id);
                rm.Data = data;
            }
            catch(Exception ex)
            {
                rm.Success = false;
                rm.ErrorMessage = ex.Message;
            }
            return rm;
        }
        //[HttpGet("GetFile")]
        //public ActionResult GetFile(string fileName)
        //{
        //    var a = Directory.GetCurrentDirectory();
        //    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", fileName);
        //    var provider = new FileExtensionContentTypeProvider();
        //    if(!provider.TryGetContentType(filepath, out var contentType))
        //    {
        //        contentType = "application/octet-stream";
        //    }
        //    var bytes = System.IO.File.ReadAllBytes(filepath);
        //    return File(bytes,contentType,Path.GetFileName(filepath));
        //}
        //[HttpPost("PostFile")]
        //public ActionResult PostFile(IFormFile uploadedFile)
        //{
        //    //var saveFolderPath = @"C:\Users\User\Desktop\salam";
        //    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");
        //    if(!Directory.Exists(filepath))
        //    {
        //        Directory.CreateDirectory(filepath);
        //    }
        //    var exactPath=Path.Combine(Directory.GetCurrentDirectory(),"Upload\\Files",uploadedFile.FileName);
        //    //FileInfo file = new FileInfo(uploadedFile.FileName);
        //    using (var stream = new FileStream(exactPath, FileMode.Create))
        //    {
        //        uploadedFile.CopyTo(stream);
        //    }
        //    return Ok(uploadedFile.Name);
        //} 
    }
}
