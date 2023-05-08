using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Miquella_BackEnd.DataAccesLayer;

namespace Miquella_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        Context ct=new Context();

        [HttpGet]
        public IActionResult GetList()
        {
            var getlist= ct.News.ToList();
            return Ok(getlist);
        }
        [HttpPost]
        public IActionResult AddNews(New news)
        {
           var addnews= ct.News.Add(news);
            ct.SaveChanges();
            return Ok(addnews);
        }

        [HttpDelete("{id}")]
        public IActionResult NewsDelete(int id)
        {
            var deletenews=ct.News.Find(id);
            ct.Remove(deletenews);
            ct.SaveChanges();
            return Ok(deletenews);  
        }


        [HttpPut]
        public IActionResult NewsUpdate(New news)
        {
            var emp=ct.Find<New>(news.ID);
            if (emp==null)
            {
                return NotFound();
            }
            else
            {
                emp.Newstitle = news.Newstitle;
                ct.Update(emp);
                ct.SaveChanges();
                return Ok();
            }
        }
    }
}
