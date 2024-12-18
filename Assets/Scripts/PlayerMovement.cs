using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int mushroom;
    public int stairs;
    private bool olusum = true;
    private bool attack;
    public Rigidbody rb;
    public float speed;
    public Animator anim;
    private Animation animtre;
    private GameObject tree;
    //public FixedJoystick joystick;
    public FloatingJoystick joystick;
    private float health;
    private Score score;
    public int wood ;
    public int stone;
    public Text woodt;
    public Text musht;
    public Text tstone;
    public GameObject Axe;
    public GameObject pAxe;
    private GameObject Log;
    Coroutine co;
    public GameObject tre;
    public GameObject tre1;
    public GameObject sto;
    public GameObject sto1;
    public bool intrig;
    private Collider trecol;
    private Collider arecol;
    private GameObject trepref;
    private GameObject stonpref;
    private Collider trecol1;
    private Collider arecol1;
    private GameObject trepref1;
    private GameObject stonpref1;
    public Slider slide;
    private int screw;
    private GameObject FoodStat;


    private bool objectGone;

    // Start is called before the first frame update
    void Start()
    {
        stone = PlayerPrefs.GetInt("Stone");
        FoodStat = GameObject.Find("Food");
        wood = PlayerPrefs.GetInt("Wood");
        mushroom = PlayerPrefs.GetInt("mushroom");
        
        slide.value = PlayerPrefs.GetFloat("Hunger");
        //tree = GameObject.FindGameObjectWithTag("Tree");
        //score = tree.GetComponent<Score>();
        
    }


    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Wood", wood);
        PlayerPrefs.SetInt("Stone",stone);
        PlayerPrefs.SetInt("mushroom",mushroom);
        attack = anim.GetBool("Attack");
        // anim.SetBool("Attack", false);

        slide.value -= 0.0005f;
        PlayerPrefs.SetFloat("Hunger", slide.value);

        musht.text = "Mushroom:" + mushroom;
        woodt.text = "Wood:" + wood;
        tstone.text = "Stone:" + stone;
        #region Plyr_Movmnt
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            anim.SetBool("Running", true);
            
            

            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        #endregion

        if (slide.value <= 0f)
        {
           // Die();
        }
        anim.SetBool("Attack", false);
        if(intrig == false)
        {
           // Debug.Log("vuramam kapal�");
            anim.SetBool("Attack", false);
        }

        objectGone = true;
    }
    
    IEnumerator OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            anim.SetBool("Attack", true);
        }




        #region TreeCut
        if (other.gameObject.tag == "Ground" && other.gameObject.tag == "Tree")
        {
            anim.SetBool("Attack", true);
            Axe.SetActive(true);
        }
        
        if (other.gameObject.tag == "Tree" )
        {
           
            //animtre = other.gameObject.GetComponent<Animation>();
            // anim.SetBool("Attack", false);
            //attack = true;
            // co = StartCoroutine(Cut(other));
           
            anim.SetBool("Attack", true);
           
              if (other.gameObject.GetComponent<Score>().Health <= 0 && objectGone == false)
              {
                yield return new WaitForSeconds(0.5f);
                other.gameObject.SetActive(false);
                    yield return new WaitForSeconds(4f);
                // Instantiate(tre, other.gameObject.transform.position, Quaternion.identity);
                trepref = Instantiate(tre, other.gameObject.transform.position, Quaternion.identity);
                arecol = other.gameObject.GetComponent<Collider>();
                arecol.enabled = false;
                    yield return new WaitForSeconds(0.01f);
                   arecol.enabled = true;
                    attack = false;
                objectGone = true;
            }
           

            PlayerPrefs.SetInt("Wood", wood);
        }
       
        if (other.gameObject.tag == "Tree1")
        {
           
            //animtre = other.gameObject.GetComponent<Animation>();
            // anim.SetBool("Attack", false);
            //attack = true;
            // co = StartCoroutine(Cut(other));
            anim.SetBool("Attack", true);
           
            if (other.gameObject.GetComponent<Score>().Health <= 0)
            {
                yield return new WaitForSeconds(0.5f);
                other.gameObject.SetActive(false);
                yield return new WaitForSeconds(4f);
                // Instantiate(tre, other.gameObject.transform.position, Quaternion.identity);
                trepref1 = Instantiate(tre1, other.gameObject.transform.position, Quaternion.identity);
                arecol1 = other.gameObject.GetComponent<Collider>();
                arecol1.enabled = false;
                yield return new WaitForSeconds(0.01f);
                arecol1.enabled = true;
                attack = false;
                objectGone = true;
            }
            arecol1.enabled = true;
            PlayerPrefs.SetInt("Wood", wood);
        }
       
        #endregion 
        
        if (other.gameObject.tag == "Ground")
        {
            anim.SetBool("Attack", false);
            // animtre.enabled = false;
           
        }
        
        #region StoneCut
        if ( other.gameObject.tag == "Stone")
        {
            //anim.SetBool("Attack", true);
            pAxe.SetActive(true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        if (other.gameObject.tag == "Stone")
        {

            //animtre = other.gameObject.GetComponent<Animation>();
            // anim.SetBool("Attack", false);
            //attack = true;
            // co = StartCoroutine(Cut(other));
            
             anim.SetBool("Attack", true);
            
               if (other.gameObject.GetComponent<Score>().Health <= 0 && objectGone == false)
               {
                  yield return new WaitForSeconds(0.5f);
                  other.gameObject.SetActive(false);
                  yield return new WaitForSeconds(4f);
                  // Instantiate(tre, other.gameObject.transform.position, Quaternion.identity);
                  stonpref = Instantiate(sto, other.gameObject.transform.position, Quaternion.identity);
                  trecol = other.gameObject.GetComponent<Collider>();
                  trecol.enabled = false;
                  yield return new WaitForSeconds(0.01f);
                  arecol.enabled = true;
                  attack = false;
                objectGone = true;
            }
            

            trecol.enabled = true;
            PlayerPrefs.SetInt("Stone",stone);
        }

        #endregion
        if (other.gameObject.tag == "Stone1")
        {
           
            //animtre = other.gameObject.GetComponent<Animation>();
            // anim.SetBool("Attack", false);
            //attack = true;
            // co = StartCoroutine(Cut(other));

            anim.SetBool("Attack", true);

            if (other.gameObject.GetComponent<Score>().Health <= 0 && objectGone == false)
            {
                yield return new WaitForSeconds(0.5f);
                other.gameObject.SetActive(false);
                yield return new WaitForSeconds(4f);
                // Instantiate(tre, other.gameObject.transform.position, Quaternion.identity);
                stonpref1 = Instantiate(sto1, other.gameObject.transform.position, Quaternion.identity);
                trecol1 = other.gameObject.GetComponent<Collider>();
                trecol1.enabled = false;
                yield return new WaitForSeconds(0.01f);
                arecol.enabled = true;
                attack = false;
                objectGone = true;
            }
           

            PlayerPrefs.SetInt("Stone", stone);
        }
       



    }
    IEnumerator OnTriggerEnter(Collider other)
    {
       
       trecol = other.gameObject.GetComponent<Collider>();
        if(other.gameObject.tag == "Tree")
        {
            intrig = true;
            trecol.enabled = true;
            attack = true;
            objectGone = false;
            if (other.gameObject.GetComponent<Score>().Health > 0 && attack == true )
            {
                
                anim.SetBool("Attack", true);
                //yield return new WaitForSeconds(1f);
                wood += 1;
                other.gameObject.GetComponent<Score>().Health -= 1;
                yield return new WaitForSeconds(0.1f);
               
                trecol.enabled = false;
                attack = false;
                yield return new WaitForSeconds(0.2f);
                
                trecol.enabled = true;
                anim.SetBool("Attack", true);
                 
                slide.value -= 0.01f;
                PlayerPrefs.SetFloat("Hunger", slide.value);
                if (attack == true)
                {
                    Debug.Log("vurduk");
                    //animtre.enabled = true;
                }
                
            }
            else
            {
                yield break;
               // trecol.enabled = true;
              //  attack = false;
            }
        }
        else
        {
            intrig = false;
            attack = false;
        }
        if (other.gameObject.tag == "Tree1")
        {
            objectGone = false;
            intrig = true;
            trecol.enabled = true;
            attack = true;
            if (other.gameObject.GetComponent<Score>().Health > 0 && attack == true)
            {

                anim.SetBool("Attack", true);
                //yield return new WaitForSeconds(1f);
                wood += 1;
                other.gameObject.GetComponent<Score>().Health -= 1;
                yield return new WaitForSeconds(0.1f);

                trecol.enabled = false;
                attack = false;
                yield return new WaitForSeconds(0.2f);

                trecol.enabled = true;
                anim.SetBool("Attack", true);

                slide.value -= 0.01f;
                PlayerPrefs.SetFloat("Hunger", slide.value);
                if (attack == true)
                {
                    Debug.Log("vurduk");
                    //animtre.enabled = true;
                }

            }
            else
            {
                yield break;
                // trecol.enabled = true;
                //  attack = false;
            }
        }
        else
        {
            intrig = false;
            attack = false;
        }


        trecol = other.gameObject.GetComponent<Collider>();
        if (other.gameObject.tag == "Stone")
        {
            objectGone = false;
            intrig = true;
            Debug.Log("ta�tay�m");
            trecol.enabled = true;
            attack = true;
            if (other.gameObject.GetComponent<Score>().Health > 0 && attack == true)
            {

                anim.SetBool("Attack", true);
                //yield return new WaitForSeconds(1f);
                stone += 1;
                other.gameObject.GetComponent<Score>().Health -= 1;
                yield return new WaitForSeconds(0.1f);

                trecol.enabled = false;
                attack = false;
                yield return new WaitForSeconds(0.2f);

                trecol.enabled = true;
                anim.SetBool("Attack", true);
                attack = true;
                slide.value -= 0.01f;
                PlayerPrefs.SetFloat("Hunger", slide.value);
                if (attack == true)
                {
                    Debug.Log("vurduk");
                    //animtre.enabled = true;
                }

            }
            else
            {
                trecol.enabled = true;
                 attack = false;
                yield break;
               
            }
        }
        else
        {
            intrig = false;
            attack = false;
        }
        if (other.gameObject.tag == "Stone1")
        {
            objectGone = false;
            intrig = true;
            Debug.Log("ta�tay�m");
            trecol.enabled = true;
            attack = true;
            if (other.gameObject.GetComponent<Score>().Health > 0 && attack == true)
            {

                anim.SetBool("Attack", true);
                //yield return new WaitForSeconds(1f);
                stone += 1;
                other.gameObject.GetComponent<Score>().Health -= 1;
                yield return new WaitForSeconds(0.1f);

                trecol.enabled = false;
                attack = false;
                yield return new WaitForSeconds(0.2f);

                trecol.enabled = true;
                anim.SetBool("Attack", true);
                attack = true;
                slide.value -= 0.01f;
                PlayerPrefs.SetFloat("Hunger", slide.value);
                if (attack == true)
                {
                    Debug.Log("vurduk");
                    //animtre.enabled = true;
                }

            }
            else
            {
                trecol.enabled = true;
                attack = false;
                yield break;

            }
        }
        else
        {
            intrig = false;
            attack = false;
        }
        if (other.gameObject.tag == "Food" && screw >= 3)
        {

        }
    }



    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Tree")
        {
            attack = false;
            Debug.Log("exit");

            intrig = false;
            Axe.SetActive(false);
        }
        if (other.gameObject.tag == "Stone")
        {
            attack = false;
            Debug.Log("exit");

            intrig = false;
            pAxe.SetActive(false);
        }
        if(other.gameObject.tag == "Enemy")
        {
            anim.SetBool("Attack", false);
        }

    }

    void Die ()
    {
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        wood /= 2;
        slide.value = 100f;
        PlayerPrefs.SetInt("Wood", wood);
    }
   
    
    void Spawn(Collider other)
    {
        if(olusum == true)
        {
            stonpref = Instantiate(sto, other.gameObject.transform.position, Quaternion.identity);
        }
           
            
        


    }
    
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        slide.value = 100f;
    }

    
}


