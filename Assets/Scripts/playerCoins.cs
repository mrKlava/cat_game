using TMPro;
using UnityEngine;

public class playerCoins : MonoBehaviour
{
    public TextMeshProUGUI Coins;
    public int currentCoins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //at some point grab currentcoins from gamemaster
        currentCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Coins.text = currentCoins.ToString();
    }
}
