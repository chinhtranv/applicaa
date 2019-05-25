using SIMS.Entities;

namespace SIMSInterface
{
    public class CacheMessage
    {
        public UserMessageEventEnum Type { get; set; }
        public string Messages { get; set; }
    }
}