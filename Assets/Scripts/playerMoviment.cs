using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class playerMoviment : MonoBehaviour
{
    public float velocidade = 3f;
    public Rigidbody2D meuRb;
    public Vector2 posicao;
    public GameObject meuTiro;
    public Transform player;
    public Image imagem;
    public TMP_Text texto;
    public float tempoTotal = 60f;
    public int score = 0;
    public float timer;
    public GameObject explosao;
    public float Xmin;
    public float Xmax;
    public float Ymin;
    public float Ymax;
    
    
    
    void Start()
    {
       meuRb = GetComponent<Rigidbody2D>();
       
      
    }
    
    void Update()
    {
       Movendo();
       perderGas();
       
       timer += Time.deltaTime;

       if (timer >= 1f) 
       {
           score += 1; 
           texto.text = score.ToString(); 
           PlayerPrefs.SetInt("UltimoScore", score); // Salva o score atual
           PlayerPrefs.Save();
           timer = 0f;
           
       }
    }

    public void Movendo()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 
        posicao = new Vector2(horizontal,vertical) * velocidade;
        posicao.Normalize();
        meuRb.linearVelocity = posicao * velocidade;
        
        float meuX = Mathf.Clamp(meuRb.position.x,Xmin,Xmax);
        float meuY = Mathf.Clamp(meuRb.position.y,Ymin,Ymax);
        
        meuRb.position = new Vector2(meuX, meuY);

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(meuTiro, player.position, player.rotation);
        }

    }

    public void perderGas()
    {
        if (imagem.fillAmount > 0)
        {
            imagem.fillAmount -= Time.deltaTime / tempoTotal;
            
        }

        if (imagem.fillAmount == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject explodir = Instantiate(explosao, player.position, player.rotation);
            Destroy(explodir, 1f);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("Inimigo2"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject explodir = Instantiate(explosao, player.position, player.rotation);
            Destroy(explodir, 1f);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            GameObject explodir = Instantiate(explosao, player.position, player.rotation);
            Destroy(explodir, 1f);
            SceneManager.LoadScene("GameOver");
        }

    }
}
