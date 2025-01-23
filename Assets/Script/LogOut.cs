using UnityEngine;
using UnityEngine.SceneManagement;

public class logOut : MonoBehaviour
{
    public void SceneReloading()
    {
        SceneManager.LoadScene("MainScene");
    }
}
