using UnityEngine;

public class InimigoControler : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 7f;
    public GameObject tiroInimigo;
    public Transform inimigo;
    private float timer = 0f;
    
    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
                
        meuRb.linearVelocity = new Vector2(0f, -velocidade);
    }

    
    void Update()
    {
        timer += Time.deltaTime; 

        if (timer >= 2f)
        {
            Instantiate(tiroInimigo, inimigo.position, inimigo.rotation);
            timer = Random.Range(0.8f, 2f);

        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
