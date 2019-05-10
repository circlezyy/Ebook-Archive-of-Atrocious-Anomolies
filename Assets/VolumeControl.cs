using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    private IUserInput inputStrategy;
    private IUserInput keyboardInput;

    public GameObject musicLevel;
    public GameObject sfxLevel;

    private float timedelay = 0;
    private float musicVolume = 0.5f;
    private float sfxVolume = 0.5f;

    void Start()
    {
        keyboardInput = new UserKeyboardInput();
        inputStrategy = keyboardInput;
        musicLevel.SetActive(false);
        sfxLevel.SetActive(false);
    }

    void Update()
    {
        GetInput();
        HideComponents();
    }

    private void HideComponents()
    {
        if (Time.time > timedelay)
        {
            musicLevel.SetActive(false);
            sfxLevel.SetActive(false);
        }
    }

    private void GetInput()
    {
        switch (inputStrategy.GetInput())
        {
            case "musicUp":
                musicLevel.SetActive(true);
                if (musicVolume < 1)
                    musicVolume += 0.01f;

                timedelay = Time.time + 3;
                musicLevel.GetComponent<Text>().text = "Music Level: " + Mathf.Floor(musicVolume * 100);
                AudioManager.Instance.ChangeMusicVolume(musicVolume);
                break;
            case "musicDown":
                musicLevel.SetActive(true);
                if (musicVolume > 0)
                    musicVolume -= 0.01f;
                timedelay = Time.time + 3;
                musicLevel.GetComponent<Text>().text = "Music Level: " + Mathf.Floor(musicVolume * 100);
                AudioManager.Instance.ChangeMusicVolume(musicVolume);
                break;
            case "sfxUp":
                sfxLevel.SetActive(true);
                if (sfxVolume < 1)
                    sfxVolume += 0.01f;
                sfxLevel.GetComponent<Text>().text = "SFX Level: " + Mathf.Floor(sfxVolume * 100);
                AudioManager.Instance.ChangeSFXVolume(sfxVolume);
                timedelay = Time.time + 3;
                break;
            case "sfxDown":
                sfxLevel.SetActive(true);
                if (sfxVolume > 0)
                    sfxVolume -= 0.01f;
                sfxLevel.GetComponent<Text>().text = "SFX Level: " + Mathf.Floor(sfxVolume * 100);
                AudioManager.Instance.ChangeSFXVolume(sfxVolume);
                timedelay = Time.time + 3;
                break;
        }
    }


}
