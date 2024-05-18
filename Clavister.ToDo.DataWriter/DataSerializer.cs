using ProtoBuf;

namespace Clavister.ToDo.DataWriter
{
    public class DataSerializer : IDataSerializer
    {
        public async Task<byte[]> Serialize<T>(T data)
        {
            return await Task.Run(() =>
            {
                using var stream = new MemoryStream();
                Serializer.Serialize(stream, data);
                return stream.ToArray();
            });
        }

        public async Task<IEnumerable<T>> Deserialize<T>(Stream data)
        {
            return await Task.Run(() => Serializer.Deserialize<IEnumerable<T>>(data)); 
        }
    }
}
