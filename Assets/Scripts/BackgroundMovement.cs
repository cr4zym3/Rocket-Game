using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject player;
    public float smoothSpeed = 0.125f;

    void Update()
    {
        float offset = player.transform.position.y / 3f;
        Vector2 targetPosition = new Vector2(0, 24f + offset);
        transform.position = Vector2.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
