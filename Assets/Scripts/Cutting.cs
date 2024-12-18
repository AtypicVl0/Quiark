using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    private PlayerMovement plyrmvmnt;
    private GameObject player;

    private Collider trecol;
    private Animator anim;

    private bool cut;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        plyrmvmnt = player.GetComponent<PlayerMovement>();
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        cut = true;
        trecol = other.gameObject.GetComponent<Collider>();
        if (other.gameObject.tag == "Tree" && cut == true) 
        {
            plyrmvmnt.wood += 2;
            anim.SetBool("Attack", true);
            //  yield WaitForSeconds(anim.IsPlaying["Attack"].length* animation["clip"].speed);
            cut = false;

           
        }
    }
}
