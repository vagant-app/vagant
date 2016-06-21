namespace Vagant.Domain.Entities
{
    public class FileData : BaseEntity
    {
        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}
