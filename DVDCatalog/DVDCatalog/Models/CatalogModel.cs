using DVDCatalog.DAOs;

namespace DVDCatalog.Models
{
    public class CatalogModel
    {
        public CatalogModel()
        { 
            Catalog = new List<MovieDAO>();
        }
        
        public CatalogModel(List<MovieDAO> catalog)
        {
            Catalog = catalog;
        }

        public List<MovieDAO> Catalog { get; set; }
    }
}
