using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnalyticsTestforCoin : MonoBehaviour
{
    [SerializeField] private string CoinsURL; //https://docs.google.com/forms/u/0/d/e/1FAIpQLSd33S19khipbCtDUnQYSfvidNHg8HBRK-BNOgA8WlDKU77QYg/formResponse
    [SerializeField] private string SpikeURL; //https://docs.google.com/forms/u/0/d/e/1FAIpQLSemguIxLw_fNak-MTN21GpAiJRyMkFSEYpxVbIvXPR9kwtn6Q/formResponse
    [SerializeField] private string TimeURL; //https://docs.google.com/forms/u/0/d/e/1FAIpQLSfDcgjOVmgtRhwrWizsM1YIhD_3l4LyiAXK_azBGMAWy7tuAg/formResponse

    private long _sessionID;
    private int _testInt;
    private int currCoins;

    private float _playerX;
    private float _playerY;

    private string _currLevel;

    private float _pastTime;
    private float _currTime;

    private PlayerController playerControllerforCoin = null;

    private void Awake()
    {
        // Assign sessionID to identify playtests
        double epochTime = System.Math.Round((System.DateTime.Now - new System.DateTime(1970, 1, 1)).TotalMilliseconds);
        playerControllerforCoin = GetComponent<PlayerController>();
        currCoins = playerControllerforCoin.currentCoin;
        _sessionID = (long)epochTime/10000;

        //test
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        _currTime = Time.time;
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

    public void SendChckpointTime(float _Time)
    {
        Debug.Log("Sent Checkpoint Time Form");
        float tempTime = UpdateTimeData(_Time);
        StartCoroutine(PostCheckpointTime(_sessionID.ToString(), _testInt.ToString(), tempTime.ToString()));
    }

    private float UpdateTimeData(float _Time)
    {
        _pastTime = _Time - _currTime;
        _currTime = Time.time;
        return _pastTime;
    }

    private IEnumerator PostCoin(string sessionID, string testInt)
    {
        // Create the form and enter reponses;
        WWWForm form = new WWWForm();
        form.AddField("entry.961188245", sessionID);
        form.AddField("entry.1775649406", testInt);

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
        form.AddField("entry.773412834", playerX);
        form.AddField("entry.955899894", playerY);

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

    private IEnumerator PostCheckpointTime(string sessionID, string checkpointID, string _Time)
    {
        // Create the form and enter reponses;
        WWWForm form = new WWWForm();
        form.AddField("entry.359554342", sessionID);
        form.AddField("entry.132313672", checkpointID);
        form.AddField("entry.589853041", _Time);

        // Send responses and verify result
        using (UnityWebRequest www = UnityWebRequest.Post(TimeURL, form))
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




