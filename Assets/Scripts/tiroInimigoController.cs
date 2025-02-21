using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TiroInimigoController : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 5f;
    public GameObject explosao;
    private Transform alvo;
    public Image imagem;
    
    
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        imagem = GameObject.Find("vida").GetComponent<Image>();
        Destroy(gameObject, 4f);
    }

    void Update()
    {
        imagem = GameObject.Find("vida").GetComponent<Image>();
        
        if (alvo == null)
        {
            var playerScript = FindFirstObjectByType<playerMoviment>();

            if (playerScript != null)
            {
                alvo = playerScript.transform;
            }
        }

        
        if (alvo != null)
        {
            Vector2 direcao = (alvo.position - transform.position).normalized;
            meuRb.linearVelocity = direcao * velocidade; 
        }
        else
        {
            
            meuRb.linearVelocity = transform.up * -velocidade; 
           
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rivall"))
        {
            imagem.fillAmount -= 0.2f;
           
            
            if (imagem.fillAmount == 0)
            {
                Destroy(collision.gameObject);
                GameObject explodir = Instantiate(explosao, transform.position, transform.rotation);
                Destroy(explodir, 1f);
                SceneManager.LoadScene("GameOver");
              
            }
            
            
        }

        if (collision.gameObject.CompareTag("Escudo"))
        {
            collision.transform.SetParent(null);
            Destroy(collision.gameObject); 
            
        }
    }
   

}