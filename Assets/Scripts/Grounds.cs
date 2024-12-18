using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    private PlayerMovement playermvmnt;
    private GameObject player;
    public GameObject[] grounds;
    public GameObject[] tree;
    private static int gro;
    public GameObject[] lvl;
    public GameObject[] info;
    // Start is called before the first frame update
    void Start()
    {
        gro = PlayerPrefs.GetInt("gro1", 1);
        player = GameObject.FindGameObjectWithTag("Player");
        playermvmnt = player.GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("gro1") == 2)
        {
            grounds[0].SetActive(true);
            lvl[8].SetActive(false);
            info[0].SetActive(false);
            info[1].SetActive(true);
            lvl[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro2") == 2)
        {
            grounds[1].SetActive(true);
            lvl[0].SetActive(false);
            info[1].SetActive(false);
            info[2].SetActive(true);
            lvl[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro3") == 2)
        {
            grounds[2].SetActive(true);
            lvl[1].SetActive(false);
            lvl[2].SetActive(true);
            info[2].SetActive(false);
            info[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro4") == 2)
        {
            grounds[3].SetActive(true);
            lvl[2].SetActive(false);
            
            lvl[7].SetActive(true);
            info[3].SetActive(false);
            info[4].SetActive(true);
           
        }
        if (PlayerPrefs.GetInt("gro9") == 2)
        {
            grounds[4].SetActive(true);
            lvl[7].SetActive(false);

            info[5].SetActive(true);
            info[4].SetActive(false);

        }
        if (PlayerPrefs.GetInt("gro5") == 2)
        {
            grounds[5].SetActive(true);
            lvl[3].SetActive(false);
            
            lvl[4].SetActive(true);
            info[5].SetActive(false);
            info[6].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro6") == 2)
        {
            grounds[6].SetActive(true);
            lvl[4].SetActive(false);
            lvl[5].SetActive(true);
            info[6].SetActive(false);
            info[7].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro7") == 2)
        {
            grounds[7].SetActive(true);
            lvl[5].SetActive(false);
            lvl[6].SetActive(true);
            info[7].SetActive(false);
            info[8].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro8") == 2)
        {
            grounds[8].SetActive(true);
            lvl[6].SetActive(false);
            lvl[9].SetActive(true);
            info[8].SetActive(false);
            info[9].SetActive(true);

        }
        




        if (PlayerPrefs.GetInt("gro10") == 2)
        {
            grounds[9].SetActive(true);
            lvl[9].SetActive(false);

            lvl[10].SetActive(true);
            info[9].SetActive(false);
            info[10].SetActive(true);
        }
        if (PlayerPrefs.GetInt("gro11") == 2)
        {
            grounds[10].SetActive(true);
            lvl[10].SetActive(false);
            lvl[12].SetActive(true);
            info[10].SetActive(false);
            info[11].SetActive(true);
        }
        /*
        if (PlayerPrefs.GetInt("gro12") == 2)
        {
            grounds[11].SetActive(true);
            lvl[11].SetActive(false);
            lvl[12].SetActive(true);
            info[11].SetActive(false);
            info[12].SetActive(true);
        }
        */
        if (PlayerPrefs.GetInt("gro13") == 2)
        {
            grounds[12].SetActive(true);
            lvl[12].SetActive(false);
            lvl[13].SetActive(true);
            info[12].SetActive(false);
            info[13].SetActive(true);

        }
        if (PlayerPrefs.GetInt("gro14") == 2)
        {
            grounds[13].SetActive(true);
            lvl[13].SetActive(false);
           // lvl[12].SetActive(true);
            info[13].SetActive(false);
            //info[13].SetActive(true);

        }


    }

    void OnTriggerStay(Collider other)
    {
        #region Grounds
        if (other.gameObject.name == "lvl1" && playermvmnt.wood > 50)
        {
            grounds[0].SetActive(true);
            PlayerPrefs.SetInt("gro1", 2);
            lvl[0].SetActive(true);
          
            playermvmnt.wood -=50;
           
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
        }

        if (other.gameObject.name == "lvl2" && playermvmnt.wood > 80 && playermvmnt.stone > 30)
        {
            grounds[1].SetActive(true);
            PlayerPrefs.SetInt("gro2", 2);
            lvl[1].SetActive(true);
            playermvmnt.wood -= 80;
            playermvmnt.stone -= 30;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);

        }
        if (other.gameObject.name == "lvl3" && playermvmnt.wood > 110 && playermvmnt.stone > 60)
        {
            grounds[2].SetActive(true);
            PlayerPrefs.SetInt("gro3", 2);
            lvl[2].SetActive(true);
            playermvmnt.wood -= 110;
            playermvmnt.stone -= 60;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);
        }
        if (other.gameObject.name == "lvl4" && playermvmnt.wood > 140 && playermvmnt.stone > 90)
        {
            grounds[3].SetActive(true);
            PlayerPrefs.SetInt("gro4", 2);
            lvl[7].SetActive(true);
            playermvmnt.wood -= 140;
            playermvmnt.stone -= 90;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);
        }

        if (other.gameObject.name == "lvl5" && playermvmnt.wood > 170 && playermvmnt.stone >120)
        {
            grounds[5].SetActive(true);
            PlayerPrefs.SetInt("gro5", 2);
            lvl[4].SetActive(true);
            playermvmnt.wood -= 170;
            playermvmnt.stone -= 120;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);

        }
        if (other.gameObject.name == "lvl6" && playermvmnt.wood > 200 && playermvmnt.stone > 150)
        {
            grounds[6].SetActive(true);
            PlayerPrefs.SetInt("gro6", 2);
            lvl[5].SetActive(true);
            playermvmnt.wood -= 200;
            playermvmnt.stone -= 150;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);
        }
        if (other.gameObject.name == "lvl7" && playermvmnt.wood > 230 && playermvmnt.stone > 180)
        {
            grounds[7].SetActive(true);
            PlayerPrefs.SetInt("gro7", 2);
            lvl[6].SetActive(true);
            playermvmnt.wood -= 230;
            playermvmnt.stone -= 180;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);
        }

        if (other.gameObject.name == "lvl8" && playermvmnt.wood > 250 && playermvmnt.stone >200)
        {
            grounds[8].SetActive(true);
            PlayerPrefs.SetInt("gro8", 2);
            lvl[9].SetActive(true);
            playermvmnt.wood -= 250;
            playermvmnt.stone -= 200;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);
        }
        if (other.gameObject.name == "lvl9" && playermvmnt.wood > 150 && playermvmnt.stone >100)
        {
            grounds[4].SetActive(true);
            PlayerPrefs.SetInt("gro9", 2);
            lvl[3].SetActive(true);
            playermvmnt.wood -= 150;
            playermvmnt.stone -= 100;
            PlayerPrefs.SetInt("Wood", playermvmnt.wood);
            PlayerPrefs.SetInt("Stone", playermvmnt.stone);

        }



        if (other.gameObject.name == "lvl10" && playermvmnt.mushroom > 80)
        {
            grounds[9].SetActive(true);
            PlayerPrefs.SetInt("gro10", 2);
            lvl[10].SetActive(true);
            playermvmnt.mushroom -= 80;
            PlayerPrefs.SetInt("mushroom", playermvmnt.mushroom);

        }
        if (other.gameObject.name == "lvl11" && playermvmnt.mushroom > 120 && playermvmnt.stairs > 50)
        {
            grounds[10].SetActive(true);
            PlayerPrefs.SetInt("gro11", 2);
            lvl[12].SetActive(true);
            playermvmnt.mushroom -= 120;
            playermvmnt.stairs -= 50;
        }
        //all of this GONE!!
        /*
        if (other.gameObject.name == "lvl12" && playermvmnt.wood > 120)
        {
            
            grounds[11].SetActive(true);
            PlayerPrefs.SetInt("gro12", 2);
            lvl[12].SetActive(true);
            
        }
        */
        //this!
        if (other.gameObject.name == "lvl13" && playermvmnt.mushroom > 200 && playermvmnt.stairs >80)
        {
            grounds[12].SetActive(true);
            PlayerPrefs.SetInt("gro13", 2);
            lvl[13].SetActive(true);
            playermvmnt.mushroom -= 200;
            playermvmnt.stairs -= 80;
        }
        if (other.gameObject.name == "lvl14" && playermvmnt.mushroom > 250 && playermvmnt.stairs > 100)
        {
            grounds[13].SetActive(true);
            PlayerPrefs.SetInt("gro14", 2);
            //lvl[14].SetActive(true);
            playermvmnt.mushroom -= 250;
            playermvmnt.stairs -= 100;

        }
        #endregion
    }
}
