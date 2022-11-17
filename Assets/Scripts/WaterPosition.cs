using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPosition : MonoBehaviour
{
    public float range;
    public void WaterPosPlus()
    {
        if (transform.localScale.y >= 1 && transform.localScale.y <= 4)
        {
            transform.localScale = new Vector3(transform.localScale.x
 , transform.localScale.y + range, transform.localScale.z);
        }

        else
        {
            transform.localScale = new Vector3(transform.localScale.x
            , 4, transform.localScale.z);
        }

    }

    public void WaterPosMinus()
    {
        if (transform.localScale.y >= 1 && transform.localScale.y <= 4)
        {
            transform.localScale = new Vector3(transform.localScale.x
            , transform.localScale.y - range, transform.localScale.z);
        }

        else
        {
            transform.localScale = new Vector3(transform.localScale.x
            , 1, transform.localScale.z);
        }


    }

      

    

}
