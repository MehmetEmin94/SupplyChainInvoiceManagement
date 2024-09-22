namespace Supplier.API.Dtos
{
    public class SupplierRegisterDto
    {
        public string TaxId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
    }
}
