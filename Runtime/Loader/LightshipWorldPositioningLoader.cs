// Copyright 2023-2024 Niantic.

using System.Collections.Generic;
using Niantic.Lightship.AR.Loader;
using Niantic.Experimental.Lightship.AR.XRSubsystems;

namespace Niantic.Experimental.Lightship.AR.Loader
{
    public class LightshipWorldPositioningLoader : ILightshipExternalLoader
    {
        static List<XRWorldPositioningSubsystemDescriptor> s_WorldPositioningSubsystemDescriptors = new ();

        /// <summary>
        /// Initializes the loader.
        /// </summary>
        /// <returns>`True` if the session subsystems were successfully created, otherwise `false`.</returns>
        bool ILightshipExternalLoader.Initialize(ILightshipLoader loader)
        {
            var wpsSettings = LightshipWorldPositioningSettings.Instance;

            if (wpsSettings.UseLightshipWorldPositioning)
            {
                loader.CreateSubsystem<XRWorldPositioningSubsystemDescriptor, XRWorldPositioningSubsystem>(s_WorldPositioningSubsystemDescriptors, "Lightship-WorldPositioning");
            }

            return true;
        }
        /// <summary>
        /// Destroys each subsystem.
        /// </summary>
        /// <returns>Always returns `true`.</returns>
        void ILightshipExternalLoader.Deinitialize(ILightshipLoader loader)
        {
            loader.DestroySubsystem<XRWorldPositioningSubsystem>();
        }
    }
}
