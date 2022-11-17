using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Pompa : MonoBehaviour
{
    public string urlNyala, urlMati;
    public int durationToOff;
    public Button btn;
    public Animator anim;
    public Button btnHome;
    
    private void Start()
    {
        anim.enabled = false;

    }
    public void ThePompaIsiAir()
    {
        StartCoroutine(GetRequest(urlNyala,0,false,true,false));    
        StartCoroutine(GetRequest(urlMati,durationToOff,true,false,true));
    }

    IEnumerator GetRequest(string url, int duration, bool btnOnOff, bool animOnOff, bool boolOnOffHome)
    {
 
        yield return new WaitForSeconds(duration);
        btnHome.interactable = false;
        btn.interactable = btnOnOff;
        anim.enabled = animOnOff;
        btnHome.interactable = boolOnOffHome;

        using (UnityWebRequest webReq = UnityWebRequest.Get(url))
        {
            
            yield return webReq.SendWebRequest();
        }
    }
}
