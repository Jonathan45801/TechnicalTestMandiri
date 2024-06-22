using Product.Application.Mapster;
using Product.Domain.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Application.Model.Query;

namespace Product.Application.UseCases.Queries.Product
{
    public record ProductAllDto : BaseDto
    {
        public ProductAllData Data { get; set; }
    }
    public class ProductAllData: MapsterBase<ProductAll,ProductAllData>
    {
        public int Id { get; set; }
        public string? NamaProduct { get; set; }
        public string? DescriptionProduct { get; set; }
        public int Harga { get; set; }
        public string? HargaConvert { get; set; }
        public override void AddCustomMappings()
        {
            SetCustomMappings()
                .Map(x => x.Id, src => src.Id)
                .Map(x => x.NamaProduct, src => src.NamaProduct)
                .Map(x => x.DescriptionProduct, src => src.DescriptionProduct)
                .Map(x => x.Harga, src => src.Harga)
                .Map(x => x.HargaConvert, src => String.Format("{0:##.0##}", src.Harga));
        }
    }
}
