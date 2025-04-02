using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;

public class DialogScript : MonoBehaviour
{

    private TextMeshProUGUI dialog;
    private RectTransform rectTransform;

    private GameMasterSceneOneScript gm;
 
    void Start()
    {
        dialog = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();

        gm = FindAnyObjectByType<GameMasterSceneOneScript>();

        gm.setIsTextAnimation(true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rectTransform.transform.position;

        rectTransform.transform.position = new Vector2(pos.x, pos.y + 0.01f);

        if (pos.y > 17)
        {
            gm.setIsCatAnimation(true);
        }

        if (pos.y > 23)
        {
            gm.setIsTextAnimation(false);
        }
    }
}
