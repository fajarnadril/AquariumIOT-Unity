using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

public struct DateData
{
    //public string abbreviation;
    //public string client_ip;
    //public string datetime;
    //public int day_of_week;
    //public int day_of_year;
    //public bool dst;
    //public object dst_from;
    //public int dst_offset;
    //public object dst_until;
    //public int raw_offset;
    //public string timezone;
    //public int unixtime;
    //public string utc_datetime;
    //public string utc_offset;
    //public int week_number;
    public string a;
    public string b;
    public string c;
}
public class GetDate : MonoBehaviour
{

    public string url;
    int i;
    // Start is called before the first frame update

    void Start()
    {
        //StartCoroutine(GetRequest("https://anno.herokuapp.com/api/posts/1"));

        StartCoroutine(Upload5());
        //StartCoroutine(GetRequest());
        Debug.Log("a=" + File.ReadAllBytes(Application.dataPath + "/blabla.jpg"));
        // Debug.Log("b"+File.ReadAllBytes(Application.persistentDataPath +"/blabla.jpg"));
    }
    void FixedUpdate()
    {
        //i++;
        //if (i % 1000 == 0) StartCoroutine(GetRequest(url));

    }


    IEnumerator GetRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://anno.herokuapp.com/api/posts"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("error");
               
            }
            else
            {
                
               

                string json;
                json = webRequest.downloadHandler.text;

                //DateData dateData;
                //dateData = JsonUtility.FromJson<DateData>(json);
                ////string time = dateData.datetime.Substring(11,15);
                ////Debug.Log(time.Substring(0,5));
                Debug.Log(json);

            }

        }
    }



    IEnumerator Upload4()
    {
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", File.ReadAllBytes(Application.dataPath + "/blabla.jpg"), "blabla.jpg");
        form.AddField("title", "17ac4c482dcdd");
        form.AddField("content","ac4c482dcdd");

        UnityWebRequest www = UnityWebRequest.Post("https://anno.herokuapp.com/api/posts/", form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete! " + www.downloadHandler.text);

        }
    }


    IEnumerator Upload5()
    {
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", File.ReadAllBytes(Application.persistentDataPath+"/blabla.jpg"));
        form.AddField("title", "hahah");
        form.AddField("content", "fajaddddrrrr");
        
        UnityWebRequest request = UnityWebRequest.Post("https://anno.herokuapp.com/api/posts", form);
        yield return request.SendWebRequest();
        print("request completed with code: " + request.responseCode);
        if (request.isNetworkError)
        {
            print("Error: " + request.error);
        }
        else
        {
            print("Request Response: " + request.downloadHandler.text);
        }
    }

    public IEnumerator UploadAFile()
    {

        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;
        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();
        //This basically takes a screenshot

        byte[] bytes = tex.EncodeToPNG(); //Can also encode to jpg, just make sure to change the file extensions down below
        Destroy(tex);

        // Create a Web Form
        var form = new WWWForm();
        
        form.AddBinaryData("file", bytes, "hehe.png", "image/png");
        form.AddField("title", "fajar");
        form.AddField("content", "fajarrrr");

        WWW w = new WWW("https://anno.herokuapp.com/api/posts", form);
        yield return w;

        if (w.error != null)
        {
            Debug.Log(w.error);
        }
        else
        {
            Debug.Log(w.text);
        }
    }

}
