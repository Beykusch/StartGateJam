using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public GameObject credits;
    public GameObject backButton;

    public void StartButton()
    {
        SceneManager.LoadScene("Cyber");
    }

    public void Credits()
    {
        credits.SetActive(true);
        backButton.SetActive(true);
    }
}
