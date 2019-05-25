using SIMS.Entities;

namespace SIMSInterface
{
    public enum Status
    {
        Failed,
        Success
    }

    public enum EntityType
    {
        Applicant,
        ExternalExamination
    }

    public class SimsResult
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public ValidationErrors Errors { get; set; }
        public int InsertedEntityId { get; set; }
    }

    public class CreateEntityResult
    {
        public EntityType Type { get; set; }
        public string EntityName { get; set; }
        public SimsResult SimsResult { get; set; }
    }
}