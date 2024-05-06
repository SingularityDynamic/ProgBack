namespace ProgiBackend.Entities
{
    public class Sale
    {
        public decimal SalePrice { get; set; }

        public string VehicleType { get; set; }

        public decimal BasicFee { get; set; }

        public decimal SpecialFee { get; set; }

        public decimal AssociationFee { get; set; }

        public decimal StorageFee { get; set; }

        public decimal Total
        {
            get
            {
                return BasicFee + SpecialFee + AssociationFee + StorageFee + SalePrice;
            }
        }

        public Sale(string vehicleType, decimal salePrice)
        {
            SalePrice = salePrice;
            VehicleType = vehicleType;

            BasicFee = 0m;
            SpecialFee = 0m;
            AssociationFee = 0m;
            StorageFee = 0m;
        }
    }
}
