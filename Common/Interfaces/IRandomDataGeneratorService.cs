using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IRandomDataGeneratorService
    {
        int CreateRandomNumber(int min = 0, int max = int.MaxValue);
    }
}
