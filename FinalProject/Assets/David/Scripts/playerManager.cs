using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    // Start is called before the first frame upd
    public int maxhealth;
    public int currenthealth;    PlayerMovement playerMovement;
    public int coinCount;
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();  
    }
    public bool PickUpItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                return true;
            case "speed+":
                playerMovement.SpeedPowerUp();
                return true;
            default:
                Debug.Log("Coin picked up");
                return false;
        }
    }
    public void TakeDamage()
    {
        currenthealth -= 1;
    }
    private void Update()
    {
        if(currenthealth <= 0)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1 ;
    }

}
