// Copyright 2023-2024 Niantic.

using System.Collections.Generic;
using Niantic.Experimental.Lightship.AR.Loader;
using UnityEngine;
using UnityEditor;
using UnityEditor.XR.Management.Metadata;

namespace Niantic.Experimental.Lightship.AR.WorldPositioning.Editor
{
    class XRPackage : IXRPackage
    {
        private class LightshipLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName { get; set; }
            public string loaderType { get; set; }
            public List<BuildTargetGroup> supportedBuildTargets { get; set; }
        }

        private class LightshipWorldPositioningPackageMetadata : IXRPackageMetadata
        {
            public string packageName { get; set; }
            public string packageId { get; set; }
            public string settingsType { get; set; }
            public List<IXRLoaderMetadata> loaderMetadata { get; set; }
        }

        private static IXRPackageMetadata s_Metadata = new LightshipWorldPositioningPackageMetadata()
        {
            packageName = LightshipWorldPositioningPackageInfo.displayName,
            packageId = LightshipWorldPositioningPackageInfo.identifier,
            settingsType = typeof(LightshipWorldPositioningSettings).FullName,
            loaderMetadata = new List<IXRLoaderMetadata>() {}
        };

        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj)
        {
            try
            {
                EditorBuildSettings.AddConfigObject(LightshipWorldPositioningSettings.SettingsKey, obj, true);
                return true;
            }
            catch (System.Exception ex)
            {
                Debug.Log($"Error adding new Lightship Settings object to build settings.\n{ex.Message}");
            }

            return false;
        }
    }
}
