namespace Storage.Items
{
    public abstract class Item
    {
        public Guid Id { get; }
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }

        public abstract double Weight { get; }
        public abstract double Volume { get; }
        public abstract DateTime ExpirationDate { get; }

        protected Item(Guid id, double width, double height, double depth)
        {
            Id = id;
            Width = width;
            Height = height;
            Depth = depth;
        }
    }
}
