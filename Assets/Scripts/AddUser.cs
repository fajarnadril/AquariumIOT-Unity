using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using TMPro;



public class AddUser : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button btnStarted;
    public GameObject panelUserNameKosong;
    string firstChar;

    void Start()
    {
        panelUserNameKosong.SetActive(false);
    }
    public void Add_User()
    {

        if (string.IsNullOrEmpty(inputField.text) || inputField.text.Length < 7)
        {
            //Debug.Log("inputField EMPTY");
            panelUserNameKosong.SetActive(true);
        }
        else if (!string.IsNullOrEmpty(inputField.text) && inputField.text.Length >= 7)
        {
            //Debug.Log("inputField ISI");
            GameManager.Instance.canvasGo[0].SetActive(false);

            firstChar = inputField.text.Substring(0, 1).ToUpper();
            GameManager.Instance.userName = inputField.text;
            
            GameManager.Instance.txtUserName.text = char.ToUpper(GameManager.Instance.userName[0]) + GameManager.Instance.userName.Substring(1, 6);
            GameManager.Instance.txtUserNameLogo.text = firstChar;

            GameManager.Instance.SaveToJson();
            GameManager.Instance.allCanvasOff(1);
        }
    }



}
