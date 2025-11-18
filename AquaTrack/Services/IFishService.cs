using System.Collections.Generic;
using AquaTrack.Models;

namespace AquaTrack.Services
{
    public interface IFishService
    {
        int CalculateFishAgeInMonths(Fish fish);
        bool IsFishTooBigForTank(Fish fish, Tank tank);
        IEnumerable<Fish> GetFishByTank(int tankId, IEnumerable<Fish> allFish);
    }
}
