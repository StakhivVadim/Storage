namespace Storage.Items
{
    public class Box : Item
    {
        public override double Weight { get; }
        public DateTime? ProductionDate { get; }
        public DateTime? ExpirationOverride { get; }
       
        public override DateTime ExpirationDate
        {
            get
            {
                if (ExpirationOverride.HasValue) 
                {
                    return ExpirationOverride.Value;
                }
                else if (ProductionDate.HasValue)
                {
                    return ProductionDate.Value.AddDays(100);
                }
                throw new InvalidOperationException("Ошибка: У коробки должен быть срок годности или дата изготовления.");
            }
        }

        public override double Volume => Width * Height * Depth;

        public Box(Guid id, double width, double height, double depth, double weight, DateTime? productionDate = null, DateTime? expirationOverride = null): base(id, width, height, depth)
        {
            if (productionDate == null && expirationOverride == null)
            {
                throw new ArgumentException("Ошибка: У коробки должен быть срок годности или дата изготовления.");
            }

            Weight = weight;
            ProductionDate = productionDate;
            ExpirationOverride = expirationOverride;
        }
    }
}
