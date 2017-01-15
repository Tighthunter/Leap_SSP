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
            var go = GameObject.Find("ConfigObject");
            if (go != null)
            {
                gameConfig = go.GetComponent<ConfigObject>().GetGameConfig();
            }
        }

        public GameConfig GetGameConfiguration()
        {
            return gameConfig ?? new GameConfig() {BestOfRounds = 3};
        }
    }
}
