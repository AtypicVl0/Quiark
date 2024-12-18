using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class joystickk : MonoBehaviour,IDragHandler, IPointerClickHandler, IPointerUpHandler,IPointerDownHandler
{
    public Transform player;
    Vector3 move;
    public float movespeed;
    public RectTransform pad;
    bool Running;
    

    public void OnDrag(PointerEventData eventData)
    {
       
        transform.position = eventData.position;
         transform.localPosition =
            Vector2.ClampMagnitude(eventData.position - (Vector2)pad.position, pad.rect.width * 0.5f);
        move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y).normalized;
        if(!Running)
        {
            Running = true;
            player.GetComponent<Animator>().SetBool("Running", true);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = new Vector3(7,-824,0);
        move = Vector3.zero;
        StopCoroutine("PlayerMove");
        Running = false;
        player.GetComponent<Animator>().SetBool("Running", false);

    }
   
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine("PlayerMove");
       

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        Debug.Log("Clicked");
    }
    IEnumerator PlayerMove()
    {
        while(true)
        {
            player.Translate(move * movespeed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
            {
                player.rotation = Quaternion.Slerp(player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            }

            yield return null;
        }
    }
}
