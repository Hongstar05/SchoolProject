using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerManager manager = collision.GetComponent<playerManager>();

            manager.PickUpItem(gameObject);
            if (manager)
            {
                bool pickUP = manager.PickUpItem(gameObject);

                if (pickUP)
                {
                    Destroy(gameObject);
                }

            }
        }
    }

}
