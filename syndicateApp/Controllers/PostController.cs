using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using syndicateApp.Models;
using System.Reflection.Metadata.Ecma335;

namespace syndicateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly TblPost _tblPost;
        public PostController(TblPost tblPost)
        {
            _tblPost = tblPost;
        }

      
    }
}
       
        

   