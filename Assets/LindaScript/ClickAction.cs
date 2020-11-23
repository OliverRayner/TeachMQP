using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using Random = System.Random;

public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {

        Text txt = GameObject.Find("Fire1Text").GetComponent<Text>();


        string[] randVal = new[] { "\"Dog\"", "\"Cat\"", "\"Car\"", "\"School\"", "\"Duck\"", "\"Barn\"", "\"True\"", "\"False\"", "False", "True", "1", "127", "30", "55", "42" };

        Random rand = new Random();
        var random = randVal[rand.Next(randVal.Length)];

        txt.text = random;

 
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Image pk = GameObject.Find("Fire1").GetComponent<Image>();
       

        Text txt = GameObject.Find("Fire1Text").GetComponent<Text>();
        

        Text dataType = GameObject.Find("DataTypeText").GetComponent<Text>();

       
        if (txt.text == "True" || txt.text == "False")           
        {
            if (dataType.text == "Boolean")
            {
                txt.enabled = false;
                pk.enabled = false;

                

                Text clickText = GameObject.Find("ClickText").GetComponent<Text>();
                clickText.enabled = false;
                dataType.text = "YOU WIN";
            }

        }
        else if (txt.text.Any(char.IsDigit))         
        {
            if (dataType.text == "Integer")
            {
                txt.enabled = false;
                pk.enabled = false;

                dataType.text = "String";
            }
        }
        else
        {
            if (dataType.text == "String")
            {
                txt.enabled = false;
                pk.enabled = false;
                

                dataType.text = "Boolean";
            }
        }
        
    }
}
