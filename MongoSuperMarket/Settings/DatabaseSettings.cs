namespace MongoSuperMarket.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string SellingCollectionName { get; set; }
        //public string GetCollectionName(string entityName)
        //{
        //    switch (entityName)
        //    {
        //        case "Category":
        //            return CategoryCollectionName;
        //        case "Discount":
        //            return DiscountCollectionName;
        //        case "Feature":
        //            return FeatureCollectionName;
        //        case "Product":
        //            return ProductCollectionName;
        //        case "Selling":
        //            return SellingCollectionName;
        //        default:
        //            throw new ArgumentException("Geçersiz entity ismi.");

        //    }
        //}
    }
}