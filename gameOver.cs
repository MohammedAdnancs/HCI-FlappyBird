using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject Death;

    private void Start()
    {
        Death.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Death.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
