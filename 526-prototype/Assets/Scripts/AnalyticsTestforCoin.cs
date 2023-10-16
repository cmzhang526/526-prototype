using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AnalyticsTestforCoin : MonoBehaviour
{
    [SerializeField] private string URL;

    private long _sessionID;
    private int _testInt;
    private bool _testBool;
    private float _testFloat;
    private int currCoins;

    public PlayerController playerControllerforCoin;

    private void Awake()
    {
        // Assign sessionID to identify playtests
        double epochTime = System.Math.Round((System.DateTime.Now - new System.DateTime(1970, 1, 1)).TotalMilliseconds);
        currCoins = playerControllerforCoin.currentCoin;
        _sessionID = (long)epochTime;

        
    }

    private void Update()
    {
        if (currCoins != playerControllerforCoin.currentCoin)
        {
            currCoins = playerControllerforCoin.currentCoin;
            _testInt = currCoins;
            Send();
        }
        
    }


    public void Send()
    {
        // Assign variables
        //_testInt = Random.Range(0, 101);
        
        _testBool = true;
        _testFloat = Random.Range(0.0f, 10.0f);

        StartCoroutine(Post(_sessionID.ToString(), _testInt.ToString(),
            _testBool.ToString(), _testFloat.ToString()));
    }

    private IEnumerator Post(string sessionID, string testInt,
        string testBool, string testFloat)
    {
        // Create the form and enter reponses;
        WWWForm form = new WWWForm();
        form.AddField("entry.439495272", sessionID);
        form.AddField("entry.306375043", testInt);
        form.AddField("entry.1751234061", testBool);
        form.AddField("entry.908372766", testFloat);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log("Form upload complete!");

            }

        }
    }

}




