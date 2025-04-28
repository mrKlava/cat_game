using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class HandleLoadButtonScript : MonoBehaviour, IPointerDownHandler
{
    private GameMasterScript gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMasterScript>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Load pressed");

        SceneManager.LoadScene(gm.GetCurrentScene());
    }
}
