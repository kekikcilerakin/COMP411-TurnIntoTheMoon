using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    public Sprite volumeOnImage;
    public Sprite volumeOffImage;

    public void OnVolumeClicked()
    {
        if (AudioManager.Instance.isVolumeOn)
        {
            AudioManager.Instance.GetComponent<AudioSource>().mute = true;
            GetComponent<Image>().sprite = volumeOffImage;
            AudioManager.Instance.isVolumeOn = false;
        }
        else
        {
            AudioManager.Instance.GetComponent<AudioSource>().mute = false;
            GetComponent<Image>().sprite = volumeOnImage;
            AudioManager.Instance.isVolumeOn = true;
        }
    }
}
