using UnityEngine;

public class healthGain : MonoBehaviour
{
    public playerHealth pHealth;
    //public GameObject potionSprite;
    public Lerp_Follow_Script lerpCollect;
    public int healthBonus;
    public bool isTrigger = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (pHealth.currentLives >= 9)
            {
                //DestroyObjectDelayed();
                lerpCollect.isCollected = false;
                pHealth.currentLives += 0;
            }
            else
            {
                lerpCollect.isCollected = true;
                pHealth.currentLives += healthBonus;
            //DestroyObjectDelayed();
            }
    }
        Debug.Log("Health obtained ! Health Bonus: " + healthBonus);
    }

    //void DestroyObjectDelayed()
    //{
    //    // Kills the game object in 5 seconds after loading the object
    //    Destroy(gameObject);
    //}
}
