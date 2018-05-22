using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Controllers.Resources
{
    public class MakeResource
    {
        public int Id { get; set; }
        // [Required]
        // [StringLength(255)]
        public string Name { get; set; }

        public ICollection<ModelResource> Models {get; set;}
        
        public MakeResource()
        {
            Models = new Collection<ModelResource>();
        }        
    }
}