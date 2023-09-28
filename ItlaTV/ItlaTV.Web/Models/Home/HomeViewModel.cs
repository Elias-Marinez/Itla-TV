using ItlaTV.Web.Models.Productora;
using ItlaTV.Web.Models.Serie;

namespace ItlaTV.Web.Models.Home
{
    public class HomeViewModel
    {
        public IEnumerable<SerieViewModel>? Series { get; set; }
        public IEnumerable<ProductoraViewModel>? Productoras { get; set; }
    }
}
