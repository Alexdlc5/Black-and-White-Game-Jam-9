using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading_In : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (GetComponent<RawImage>().color.a <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<RawImage>().color = new Color(GetComponent<RawImage>().color.r, GetComponent<RawImage>().color.g, GetComponent<RawImage>().color.b, GetComponent<RawImage>().color.a - Time.deltaTime / 10);
        }
       
    }
}
