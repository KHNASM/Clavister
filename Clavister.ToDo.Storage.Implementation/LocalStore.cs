using Clavister.ToDo.DataWriter;
using Clavister.ToDo.Storage.Abstraction;

namespace Clavister.ToDo.Storage.Implementation
{
    public class LocalStore : IStorage

    {
        private readonly IDataSerializer _serializer;

        public LocalStore(IDataSerializer serializer)
        {
            _serializer = serializer;
        }
        public async Task<IEnumerable<T>> Load<T>(string filePath) where T : class
        {
            if(filePath is null) return Enumerable.Empty<T>();

            await using var file = File.OpenRead(filePath);
            return await _serializer.Deserialize<T>(file);
        }

        public async Task<bool> Save<T>(IEnumerable<T> items, string filePath) where T : class
        {
            if(items is null) return false;

            var data = await _serializer.Serialize(items);
            try
            {
                await File.WriteAllBytesAsync(filePath, data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
