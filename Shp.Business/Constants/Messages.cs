
namespace Shp.Business.Constants
{
    public static class Messages<T>
    {
        public static string EntityInserted = $"{typeof(T).Name}'s inserted successfully.";
        public static string EntityUpdated = $"{typeof(T).Name}'s updated successfully.";
        public static string EntityDeleted = $"{typeof(T).Name}'s deleted successfully.";
        public static string EntityNotFound = $"{typeof(T).Name} not found.";
    }
}
