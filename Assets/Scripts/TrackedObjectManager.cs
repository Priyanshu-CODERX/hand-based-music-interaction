using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObjectManager : MonoBehaviour
{
    [SerializeField] HandTrackingManager handTrackingManager;
    [SerializeField] GameObject trackableObject;
    [SerializeField] float objectMovementSpeed = 0.5f;

    private void Update()
    {
        float currentDistanceToObject = Vector3.Distance(handTrackingManager.HandPositionVector, trackableObject.transform.position);
        trackableObject.transform.position = Vector3.MoveTowards(trackableObject.transform.position, handTrackingManager.HandPositionVector, objectMovementSpeed);
    }
}
