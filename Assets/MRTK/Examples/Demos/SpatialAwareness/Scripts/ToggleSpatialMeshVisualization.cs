// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{
    /// <summary>
    /// This class controls the visualization of the spatial mesh.
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/Examples/ToggleSpatialMeshVisualization")]
    public class ToggleSpatialMeshVisualization : MonoBehaviour
    {
        /// <summary>
        /// Toggles the state of the mesh display option.
        /// </summary>
        public void ToggleSpatialMeshVisual(int mode)
        {
            // Get the first Mesh Observer available, generally we have only one registered
            var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();

            switch(mode)
            {
                case 0:
                    // Spatial mesh is not visible, holograms are not occluded by spatial mesh
                    observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.None;
                    break;
                case 1:
                    // Spatial mesh is visible, holograms are occluded by spatial mesh
                    observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Visible;
                    break;
                case 2:
                    // Spatial mesh is not visible, holograms are occluded by spatial mesh
                    observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Occlusion;
                    break;
            }
        }
    }
}