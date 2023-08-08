namespace BookShop
{
    using BookShop.Initializer;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }
    }
}
