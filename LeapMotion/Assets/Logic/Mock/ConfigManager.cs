using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using UnityEngine;

namespace Assets.Logic.Mock
{
    public class ConfigManager : IConfigManager
    {
        private GameConfig gameConfig;

        public ConfigManager()
        {
            gameConfig =GameObject.Find("ConfigObject").GetComponent<ConfigObject>().GetGameConfig();
        }

        public GameConfig GetGameConfiguration()
        {
            if (gameConfig == null)
            {
                return new GameConfig() {BestOfRounds = 3};
            }
            return gameConfig;
        }
    }
}
