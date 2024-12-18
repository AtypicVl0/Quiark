using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 10f;
    public Vector3 offset;
    public float speed = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        // transform.position = player.transform.position - player.transform.forward * cameraDistance;
        //transform.LookAt(player.transform.position);
        //transform.position = new Vector3(transform.position.x, transform.position.y + 7, transform.position.z);
        transform.position = player.position + offset;
    }
}
