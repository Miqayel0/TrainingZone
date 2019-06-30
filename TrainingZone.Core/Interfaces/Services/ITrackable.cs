using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingZone.Core.Interfaces.Services
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        DateTime LastUpdatedAt { get; set; }
    }
}
