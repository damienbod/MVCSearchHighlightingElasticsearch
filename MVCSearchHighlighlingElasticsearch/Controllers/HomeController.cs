using System.Linq;
using System.Web.Mvc;
using MVCSearchHighlighlingElasticsearch.ElasticsearchProvider;
using MVCSearchHighlighlingElasticsearch.Models;

namespace MVCSearchHighlighlingElasticsearch.Controllers
{
	public class HomeController : Controller
	{
		readonly SearchProvider _searchProvider = new SearchProvider();
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult Search(string term)
		{
			var searchResults = new SearchResults { Results = _searchProvider.Search(term).ToList() };
			return Json(searchResults.Results, "highlights", JsonRequestBehavior.AllowGet);
		}
	}
}