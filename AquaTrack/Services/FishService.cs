using System;
using System.Collections.Generic;
using System.Linq;
using AquaTrack.Models;

namespace AquaTrack.Services
{
    public class FishService : IFishService
    {
        public int CalculateFishAgeInMonths(Fish fish)
        {
            return fish.Age * 12;
        }

        public bool IsFishTooBigForTank(Fish fish, Tank tank)
        {
            return tank.VolumeInLiters < (fish.Age * 10);
        }

        public IEnumerable<Fish> GetFishByTank(int tankId, IEnumerable<Fish> allFish)
        {
            return allFish.Where(f => f.TankId == tankId);
        }
    }
}
