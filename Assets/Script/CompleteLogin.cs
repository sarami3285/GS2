using UnityEngine;

public class CompleteLogin : MonoBehaviour
{
    public GameObject LoginCanvas;
    public GameObject PlayCanvas;
    public AudioSource MainBGM;

    private void Start()
    {
        MainBGM = GetComponent<AudioSource>();
    }

    public void LoggedIn()
    {
        LoginCanvas.SetActive(false);
        PlayCanvas.SetActive(true);
        MainBGM.Play();
    }
}
