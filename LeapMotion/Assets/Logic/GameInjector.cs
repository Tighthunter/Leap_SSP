using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;
using Assets.Logic.Mock;
using UnityEngine;

namespace Assets.Logic
{
    public class GameInjector : MonoBehaviour
    {
        private GameInjector _instance;

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
        }

        public IConfigManager GetConfigManager()
        {
            //TODO: martin bitte hier die config laden und einen manager zurückgeben
            return new MockConfigManager();
        }
    }
}
