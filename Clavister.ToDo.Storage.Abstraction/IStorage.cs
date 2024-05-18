namespace Clavister.ToDo.Storage.Abstraction
{
    public interface IStorage
    {
        Task<IEnumerable<T>> Load<T>(string filePath) where T : class;
        Task<bool> Save<T>(IEnumerable<T> items, string filePath) where T : class; 
    }
}
