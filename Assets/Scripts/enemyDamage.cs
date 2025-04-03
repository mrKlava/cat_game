using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDamage : MonoBehaviour
{
    public playerHealth pHealth;
    public int damage;
    public bool playerIsDead = false;
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
            pHealth.currentLives -= damage;
        }
        if (pHealth.currentLives <= 0)
        {
            Debug.Log("Cat has fainted !");
            // Reloads the currently active scene
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
            playerIsDead = true;
        }
        Debug.Log("collision ! Damage: " + damage);
    }
}
