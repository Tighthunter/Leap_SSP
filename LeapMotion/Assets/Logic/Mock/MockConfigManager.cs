using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;

namespace Assets.Logic.Mock
{
    public class MockConfigManager : IConfigManager
    {
        public GameConfig GetGameConfiguration()
        {
            return new GameConfig() {BestOfRounds = 3};
        }
    }
}
