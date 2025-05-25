using PT2.data;
using PT2.data.API;

namespace Data.API
{
    public static class DataServiceFactory
    {
        private static readonly Lazy<IDataService> _instance =
            new Lazy<IDataService>(() => new DbDataService());

        public static IDataService Instance => _instance.Value;
    }
}