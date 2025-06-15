namespace Storage.Items
{
    public class Pallet : Item
    {
        private const double PALLET_OWN_WEIGHT = 30.0;

        private readonly List<Box> _boxes = new();
        public IReadOnlyList<Box> Boxes => _boxes;

        public override double Weight =>
            _boxes.Sum(b => b.Weight) + PALLET_OWN_WEIGHT;

        public override double Volume =>
            Width * Height * Depth + _boxes.Sum(b => b.Volume);

        public override DateTime ExpirationDate
        {
            get
            {
                if (_boxes.Any())
                {
                    return _boxes.Min(b => b.ExpirationDate);
                }
                else
                {
                    return DateTime.MaxValue;
                }
            }
        }

        public Pallet(Guid id, double width, double height, double depth, IEnumerable<Box>? boxes = null): base(id, width, height, depth)
        {
            if (boxes != null)
            {
                foreach (var box in boxes)
                {
                    AddBox(box);
                }
            }
        }

        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Depth > Depth)
            {
                throw new ArgumentException("Коробка не поместится на палете");
            }

            _boxes.Add(box);
        }
    }
}
