
namespace Shp.Business.Constants
{
    public static class Messages<T>
    {
        public static string EntityInserted = $"{typeof(T).Name} is inserted successfully.";
        public static string EntityUpdated = $"{typeof(T).Name} is updated successfully.";
        public static string EntityDeleted = $"{typeof(T).Name} is deleted successfully.";
    }
}
