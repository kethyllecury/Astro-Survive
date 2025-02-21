using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class InicioController : MonoBehaviour

{
    public TMP_Text scoreText;
    public int ultimoScore;
    void Start()
    {
        scoreText = Object.FindFirstObjectByType<TMP_Text>();
        ultimoScore = PlayerPrefs.GetInt("UltimoScore", 0); // Recupera o score salvo
        scoreText.text = ultimoScore.ToString();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
