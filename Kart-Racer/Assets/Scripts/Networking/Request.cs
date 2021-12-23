using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;


public class Request : MonoBehaviour
{


    public  void GetRequest(Action<string> successCallback)
    {
        StartCoroutine(GetRequestCoroutine("http://127.0.0.1:3000/db/get/all", successCallback));
    }

    public IEnumerator GetRequestCoroutine(string uri, Action<string> successCallback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    // Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    successCallback?.Invoke(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

}
