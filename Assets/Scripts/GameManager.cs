using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerMovement playermvmnt;
    private GameObject player;

    public GameObject FoodShop;

    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playermvmnt = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ExitShop()
    {
        FoodShop.SetActive(false);
    }

    public void give10()
    {
        if (playermvmnt.wood > 100)
        {
            playermvmnt.wood -= 100;
            playermvmnt.mushroom += 10;
            buttons[0].interactable = true;
        }
        else
        {
            buttons[0].interactable = false;
        }
    }
    public void give50()
    {
        if (playermvmnt.wood > 500)
        {
            playermvmnt.wood -= 500;
            playermvmnt.mushroom += 50;
            buttons[1].interactable = true;
        }
        else
        {
            buttons[1].interactable = false;
        }
    }
    public void give100()
    {
        if (playermvmnt.wood > 1000)
        {
            playermvmnt.wood -= 1000;
            playermvmnt.mushroom += 100;
            buttons[2].interactable = true;
        }
        else
        {
            buttons[2].interactable = false;
        }
    }
}
