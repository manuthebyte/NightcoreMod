using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using Zenject;

namespace NightcoreMod
{
    [HotReload]
    [ViewDefinition("NightcoreMod.SettingsView.bsml")]
    internal class SettingsViewController : BSMLAutomaticViewController
    {
        internal static SettingsViewController Instance { get; private set; } = null!;

        [Inject]
        private void Construct()
        {
            Instance = this;
        }

        [Inject] private PluginConfig _config = null!;

        private bool EnableNightcore
        {
            get => _config.EnableNightcore;
            set => _config.EnableNightcore = value;
        }

        private bool EnableDaycore
        {
            get => _config.EnableDaycore;
            set => _config.EnableDaycore = value;
        }

        private bool PreviewPitch
        {
            get => _config.PreviewPitch;
            set => _config.PreviewPitch = value;
        }
    }
}