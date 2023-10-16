using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AnalyticsTestforCoin : MonoBehaviour
{
    [SerializeField] private string CoinsURL;
    [SerializeField] private string SpikeURL;

    private long _sessionID;
    private int _testInt;
    private int currCoins;

    private float _playerX;
    private float _playerY;

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
            SendCoin();
        }
        
    }

    public void SendCoin()
    {
        // Assign variables

        StartCoroutine(PostCoin(_sessionID.ToString(), _testInt.ToString()));
    }

    public void SendSpike(float posX, float posY)
    {
        Debug.Log("Sent Spike Form");
        StartCoroutine(PostSpike(posX.ToString(), posY.ToString()));
    }

    private IEnumerator PostCoin(string sessionID, string testInt)
    {
        // Create the form and enter reponses;
        WWWForm form = new WWWForm();
        form.AddField("entry.439495272", sessionID);
        form.AddField("entry.306375043", testInt);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(CoinsURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log("Coin Form upload complete!");

            }

        }
    }

    private IEnumerator PostSpike(string playerX, string playerY)
    {
        // Create the form and enter reponses;
        WWWForm form = new WWWForm();
        form.AddField("entry.493098765", playerX);
        form.AddField("entry.189242426", playerY);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(SpikeURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log("Spike Form upload complete!");

            }

        }
    }

}




