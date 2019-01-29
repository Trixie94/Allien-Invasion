using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    public Transform center;
    public float degreesPerSecond = -65f;

    private Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        v = transform.position - center.position;
    }

    // Update is called once per frame
    void Update()
    {
        v = Quaternion.AngleAxis(degreesPerSecond * Time.deltaTime, Vector3.forward) * v;
        transform.position = center.position + v;
    }
}
