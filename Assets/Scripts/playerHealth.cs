using TMPro;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public TextMeshProUGUI lives;
    public int currentLives;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //later on maybe reference the gamemaster data to get the current lives
        currentLives = 9;
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = currentLives.ToString();
    }


}
