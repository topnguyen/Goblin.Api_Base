using System.ComponentModel.DataAnnotations;
using Goblin.Core.Models;

namespace Goblin.Api_Base.Share.Models
{
    public class GoblinApi_BaseCreateSampleModel : GoblinApiSubmitRequestModel
    {
        [Required]
        public string SampleData { get; set; }
    }
}