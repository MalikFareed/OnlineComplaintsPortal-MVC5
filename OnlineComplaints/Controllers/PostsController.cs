using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace OnlineComplaints.Controllers
{
    [Filters.Admin]
    public class PostsController : Controller
    {
        public ActionResult AllPosts()
        {
            BL_Posts bL_Posts = new BL_Posts();
            List<Post> posts_List = bL_Posts.Posts.ToList();

            return View(posts_List);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                BL_Posts bL_Posts = new BL_Posts();
                bL_Posts.InsertPost(post);

                return RedirectToAction("AllPosts");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            BL_Posts bL_Posts = new BL_Posts();
            bL_Posts.DeletePost(id);

            return RedirectToAction("AllPosts");
        }
    }
}