using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverController : MonoBehaviour
{
    public float timer = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (timer < 3f) 
        {
            timer += Time.deltaTime; 
            
            
            
        }
        if (timer >= 3f)
        {
            SceneManager.LoadScene("Inicio");
        }
    }
}
