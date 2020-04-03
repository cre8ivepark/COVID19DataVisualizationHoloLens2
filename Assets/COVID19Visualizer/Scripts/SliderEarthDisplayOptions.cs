//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class SliderEarthDisplayOptions : MonoBehaviour
{
    [SerializeField]
    private EarthRenderer TargetRenderer;

    public void OnSliderUpdatedSaturation(SliderEventData eventData)
    {
        if ((TargetRenderer != null))
        {
            TargetRenderer.colorSaturation = eventData.NewValue;
        }
    }

    public void OnSliderUpdatedCloudOpacity(SliderEventData eventData)
    {
        if ((TargetRenderer != null))
        {
            TargetRenderer.cloudColor = new Color(TargetRenderer.cloudColor.r, TargetRenderer.cloudColor.g, TargetRenderer.cloudColor.b, eventData.NewValue);
        }
    }

    public void OnSliderUpdatedSeaColor(SliderEventData eventData)
    {
        if ((TargetRenderer != null))
        {
            TargetRenderer.seaColor = new Color(TargetRenderer.seaColor.r, TargetRenderer.seaColor.g, TargetRenderer.seaColor.b, eventData.NewValue);
        }
    }

}
