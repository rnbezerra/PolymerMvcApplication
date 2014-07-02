using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PostController : Controller
    {
        private static List<PostView> list = null   ;

        //
        // GET: /Post/

        public string Index()
        {
            return "Hello";
        }

        [HttpGet]
        public JsonResult PostById(string id)
        {
            return Json(new PostDTO(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult All()
        {
            if (list == null)
            {
                string json = System.IO.File.ReadAllText(@"C:\GitHub\PolymerMvcApplication\src\Web\api\posts.json");

                list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PostView>>(json);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void FavoritePost(string id)
        {
            PostView post = list.FirstOrDefault(p => p.uid.ToString() == id);

            if (post != null)
            {
                post.favorite = !post.favorite;
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            System.IO.File.WriteAllText(@"C:\GitHub\PolymerMvcApplication\src\Web\api\posts.json", json);
        }
    }
}
