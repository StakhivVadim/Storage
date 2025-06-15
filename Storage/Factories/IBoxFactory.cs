using Storage.Items;

namespace Storage.Factories
{
    public interface IBoxFactory
    {
        Box CreateRandomBox(double maxWidth, double maxHeight, double maxDepth);
    }
}
