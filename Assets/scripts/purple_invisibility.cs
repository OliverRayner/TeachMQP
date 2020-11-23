using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class purple_invisibility : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Image pk1 = GameObject.Find("invisibility-1").GetComponent<Image>();
        Image pk2 = GameObject.Find("invisibility-2").GetComponent<Image>();
        Text txt = GameObject.Find("Instructions-prompt").GetComponent<Text>();

        if(txt.text.Equals("Select all blocks that are purple OR have invisibility") && pk2.enabled==false)
        {
            txt.text = "Select all blocks that are orange AND have telepathy";
            pk1.enabled = false;
        } else if(txt.text.Equals("Select all blocks that are purple OR have invisibility"))
        {
            pk1.enabled = false;
        }

    }
}
