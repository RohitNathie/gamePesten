using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public AudioSource music;
    public Button musicButton;
    public Text buttonText;

    private bool isMuted = false;
    private bool isFirstClick = true;

    private void Start()
    {
        musicButton.onClick.AddListener(ToggleMusic);
        UpdateButtonText();
    }

    private void ToggleMusic()
    {
        if (isFirstClick)
        {
            isFirstClick = false;
            isMuted = true;
            music.Pause();
        }
        else
        {
            isMuted = !isMuted;

            if (isMuted)
            {
                music.Pause();
            }
            else
            {
                music.Play();
            }
        }

        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (isMuted)
        {
            buttonText.text = "Muziek: Uit";
        }
        else
        {
            buttonText.text = "Muziek: Aan";
        }
    }
}