﻿using Zenject;

namespace NightcoreMod
{
    internal class AppInstaller : Installer
    {
        private readonly PluginConfig _config;

        public AppInstaller(PluginConfig config)
        {
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();

            Container.BindInterfacesTo<AudioTimeSyncController>().AsSingle();
        }
    }
}