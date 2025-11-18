using AquaTrack.Models;
using System.Collections.Generic;

namespace AquaTrack.Services
{
    public interface IFishService
    {
        int CalculateFishAgeInMonths(Fish fish);
        bool IsFishTooBigForTank(Fish fish, Tank tank);
        IEnumerable<Fish> GetFishByTank(int tankId, IEnumerable<Fish> allFish);
    }
}
