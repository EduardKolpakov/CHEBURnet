using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    public GameObject[] hearts;
    public Transform soundSource1;
    public Transform soundSource2;
    private AudioSource sound1;
    private AudioSource sound2;
    private int lives;
    public static LivesScript singlton;
    void Awake()
    {
        // Делаем этот объект единственным экземпляром
        if (singlton == null)
        {
            singlton = this;
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликаты
        }
    }
    void Start()
    {
        if (soundSource1 != null)
        {
            sound1 = soundSource1.GetComponent<AudioSource>();
        }
        if (soundSource2 != null)
        {
            sound2 = soundSource2.GetComponent<AudioSource>();
        }
        lives = hearts.Length;
        UpdateHeartsVisibility();
    }
    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            if (sound1 != null)
            {
                sound1.Play();
            }
            StartCoroutine(VignetteSCript.ToggleVisibility());
            UpdateHeartsVisibility();
            if (lives == 0)
            {
                if (sound2 != null)
                {
                    sound2.Play();
                }
                StartCoroutine(RestartGame());
            }
        }
    }

    void UpdateHeartsVisibility()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < lives);
        }
    }
    IEnumerator RestartGame()
    {
        Time.timeScale = 0.000000001f;
        yield return new WaitForSeconds(0.000000003f);
        Time.timeScale = 1;
        int hsc = HighScoreScript.GetHighScore();
        int sc = ScoreManager.GetScore();
        if (sc > hsc)
        {
            HighScoreScript.setHighScore(sc);
        }
        ScoreManager.RemoveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}