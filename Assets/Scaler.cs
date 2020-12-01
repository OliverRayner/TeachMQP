using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        Image s3 = GameObject.Find("strength-3").GetComponent<Image>();

        SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();

        Debug.Log(s3.transform.localPosition);

        spriteR.transform.localPosition = new Vector3(s3.transform.localPosition.x, s3.transform.localPosition.y, s3.transform.localPosition.z);

    }

}
