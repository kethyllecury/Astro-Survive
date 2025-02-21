using UnityEngine;
using UnityEngine.UI;

public class powerupController : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 7f;
    public float timer = 0f;
    public Image imagem;
  

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        imagem = GameObject.Find("gas").GetComponent<Image>();
        meuRb.linearVelocity = new Vector2(0f, -velocidade);

        
    }

    void Update()
    {
        meuRb.linearVelocity = new Vector2(0f, -velocidade);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rivall"))
        {
                imagem.fillAmount += 0.3f;
                Destroy(gameObject, 0.05f);
        }
            
        
    }
}