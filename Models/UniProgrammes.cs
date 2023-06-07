using System;
using System.Collections.Generic;

namespace uniPlanner.Models;

public partial class UniProgrammes
{
    public int UniProgrammeId { get; set; }

    public int UniversityId { get; set; }

    public int ProgrammeId { get; set; }

    public int? RankScore { get; set; }

    public string Link { get; set; } = null!;

    public virtual ICollection<MajorsOffered> MajorsOffereds { get; set; } = new List<MajorsOffered>();

    public virtual Programmes Programme { get; set; } = null!;

    public virtual UniversityInfo University { get; set; } = null!;
}
