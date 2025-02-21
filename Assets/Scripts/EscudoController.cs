using UnityEngine;

public class EscudoController : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 7f;
    public float timer = 0f;
    public GameObject escudoPrefab;

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
                
        meuRb.linearVelocity = new Vector2(0f, -velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        meuRb.linearVelocity = new Vector2(0f, -velocidade);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rivall"))
        {
            Destroy(gameObject);

            playerMoviment player = collision.gameObject.GetComponent<playerMoviment>(); 
            if (player != null) 
            {
                GameObject escudoAtivo = Instantiate(escudoPrefab, player.transform.position, Quaternion.identity);
                escudoAtivo.transform.SetParent(player.transform); 
                
                escudoAtivo.transform.localPosition = new Vector3(0, 0, 0); 
            }
        }
    }
        
}

