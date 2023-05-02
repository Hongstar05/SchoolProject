using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP : MonoBehaviour
{
    public Transform[] platformPosition = new Transform[3];
    int direction = 1;
    public float speed = 0;
    Vector2 target;
    // Update is called once per frame
    void Update()
    {
        Vector2 target = CurrentMovementTarget();
        float distance = (target - (Vector2)platformPosition[0].position).magnitude;
        if(distance <= .5f)
        {
            direction *= -1;
        }
    }
    private void FixedUpdate()
    {
        platformPosition[0].position = Vector2.Lerp(platformPosition[0].position, target, speed * Time.deltaTime);
    }
    Vector2 CurrentMovementTarget()
    {
        if(direction == 1)
        {
            return platformPosition[0].position;
        }
        else
        {
            return platformPosition[2].position;
        }
    }
    private void OnDrawGizmos()
    {
        if(platformPosition[0] != null && platformPosition[1] != null && platformPosition[2])
        {
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[1].transform.position);
            Gizmos.DrawLine(platformPosition[0].transform.position, platformPosition[2].transform.position);
        }
    }
}
