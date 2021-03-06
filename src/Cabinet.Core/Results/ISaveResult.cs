﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Core.Results {
    public interface ISaveResult : IFileOperationResult {
        string Key { get; }
        bool AlreadyExists { get; }
    }
}
