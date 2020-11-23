using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using Random = System.Random;

public class ClickAction3 : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {


        Text fire1txt = GameObject.Find("Fire1Text").GetComponent<Text>();

        Text fire2txt = GameObject.Find("Fire2Text").GetComponent<Text>();

        Text fire3txt = GameObject.Find("Fire3Text").GetComponent<Text>();

        Random rand = new Random();

        //Fire1 is a Bool
        if (fire1txt.text == "True" || fire1txt.text == "False")
        {
            //Fire2 is an Int
            if (fire2txt.text.Any(char.IsDigit))
            {
                //Fire 3 is a String
                string[] randVal = new[] { "\"Dog\"", "\"Cat\"", "\"Car\"", "\"School\"", "\"Duck\"", "\"Barn\"", "\"True\"", "\"False\"" };
                var random = randVal[rand.Next(randVal.Length)];
                fire3txt.text = random;
            }
            //Fire2 is a String
            else
            {
                //Fire3 is an Int
                string[] randVal = new[] { "1", "127", "30", "55", "42" };
                var random = randVal[rand.Next(randVal.Length)];
                fire3txt.text = random;

            }
                

        }
        //Fire1 is an Int
        else if (fire1txt.text.Any(char.IsDigit))
        {
            //Fire2 is a Boolean
            if (fire2txt.text == "True" || fire2txt.text == "False")
            {
                //Fire3 is a String
                string[] randVal = new[] { "\"Dog\"", "\"Cat\"", "\"Car\"", "\"School\"", "\"Duck\"", "\"Barn\"", "\"True\"", "\"False\"" };
                var random = randVal[rand.Next(randVal.Length)];
                fire3txt.text = random;

            }
            //Fire2 is a String
            else
            {
                //Fire3 is a Boolean
                string[] randVal = new[] { "True","False" };
                var random = randVal[rand.Next(randVal.Length)];
                fire3txt.text = random;

            }

        }
        //Fire1 is a String
        else
        {
            //Fire2 is a Boolean
            if (fire2txt.text == "True" || fire2txt.text == "False")
            {
                //Fire3 is an Int
                string[] randVal = new[] {"1", "127", "30", "55", "42" };
                var random = randVal[rand.Next(randVal.Length)];
                fire3txt.text = random;
            }
            //Fire2 is an Int
            else if (fire2txt.text.Any(char.IsDigit))
            {
                //Fire3 is a Boolean
                string[] randVal = new[] { "False", "True" };
                var random = randVal[rand.Next(randVal.Length)];
                fire3txt.text = random;

            }
        

        }


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Image pk = GameObject.Find("Fire3").GetComponent<Image>();
        

        Text txt = GameObject.Find("Fire3Text").GetComponent<Text>();

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