using UnityEngine;
using UnityEngine.UI;

public class ChangeUIButton : MonoBehaviour
{
    public GameObject BeforeScreen;
    public GameObject AfterScreen;

    void Start()
    {
        if (AfterScreen != null && BeforeScreen != null)
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(() =>
            {
                if (AfterScreen == null)
                {
                    BeforeScreen.SetActive(false);
                }
                else if (BeforeScreen == null)
                {
                    AfterScreen.SetActive(true);
                }
                else
                {
                    BeforeScreen.SetActive(false);
                    AfterScreen.SetActive(true);
                }
            });
        }
    }
}
