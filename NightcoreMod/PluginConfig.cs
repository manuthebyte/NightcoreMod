using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace NightcoreMod
{
    internal class PluginConfig
    {
        public virtual bool EnableNightcore { get; set; } = true;
        public virtual bool EnableDaycore { get; set; } = true;
        public virtual bool PreviewPitch { get; set; } = false;
    }
}