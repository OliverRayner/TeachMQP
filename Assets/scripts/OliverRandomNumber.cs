using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OliverRandomNumber : MonoBehaviour
{
    public Text rando;

    // Start is called before the first frame update
    void Start()
    {
        rValue(11);
    }

    void rValue(int maxInt)
    {
        int randomize = Random.Range(1, maxInt);
        rando.text = randomize.ToString();
    }
}