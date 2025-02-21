using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 2f;
    private bool indoDireita = true;
    private float limiteDireita = 6f;
    private float limiteEsquerda = -6f;
    public GameObject tiroInimigo;
    public Transform inimigo;
    public float timer = 1f;
    public GameObject explosao;
    public Transform tiro;

  
    public GameObject barraDeVidaPrefab; 
    public GameObject bossUI; 
    public Image barraDeVida; 

    public int vidaMaxima = 100;
    public int vidaAtual;

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();
        meuRb.linearVelocity = new Vector2(velocidade, 0f);

       
        vidaAtual = vidaMaxima;

       
        InstanciarUI();
    }

    void Update()
    {
        
        if (transform.position.x >= limiteDireita)
        {
            indoDireita = false;
        }
        else if (transform.position.x <= limiteEsquerda)
        {
            indoDireita = true;
        }

        
        meuRb.linearVelocity = new Vector2(indoDireita ? velocidade : -velocidade, 0f);
        
        timer += Time.deltaTime; 

        if (timer >= 2f)
        {
            Instantiate(tiroInimigo, inimigo.position, inimigo.rotation);
            timer = Random.Range(0.8f, 2f);
        }
    }

    
    void InstanciarUI()
    {
      
        bossUI = Instantiate(barraDeVidaPrefab);

       
        bossUI.transform.SetParent(GameObject.Find("Canvas").transform);

        
        RectTransform rectTransform = bossUI.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1); 
        rectTransform.anchorMax = new Vector2(0, 1); 
        rectTransform.anchoredPosition = new Vector2(110, -20); 

        barraDeVida = bossUI.GetComponentInChildren<Image>(); 
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiroplayer"))
        {
            
            barraDeVida.fillAmount -= 0.2f; 

            Destroy(collision.gameObject);

          
            if (barraDeVida.fillAmount <= 0)
            {
                Morrer();
            }
        }
    }
    void Morrer()
    {
        Destroy(gameObject);
        Destroy(bossUI); 
        GameObject explodir = Instantiate(explosao, tiro.position, tiro.rotation);
        Destroy(explodir, 1f);
    }
}
