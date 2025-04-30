using UnityEngine;

public class Lerp_Follow_Script : MonoBehaviour
{
    public Transform targetEndPosition;  // Where the coin should move after collection
    private Vector3 startPosition;       // Where the coin starts from
    public float speed = 1f;              // Time it takes to reach the target
    private float elapsedTime;
    public bool isCollected = false;    // Only move when collected

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isCollected)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / speed;

            transform.position = Vector3.Lerp(startPosition, targetEndPosition.position, percentageComplete);

            //Destroy or disable after reaching the target
            if (percentageComplete >= 1f)
            {
                Destroy(gameObject); //desroying
                //gameObject.SetActive(false); //disabling
            }
        }
    }

    //public void Collect()
    //{
    //    isCollected = true;
    //    elapsedTime = 0f; // reset timer
    //    startPosition = transform.position; // in case it moves before collection
    //}
}
