using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().name == "LevelOne")
            SceneManager.LoadScene("LevelTwo");
        else
        {
            SceneManager.LoadScene("LevelOne");
        }
    }
}
