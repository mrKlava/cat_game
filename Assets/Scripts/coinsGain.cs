using UnityEngine;
using UnityEngine.SceneManagement;

public class coinsGain : MonoBehaviour
{
    public playerCoins pCoins;
    public GameObject coinSprite;
    public int coinValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            pCoins.currentCoins += coinValue;
            DestroyGameObject();
            
        }
        Debug.Log("Coin obtained ! Coin value: " + coinValue);
    }

    void DestroyGameObject()
    {
        // Kills the game object in X seconds after loading the object
        Destroy(gameObject);
    }
}
