using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{

    // Start is called before the first frame update

    public Transform player;
    public List<Transform> points;
    public int nextid;
    private int idChangeValue = 1;
    public float speed;
    public float DistanceCheck;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < 5F)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            MoveToNextPoint();

        }
    }
    void MoveToNextPoint()
    {
        //set and get a point based on our list indez
        Transform goalpoint = points[nextid];
        //flips the enemy to look at the next goalPoint
        if (goalpoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, goalpoint.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalpoint.position) < 1f)

            if (nextid == points.Count - 1)
            {
                idChangeValue = -1;

            }
        if (nextid == points.Count - 1)
        {
            idChangeValue = -1;

        }
        nextid += idChangeValue;




    }
} 
