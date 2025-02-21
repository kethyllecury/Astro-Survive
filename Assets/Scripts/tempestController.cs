using UnityEngine;
using UnityEngine.SceneManagement;

public class TempestController : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 2f;
    public float limiteEsquerda = -6f;
    public float limiteDireita = 6f;
    private bool indoDireita = true;
    public AudioSource somBuracoNegro;

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(limiteEsquerda, transform.position.y);
        somBuracoNegro = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        float direcao = indoDireita ? 1 : -1;
        meuRb.linearVelocity = new Vector2(direcao * velocidade, 0f);

        if (transform.position.x >= limiteDireita)
        {
            indoDireita = false;
        }
        else if (transform.position.x <= limiteEsquerda)
        {
            indoDireita = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rivall"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnBecameInvisible()
    {
        somBuracoNegro.enabled = false;
    }
}