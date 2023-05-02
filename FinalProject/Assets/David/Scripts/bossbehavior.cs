using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossbehavior : MonoBehaviour
{
    //create a health variable called bossHealth
    public int bosshealth = 10;
    public float speed = 6;
    Transform player;
    public bool isFlipped = false;
    public float attackrange = 1.5f;
    public bool Phase2 = false;
    public bool Phase3 = false;
    public bool isDead = false;
    public Transform shotLocation;
    public float timer;
    public float CoolDown;
    public GameObject projectile;
    public GameObject projectile2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 

    }

    // Update is called once per frame
    void Update()
    {
        if(bosshealth< 7 && bosshealth >3)
        {
            Phase2 = true;
            attackrange = 6;
            speed = 1;
            Debug.Log("Phase2");
        }
        else if(bosshealth < 3 && bosshealth >= 1 ) 
        {
            Phase2 = false;
            Phase3 = true;
            speed = 3;
            speed = 8;
            Debug.Log("Phase3");
        }
        else if(bosshealth <= 0)
        {
            Phase3 = false;
            isDead = true;
            Debug.Log("Dead");
        }
        timer = Time.deltaTime;

    }
    public void ProjectileShoot()
    {
        if(timer > CoolDown)
        {
            GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
            
            
            timer = 0;
        }
        if (Phase2)
        {
            GameObject clone = Instantiate(projectile, shotLocation.position, Quaternion.identity);
            timer = 0;
        }
        
        else if (Phase3)
        {
            GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
            timer = 0;
        }

        
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;
        if (transform.position.x > player.position.x && isFlipped) 
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
        else if(transform.position.x<player.position.x&& !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }

    }
}

