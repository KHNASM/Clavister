namespace Clavister.ToDo.DataWriter;

public interface IDataSerializer
{
    Task<byte[]> Serialize<T>(T data);
    Task<IEnumerable<T>> Deserialize<T>(Stream data);
}