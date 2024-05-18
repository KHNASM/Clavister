using ProtoBuf;

namespace Clavister.ToDo.Models.Models
{
    [ProtoContract]
    public class TaskModel
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Title { get; set; }

        [ProtoMember(3)]
        public string Description { get; set; }

        [ProtoMember(4)] public bool IsCompleted { get; set; }
    }
}
