create Procedure sp_ProductAll

as
select a.Id,a.NamaProduct,a.DescriptionProduct,b.Harga from Product (nolock) a inner join ProductDetail b (nolock) on a.Id = b.ProductId
