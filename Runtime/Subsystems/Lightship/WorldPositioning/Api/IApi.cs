// Copyright 2023-2024 Niantic.

using System;
using UnityEngine;
using Niantic.Experimental.Lightship.AR.XRSubsystems;

namespace Niantic.Experimental.Lightship.AR.Subsystems.WorldPositioning
{
    internal interface IApi
    {
        public IntPtr Construct(IntPtr unityContext);

        public void Start(IntPtr providerHandle);

        public void Stop(IntPtr providerHandle);

        public void Configure(IntPtr providerHandle);

        public void Destruct(IntPtr providerHandle);

        public WorldPositioningStatus TryGetXRToWorld(IntPtr providerHandle, out Matrix4x4 arToWorld, out double originLatitude, out double originLongitude, out double originAltitude);

    }
}
