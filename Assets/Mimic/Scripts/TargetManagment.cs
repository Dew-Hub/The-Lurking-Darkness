using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MimicSpace;

public class TargetManagment : MonoBehaviour
{
    public GameObject target;
    public Camera cam;

    private bool IsVisible(Camera c, GameObject Target)
    {
        Vector3 screenPoint = c.WorldToViewportPoint(Target.transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    // Movement script'inden erişeceğimiz nesne
    public Movement mimicMovement;

    // Update is called once per frame
    private void Update()
    {
        if (IsVisible(cam, target))
        {
            mimicMovement.speed = 5f; // Hızlandırma
        }
        else
        {
            mimicMovement.speed = 2f; // Yavaşlatma
        }
    }
}
