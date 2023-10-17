using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsTextControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject _player;
    private int count = 0;
    [SerializeField] private int totalCoins = 0;
    private PlayerController _playerController;
    void Start()
    {
        coinText = coinText.GetComponent<TextMeshProUGUI>();
        _playerController = _player.GetComponent<PlayerController>();

        count = _playerController.currentCoin;
        coinText.text = "Coins: " + _playerController.currentCoin + "/" + totalCoins;
    }

    // Update is called once per frame
    void Update()
    {
        if(count!= _playerController.currentCoin)
        {
            count = _playerController.currentCoin;
            coinText.text = "Coins: " + _playerController.currentCoin + "/" + totalCoins;
        }
    }
}
