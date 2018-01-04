using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileZ;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileZ);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
