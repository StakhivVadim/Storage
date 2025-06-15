using Storage.Items;

namespace Storage.DataGenerator
{
    public interface IPalletDataGenerator
    {
        List<Pallet> GeneratePallets(int count);
    }
}
