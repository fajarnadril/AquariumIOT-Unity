using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string userName;
    public GameObject[] canvasGo;
    public TextMeshProUGUI txtUserName;
    public TextMeshProUGUI txtUserNameLogo;


    void Awake()
    {
        Instance = this;
        //Debug.Log(Application.persistentDataPath);
    }


    public void allCanvasOff (int idCanvasOn)
    {  
        for (int i = 0; i < canvasGo.Length; i++)
        {
            canvasGo[i].SetActive(false);
        }
        StartCoroutine(newPanel(idCanvasOn));
        

        
    }

    IEnumerator newPanel (int idCanvasOn)
    {
        canvasGo[6].SetActive(true);
        canvasGo[idCanvasOn].SetActive(true);
        yield return new WaitForSeconds(1);
        canvasGo[6].SetActive(false);
        
    }

    public void SaveToJson()
    {
        UserData data = new UserData();
        data.userNameData = userName;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/UserNameJson.json", json);
        //File.WriteAllText(Application.dataPath+ "/UserNameJson.json", json);
    }

    public void LoadFromJson()
    {
        string json;
        json = File.ReadAllText(Application.persistentDataPath + "/UserNameJson.json");
        UserData data = JsonUtility.FromJson<UserData>(json);
        userName = data.userNameData;
        string firstChar = userName.Substring(0, 1).ToUpper();
        txtUserName.text = char.ToUpper(GameManager.Instance.userName[0]) + GameManager.Instance.userName.Substring(1, 6);
        txtUserNameLogo.text = firstChar;
    }


    void Start()
    {

        if (File.Exists(Application.persistentDataPath + "/UserNameJson.json"))
        {
            //ada file json username
            LoadFromJson();
            allCanvasOff(1);

        }
        else
        {
            allCanvasOff(0);
        }
    }

    public void OpenURl (string url)
    {
        Application.OpenURL(url);
    }
}
