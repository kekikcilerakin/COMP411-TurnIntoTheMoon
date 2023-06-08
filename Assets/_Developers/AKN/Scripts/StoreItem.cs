using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    public void Item1Clicked()
    {
        if (!HighScoreHolder.Instance.hatOneEquipped)
        {
            HighScoreHolder.Instance.playerHatOne.SetActive(true);
            HighScoreHolder.Instance.playerHatTwo.SetActive(false);
            HighScoreHolder.Instance.playerHatThree.SetActive(false);
            Debug.Log("Item 1 equipped");
            HighScoreHolder.Instance.hatOneEquipped = true;
            HighScoreHolder.Instance.hatTwoEquipped = false;
            HighScoreHolder.Instance.hatThreeEquipped = false;
        }
    }
    public void Item2Clicked()
    {
        if (!HighScoreHolder.Instance.hatTwoEquipped)
        {
            HighScoreHolder.Instance.playerHatOne.SetActive(false);
            HighScoreHolder.Instance.playerHatTwo.SetActive(true);
            HighScoreHolder.Instance.playerHatThree.SetActive(false);
            Debug.Log("Item 2 equipped");
            HighScoreHolder.Instance.hatOneEquipped = false;
            HighScoreHolder.Instance.hatTwoEquipped = true;
            HighScoreHolder.Instance.hatThreeEquipped = false;
        }

    }
    public void Item3Clicked()
    {
        if (!HighScoreHolder.Instance.hatThreeEquipped)
        {
            HighScoreHolder.Instance.playerHatOne.SetActive(false);
            HighScoreHolder.Instance.playerHatTwo.SetActive(false);
            HighScoreHolder.Instance.playerHatThree.SetActive(true);
            Debug.Log("Item 3 equipped");
            HighScoreHolder.Instance.hatOneEquipped = false;
            HighScoreHolder.Instance.hatTwoEquipped = false;
            HighScoreHolder.Instance.hatThreeEquipped = true;
        }
        
    }
}
