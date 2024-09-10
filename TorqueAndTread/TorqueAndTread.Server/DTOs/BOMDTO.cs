using System.ComponentModel.DataAnnotations.Schema;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class BOMDTO
    {
        public int BOMId { get; set; }
        public string BOMName { get; set; }
        public Nullable<int> MaterialId { get; set; }
        public string BOMCode { get; set; }
        public bool Active { get; set; }
        public string MaterialCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public BOMDTO(){}
        public BOMDTO(BOM bom)
        {
            BOMId = bom.BOMId;
            MaterialId = bom.MaterialId;
            BOMName = bom.BOMName;
            BOMCode = bom.BOMCode;
            Active = bom.Active;
            CreatedOn = bom.CreatedOn;
            LastUpdatedOn = bom.LastUpdatedOn;
            if (bom.MaterialId != null) { MaterialCode = bom.Material.ProductCodeName; }
        }
    }
}
