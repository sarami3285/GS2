using UnityEngine;

public class CompleteLogin : MonoBehaviour
{
    public GameObject LoginCanvas;
    public GameObject PlayCanvas;

    public void LoggedIn()
    {
        LoginCanvas.SetActive(false);
        PlayCanvas.SetActive(true);
    }
}
