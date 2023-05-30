﻿using DraftInsights.NHLApi.Models;

namespace DraftInsights.Core.Models;

public record DraftPosition(int Position, int InitialPosition, TeamRecord TeamRecord)
{
    public int PositionDifference => (Position * -1) + InitialPosition;
}
