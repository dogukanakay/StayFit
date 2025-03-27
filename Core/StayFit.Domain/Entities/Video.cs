using StayFit.Domain.Entities.Common;
using StayFit.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayFit.Domain.Entities
{
    public class Video : BaseEntity<int>
    {
        public string Title { get; set; }
        public VideoPlatforms VideoPlatform { get; set; }
        public VideoTypes VideoType { get; set; }
        public string Url { get; set; }
        public int Priority { get; set; }


        [NotMapped]
        public override DateTime? UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }
    }
}
