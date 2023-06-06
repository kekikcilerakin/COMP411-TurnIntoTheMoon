using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsLevelTwoUnlocked : MonoBehaviour
{
    public Sprite unlockedIcon;
    public Sprite lockedIcon;

    private void OnEnable()
    {
        if (HighScoreHolder.Instance.LevelTwoUnlocked)
        {
            GetComponent<Image>().sprite = unlockedIcon;
            GetComponentInParent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Image>().sprite = lockedIcon;
            GetComponentInParent<Button>().interactable = false;

        }
    }
}
