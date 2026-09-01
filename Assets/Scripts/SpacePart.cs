using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePart : MonoBehaviour
{
    public float moveDistance = 1.0f;

    public float moveSpeed = 1.0f;

    private Vector2 startingPos;
    private Vector2 targetPos;

    void Start()
    {
        startingPos = transform.position;
        targetPos = startingPos + new Vector2(0, moveDistance);
    }

    void Update()
    {
        float time = Mathf.PingPong(Time.time * moveSpeed, 1);
        transform.position = Vector3.Lerp(startingPos, targetPos, time);
    }


}
