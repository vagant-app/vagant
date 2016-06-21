namespace Vagant.Domain.Entities
{
    public class EventInstrument : BaseEntity
    {
        public bool IsGuitarUsed { get; set; }

        public bool IsViolinUsed { get; set; }

        public bool IsVocalApplicable { get; set; }

        public bool IsSaxophoneUsed { get; set; }
    }
}
