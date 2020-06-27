using System.ComponentModel.DataAnnotations;
using Goblin.Core.Models;

namespace Goblin.Api_Base.Share.Models
{
    public class GoblinApi_BaseCreateSampleModel : GoblinApiRequestModel
    {
        [Required]
        public string SampleData { get; set; }
    }
}