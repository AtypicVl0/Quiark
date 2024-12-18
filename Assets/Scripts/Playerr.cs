using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerr : MonoBehaviour
{
    private GameObject gamemanage;
    private GameManager gameManager;
    private PlayerMovement playermvmnt;
    private GameObject player;
    private int screwnum;
    private int screcol;
    private int screcol1;
    private int screcol2;
    public GameObject[] screw;

    private bool tükendi;

    
    // Start is called before the first frame update
    void Start()
    {
        gamemanage = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gamemanage.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playermvmnt = player.GetComponent<PlayerMovement>();
        screwnum = PlayerPrefs.GetInt("screw");
        screcol = PlayerPrefs.GetInt("scr");
        screcol1 = PlayerPrefs.GetInt("scr1");
        screcol2 = PlayerPrefs.GetInt("scr2");
    }

    // Update is called once per frame
    void Update()
    {

        if(screcol == 1)
        {
            Destroy(screw[0]);
        }
        if (screcol1 == 1)
        {
            Destroy(screw[1]);
        }
        if (screcol2 == 1)
        {
            Destroy(screw[2]);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        #region screws
        if (other.gameObject.tag == "Screw")
        {
           
            Destroy(other.gameObject);
            screwnum++;
            PlayerPrefs.SetInt("screw", screwnum);
            PlayerPrefs.SetInt("scr", 1);

        }
        if (other.gameObject.tag == "Screw1")
        {

            Destroy(other.gameObject);
            screwnum++;
            PlayerPrefs.SetInt("screw", screwnum);
            PlayerPrefs.SetInt("scr1", 1);

        }
        if (other.gameObject.tag == "Screw2")
        {

            Destroy(other.gameObject);
            screwnum++;
            PlayerPrefs.SetInt("screw", screwnum);
            PlayerPrefs.SetInt("scr2", 1);

        }

        if (other.gameObject.tag == "Food" && screwnum >=3)
        {
            //play animation
           // StartCoroutine(giveFood());
            gameManager.FoodShop.SetActive(true);
            Debug.Log("food ready");
            if (playermvmnt.wood > 100)
            {

                gameManager.buttons[0].interactable = true;
            }
            else
            {
               gameManager.buttons[0].interactable = false;
            }
            if (playermvmnt.wood > 500)
            {

                gameManager.buttons[1].interactable = true;
            }
            else
            {
                gameManager.buttons[1].interactable = false;
            }
            if (playermvmnt.wood > 1000)
            {

                gameManager.buttons[2].interactable = true;
            }
            else
            {
                gameManager.buttons[2].interactable = false;
            }

        }
        if (other.gameObject.tag == "Eat" )
        {
            tükendi = false;

        }
        #endregion

       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Eat" && tükendi == false )
        {
            playermvmnt.mushroom--;
            playermvmnt.slide.value++;
            if (playermvmnt.mushroom <= 0 || playermvmnt.slide.value >98)
            {
                tükendi = true;
            }

        }
        
    }

   

    
}
