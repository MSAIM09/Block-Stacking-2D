using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("musciVolume"))
        {
            PlayerPrefs.SetFloat("musciVolume", 1);
            load();
        }

        else
        {
            load();
        }
    }

    // Update is called once per frame
    public void chanheVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musciVolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musciVolume", volumeSlider.value);

    }


















}
