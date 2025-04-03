using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;

public class DialogBbqSceneScript : MonoBehaviour
{

    private TextMeshProUGUI dialog;
    private RectTransform rectTransform;

    private GameMasterBbqSceneScript gm;
 
    void Start()
    {
        dialog = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();

        gm = FindAnyObjectByType<GameMasterBbqSceneScript>();

        gm.setIsTextAnimation(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rectTransform.transform.position;

        rectTransform.transform.position = new Vector2(pos.x, pos.y + 0.01f);


        Debug.Log(pos.y);


        if (pos.y > 9)
        {
            gm.setIsCatAnimation(true);
        }

        if (pos.y > 15)
        {
            gm.setIsTextAnimation(false);
        }
    }
}
