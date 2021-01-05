using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSight : MonoBehaviour
{
    public Transform playerTransform;

    private void Update()
    {
        RaycastHit[] hits;
        Vector3 dir = playerTransform.position - transform.position;

        hits = Physics.RaycastAll(transform.position, dir, 10f);

        foreach (RaycastHit hit in hits)
        {
            // hit gameobject should be tagged and be in front of the player
            if (hit.collider.CompareTag("FadeOut") && IsInFrontOfPlayer(hit.distance))
            {
                var fadingObject = hit.collider.GetComponent<FadeOutObject>();
                fadingObject.FadeOut();
            }

        }
    }

    /// <summary>
    /// If the distance of the hit object is less than the distance to the player the object is in between the player and camera
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    private bool IsInFrontOfPlayer(float distance)
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        return distance < distanceToPlayer;
    }
}
