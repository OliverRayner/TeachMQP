using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class orange_flight : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Image pk = GameObject.Find("flying-1").GetComponent<Image>();
        Text txt = GameObject.Find("Instructions-prompt").GetComponent<Text>();


        if(txt.text.Equals("Select all blocks that are orange AND have flight"))
        {
        txt.text = "Select all blocks that are purple AND have strength";
        pk.enabled = false;
        }

    }
}
