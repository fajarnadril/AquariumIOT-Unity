using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class GetData : MonoBehaviour
{
    [Header("Sensor")]
    public string nameSensor;
        

    [Header("Get URL")]
    public string urlRestApi;
    string strValue;
    int intValue;
    int g = 0;
    public int durationGet;

    public TextMeshProUGUI[] txtValues;
    [Header("Circle Color")]
    public RawImage[] rawImageCircle;
    public Texture circleBlue, circleRed, circleBlack;
    public int intRangeRed1, intRangeRed2, intRangeBlack1,
               intRangeBlack2, intRangeBlue1, intRangeBlue2;
    void Start()
    {
        StartCoroutine(GetRequest(urlRestApi));
    }

    public void CircleColor()
    {
        if (intValue >= intRangeRed1 && intValue <= intRangeRed2)
        {
            for (int i =0; i < rawImageCircle.Length; i++)
            {
                rawImageCircle[i].texture = circleRed;
            }
        }
        else if (intValue >= intRangeBlack1 && intValue <= intRangeBlack2)
        {
            for (int i = 0; i < rawImageCircle.Length; i++)
            {
                rawImageCircle[i].texture = circleBlack;
            }
        }
        else if (intValue >= intRangeBlue1 && intValue <= intRangeBlue2)
        {
            for (int i = 0; i < rawImageCircle.Length; i++)
            {
                rawImageCircle[i].texture = circleBlue;
            }
        } 
    }


    void FixedUpdate()
    {
        g++;
        if (g % durationGet == 0) 
        {
            StartCoroutine(GetRequest(urlRestApi));  
        }

    }


    IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                //Debug.Log("error");
            }
            else
            {
                strValue = webRequest.downloadHandler.text;
                int.TryParse(strValue, out intValue);
                CircleColor();
                for (int i = 0; i < txtValues.Length; i++)
                {
                    txtValues[i].text = strValue;
                }              
            }
        }
    }
        


    






}