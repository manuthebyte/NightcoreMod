using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace NightcoreMod
{
    internal class SettingsMenuRegistrar : IInitializable
    {
        private readonly SettingsViewController _view;

        public SettingsMenuRegistrar(SettingsViewController view)
        {
            _view = view;
        }

        public void Initialize()
        {
            BSMLSettings.Instance.AddSettingsMenu("Nightcore", "NightcoreMod.SettingsView.bsml", _view);
        }
    }
}