using UnityEngine;

public class GameMasterSceneOneScript : MonoBehaviour
{
    private bool isCatAnimation = false;
    private bool isTextAnimation = false;

    public void setIsTextAnimation(bool state) { isTextAnimation = state; }
    public void setIsCatAnimation(bool state) { isCatAnimation = state; }

    public bool getIsCatAnimation() { return isCatAnimation; }
    public bool getIsTextAnimation() { return isTextAnimation; }
}
