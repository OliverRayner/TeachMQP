using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class green_strength : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Image pk1 = GameObject.Find("telepathy-2").GetComponent<Image>();
        Image pk2 = GameObject.Find("strength-3").GetComponent<Image>();
        Image pk3 = GameObject.Find("flying-2").GetComponent<Image>();
        Text txt = GameObject.Find("Instructions-prompt").GetComponent<Text>();

        if(txt.text.Equals("Select all blocks that are green OR have flight") && pk1.enabled==false && pk3.enabled==false)
        {
            txt.text = "You win!";
            pk2.enabled = false;
        } else if(txt.text.Equals("Select all blocks that are green OR have flight"))
        {
            pk2.enabled = false;
        }

    }
}