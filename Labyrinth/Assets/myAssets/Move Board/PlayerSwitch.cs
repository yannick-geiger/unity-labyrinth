using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public PlayerController playerController;
    public PlayerController player2Controller;
    public PlayerController player3Controller;
    public PlayerController player4Controller;
    public bool player1Active = true;
    public bool player2Active = false;
    public bool player3Active = false;
    public bool player4Active = false;
    [SerializeField]
    
    public void SwitchPlayer()
    {
        if (player1Active)
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            player3Controller.enabled = false;
            player4Controller.enabled = false;
            player1Active = false;
            player2Active = true;
            player3Active = false;
            player4Active = false;
        }
        else if (player2Active)
        {
            playerController.enabled = false;
            player2Controller.enabled = false;
            player3Controller.enabled = true;
            player4Controller.enabled = false;
            player1Active = false;
            player2Active = false;
            player3Active = true;
            player4Active = false;
        }
        else if (player3Active)
        {
            playerController.enabled = false;
            player2Controller.enabled = false;
            player3Controller.enabled = false;
            player4Controller.enabled = true;
            player1Active = false;
            player2Active = false;
            player3Active = false;
            player4Active = true;
        }
        else if (player4Active)
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player3Controller.enabled = false;
            player4Controller.enabled =false;
            player1Active = true;
            player2Active = false;
            player3Active = false;
            player4Active = false;
        }
        
    }
}

