using System.Reflection;
using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Utilities;
using SiraUtil.Zenject;
using UnityEngine;
using IpaLogger = IPA.Logging.Logger;

namespace NightcoreMod
{
    [Plugin(RuntimeOptions.SingleStartInit)] 
    public class Plugin
    {
        internal static PluginConfig Config { get; private set; } = null!;
        
        internal static IpaLogger Log { get; private set; } = null!;
        private Harmony _harmony;

        [Init]
        public Plugin(IpaLogger logger, Config conf, Zenjector zenjector)
        {
            Log = logger;
            _harmony = new Harmony("com.manubyte.nightcoremod");
            
            Config = conf.Generated<PluginConfig>();
            zenjector.Install<AppInstaller>(Location.App, Config);
            zenjector.Install<MenuInstaller>(Location.Menu);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            _harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            _harmony.UnpatchSelf();
        }
    }
    
    [HarmonyPatch(typeof(AudioTimeSyncController), "Update")]
    class AudioTimeSyncControllerUpdatePatch
    {
        static void Postfix(AudioTimeSyncController __instance)
        {
            var audioSource = __instance.GetField<AudioSource, AudioTimeSyncController>("_audioSource");
            if (audioSource != null)
            {
                if (Plugin.Config.EnableNightcore && __instance.timeScale > 1f) {
                    audioSource.outputAudioMixerGroup = null;
                    audioSource.pitch = __instance.timeScale;
                }
                else if (Plugin.Config.EnableDaycore && __instance.timeScale < 1f) {
                    audioSource.outputAudioMixerGroup = null;
                    audioSource.pitch = __instance.timeScale;
                }
            }
        }
    }
}
