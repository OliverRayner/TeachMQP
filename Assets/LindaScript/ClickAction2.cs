using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using Random = System.Random;
public class ClickAction2 : MonoBehaviour, IPointerClickHandler
{
    void Start()
    {


        Text fire1txt = GameObject.Find("Fire1Text").GetComponent<Text>();

        Text fire2txt = GameObject.Find("Fire2Text").GetComponent<Text>();

        Random rand = new Random();

        if (fire1txt.text == "True" || fire1txt.text == "False")
        {
            string[] randVal = new[] { "\"Dog\"", "\"Cat\"", "\"Car\"", "\"School\"", "\"Duck\"", "\"Barn\"", "\"True\"", "\"False\"", "1", "127", "30", "55", "42" };
            var random = randVal[rand.Next(randVal.Length)];
            fire2txt.text = random;

        }

        else if (fire1txt.text.Any(char.IsDigit))
        {
            string[] randVal = new[] { "\"Dog\"", "\"Cat\"", "\"Car\"", "\"School\"", "\"Duck\"", "\"Barn\"", "\"True\"", "\"False\"", "False", "True"};
            var random = randVal[rand.Next(randVal.Length)];
            fire2txt.text = random;

        }

        else
        {
            string[] randVal = new[] { "False", "True", "1", "127", "30", "55", "42" };
            var random = randVal[rand.Next(randVal.Length)];
            fire2txt.text = random;

        }


    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Image pk = GameObject.Find("Fire2").GetComponent<Image>();

        Text txt = GameObject.Find("Fire2Text").GetComponent<Text>();

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
