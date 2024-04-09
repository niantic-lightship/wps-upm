// Copyright 2023-2024 Niantic.

using UnityEngine;
using UnityEngine.XR.Management;
using System;
using System.IO;
using UnityEditor;

namespace Niantic.Experimental.Lightship.AR.Loader
{
    [Serializable]
    [XRConfigurationData("Niantic Lightship World Positioning", SettingsKey)]
    public class LightshipWorldPositioningSettings : ScriptableObject
    {
        private const string AssetsPath = "Assets";
        private const string AssetsRelativeSettingsPath = "XR/Settings";
        public const string SettingsKey = "Niantic.Lightship.AR.WorldPositioningSettings";

        [SerializeField, Tooltip("When enabled, Lightship's World Positioning System (WPS) feature can be used")]
        private bool _useLightshipWorldPositioning = true;
        public bool UseLightshipWorldPositioning => _useLightshipWorldPositioning;

#if !UNITY_EDITOR
        /// <summary>
        /// Static instance that will hold the runtime asset instance we created in our build process.
        /// </summary>
        private static LightshipWorldPositioningSettings s_RuntimeInstance;
#endif

        private void Awake()
        {
#if !UNITY_EDITOR
            s_RuntimeInstance = this;
#endif
        }

        /// <summary>
        /// Accessor to Lightship world space settings.
        /// </summary>
        public static LightshipWorldPositioningSettings Instance => GetOrCreateInstance();

        private static LightshipWorldPositioningSettings GetOrCreateInstance()
        {
            LightshipWorldPositioningSettings settings = null;

#if UNITY_EDITOR
            if (!EditorBuildSettings.TryGetConfigObject(SettingsKey, out settings))
            {
                Debug.Log("No LightshipWorldPositioningSettings.Instance found, creating new one.");
                settings = CreateInstanceAsset();

            }
#else
            settings = s_RuntimeInstance;
            if (settings == null)
                settings = CreateInstance<LightshipWorldPositioningSettings>();
#endif
            return settings;
        }

#if UNITY_EDITOR
        private static LightshipWorldPositioningSettings CreateInstanceAsset()
        {
            // ensure all parent directories of settings asset exists
            var settingsPath = Path.Combine(AssetsPath, AssetsRelativeSettingsPath, "Lightship WPS Settings.asset");
            var pathSplits = settingsPath.Split("/");
            var runningPath = pathSplits[0];
            for (var i = 1; i < pathSplits.Length - 1; i++)
            {
                var pathSplit = pathSplits[i];
                var nextPath = Path.Combine(runningPath, pathSplit);
                if (!AssetDatabase.IsValidFolder(nextPath))
                {
                    AssetDatabase.CreateFolder(runningPath, pathSplit);
                }

                runningPath = nextPath;
            }

            // create settings asset at specified path
            var settings = CreateInstance<LightshipWorldPositioningSettings>();
            AssetDatabase.CreateAsset(settings, settingsPath);

            EditorBuildSettings.AddConfigObject(SettingsKey, settings, true);

            return settings;
        }
#endif
    }

}
