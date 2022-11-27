using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class DataUploader : MonoBehaviour
{
    public enum UploadStatus
    {
        notStarted,
        started,
        successful,
        error,
        completed
    }
    public UploadStatus uploadStatus;

    public void Start()
    {
        uploadStatus = UploadStatus.notStarted;
    }

    public void UploadFile()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        uploadStatus = UploadStatus.started;

        string path = Application.dataPath + "/blabla.jpg";
        WWWForm form = new WWWForm();
        UnityWebRequest dataFile = UnityWebRequest.Get(path);
        yield return dataFile.SendWebRequest();
        form.AddField("title", "somedata2");
        form.AddField("content", "somedata");
        form.AddBinaryData("image", dataFile.downloadHandler.data, Path.GetFileName(path));
       // form.AddBinaryData("file", bytes, "hehe.png", "image/png")
        UnityWebRequest req = UnityWebRequest.Post("https://anno.herokuapp.com/api/posts", form);
        yield return req.SendWebRequest();

        uploadStatus = UploadStatus.completed;

        Debug.Log("SERVER: " + req.downloadHandler.text); // server response

        if (req.isHttpError || req.isNetworkError || !(req.downloadHandler.text.Contains("FILE OK")))
            uploadStatus = UploadStatus.error;
        else
            uploadStatus = UploadStatus.successful;

        yield break;
    }
}