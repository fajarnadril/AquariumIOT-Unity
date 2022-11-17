using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SendData : MonoBehaviour
{
    public string namaSensor;
    //public string urlNyala;
    //public string urlMati;

    public void Nyala(string urlNyala)
    {
        StartCoroutine(GetRequest(urlNyala));
    }

    public void Mati(string urlMati)
    {
        StartCoroutine(GetRequest(urlMati));
    }

    IEnumerator GetRequest (string url)
    {
        using (UnityWebRequest webReq = UnityWebRequest.Get(url))
        {
            yield return webReq.SendWebRequest();
        }
    }



}
