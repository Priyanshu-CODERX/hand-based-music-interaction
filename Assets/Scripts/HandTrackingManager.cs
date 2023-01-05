using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Niantic.ARDK.AR.Awareness;
using ARDK.Extensions;

public class HandTrackingManager : MonoBehaviour
{
    [SerializeField] ARHandTrackingManager _handTrackingManager;
    [SerializeField] Camera ARCamera;
    [SerializeField] float accuracyLevel = 0.90f;

    private Vector3 handPositionVector;
    public Vector3 HandPositionVector { get => handPositionVector; }

    private void Start()
    {
        _handTrackingManager.HandTrackingUpdated += UpdateTrackingData;
    }

    private void OnDestroy()
    {
        _handTrackingManager.HandTrackingUpdated -= UpdateTrackingData;
    }

    private void UpdateTrackingData(HumanTrackingArgs updatedData)
    {
        var trackingInfo = updatedData.TrackingData?.AlignedDetections;
        if (trackingInfo == null)
        {
            return;
        }
        foreach (var latestDataSet in trackingInfo)
        {
            if (latestDataSet.Confidence < accuracyLevel)
            {
                return;
            }

            Vector3 trackingFrameSize = new Vector3(latestDataSet.Rect.width, latestDataSet.Rect.height, 0);
            float depthEstimation = 0.2f + Mathf.Abs(1 - trackingFrameSize.magnitude);

            handPositionVector = ARCamera.ViewportToWorldPoint(new Vector3(latestDataSet.Rect.center.x, 1 - latestDataSet.Rect.center.y, depthEstimation));

        }
    }
}
