﻿using Model.Entity;

namespace BAL.Interfaces
{
    public interface ISandboxManager
    {
        ExecutionResult Execute(string code);
    }
}
