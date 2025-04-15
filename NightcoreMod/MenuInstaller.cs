using NightcoreMod;
using Zenject;

namespace NightcoreMod
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<SettingsViewController>()
                .FromNewComponentAsViewController()
                .AsSingle();

            Container.BindInterfacesTo<SettingsMenuRegistrar>().AsSingle();
        }
    }
}