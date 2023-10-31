using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnalyticsTestforCheckpoint : MonoBehaviour
{
    [SerializeField] private string CoinsURL; //https://docs.google.com/forms/u/1/d/e/1FAIpQLSebOn2bOdAEFXFa18xCbGScnZf4FAML6fYEpaUlhhBBf2tqRQ/formResponse
    [SerializeField] private string SpikeURL; //https://docs.google.com/forms/u/0/d/e/1FAIpQLSciKoomFaXT1B-S4GDQBDwPTuo-vDvQlZubFPJHq7DFcEaZVQ/formResponse
    [SerializeField] private string CheckpointURL; //https://docs.google.com/forms/u/1/d/e/1FAIpQLScOzAm-Ay8qSlSpc-YguA8q0HWZVIxzEIAaUhBHkAMMzfz0rA/formResponse

    private long _sessionID;
    private int _testInt;
    private int currCoins;

    private float _playerX;
    private float _playerY;

    private PlayerController playerControllerforCoin = null;

    private void Awake()
    {
        // Assign sessionID to identify playtests
        double epochTime = System.Math.Round((System.DateTime.Now - new System.DateTime(1970, 1, 1)).TotalMilliseconds);
        playerControllerforCoin = GetComponent<PlayerController>();
        currCoins = playerControllerforCoin.currentCoin;
        _sessionID = (long)epochTime;

        //test
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        /*
        if (currCoins != playerControllerforCoin.currentCoin)
        {
            currCoins = playerControllerforCoin.currentCoin;
            _testInt = currCoins;
            SendCoin();
        }
        */
        //SendCheckpoint();
    }
    /*
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
    */
    public void SendCheckpoint(float checposX, float checposY)
    {
        // Assign variables
        Debug.Log("Sent Checkpoint Form");
        StartCoroutine(PostCheckpoint(checposX.ToString(), checposY.ToString()));
    }
    /*
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
    */
    private IEnumerator PostCheckpoint(string checkX, string checkY)
    {
        // Create the form and enter reponses;
        WWWForm form = new WWWForm();
        form.AddField("entry.414465238", checkX);
        form.AddField("entry.1197266084", checkY);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(CheckpointURL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);

            }
            else
            {
                Debug.Log("Checkpoint Form upload complete!");

            }

        }
    }

}




