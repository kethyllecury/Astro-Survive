using System;
using UnityEngine;

public class tiroController : MonoBehaviour
{
    public Rigidbody2D meuRb;
    public float velocidade = 7f;
    public GameObject explosao;
    public Transform tiro;
  

    void Start()
    {
        meuRb = GetComponent<Rigidbody2D>();

        meuRb.linearVelocity = new Vector2(0f, velocidade);
        
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {

            Destroy(collision.gameObject);
            GameObject explodir = Instantiate(explosao, tiro.position, tiro.rotation);
            Destroy(explodir, 1f);
            
        }

        if (collision.gameObject.CompareTag("Inimigo2"))
        {

            Destroy(collision.gameObject);
            GameObject explodir = Instantiate(explosao, tiro.position, tiro.rotation);
            Destroy(explodir, 1f);
           
        }
        
    }
}