using UnityEngine;
using TMPro;
using NUnit.Framework.Internal;

public class DialogHomeReturnSceneScript : MonoBehaviour
{

    private TextMeshProUGUI dialog;
    private RectTransform rectTransform;

    private GameMasterHomeReturnSceneScript gm;

    void Start()
    {
        dialog = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();

        gm = FindAnyObjectByType<GameMasterHomeReturnSceneScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = rectTransform.transform.position;

        if (gm.getIsTextAnimation())
        {
            rectTransform.transform.position = new Vector2(pos.x, pos.y + 0.01f);

            if (pos.y > 5)
            {
                gm.setIsTextAnimation(false);
            }
        }
    }
}
