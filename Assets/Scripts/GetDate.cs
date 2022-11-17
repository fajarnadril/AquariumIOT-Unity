using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public struct DateData
{
    public string abbreviation;
    public string client_ip;
    public string datetime;
    public int day_of_week;
    public int day_of_year;
    public bool dst;
    public object dst_from;
    public int dst_offset;
    public object dst_until;
    public int raw_offset;
    public string timezone;
    public int unixtime;
    public string utc_datetime;
    public string utc_offset;
    public int week_number;
}
public class GetDate : MonoBehaviour
{

    public string url;
    int i;
    // Start is called before the first frame update

    void Start()
    {


        StartCoroutine(GetRequest(url));
    }
    void FixedUpdate()
    {
        i++;
        if (i % 1000 == 0) StartCoroutine(GetRequest(url));

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
                
               

                string json;
                json = webRequest.downloadHandler.text;

                DateData dateData;
                dateData = JsonUtility.FromJson<DateData>(json);
                string time = dateData.datetime.Substring(11,15);
                //Debug.Log(time.Substring(0,5));

            }

        }
    }

}
