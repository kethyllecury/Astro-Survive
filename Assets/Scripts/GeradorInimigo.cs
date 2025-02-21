using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    public List<GameObject> inimigos;
    public GameObject BonusPrefab;

    public float spawnYMin = 4f;
    public float spawnYMax = 4f;

    void Start()
    {
       
        InvokeRepeating("GerarInimigo", 0f, 3f);
        InvokeRepeating("GerarBonus", 0f, 10f);
    }

    void GerarInimigo()
    {
        int index = Random.Range(0, inimigos.Count);
        GameObject inimigo = inimigos[index];
        
        bool podeInstanciar = true;
        GameObject[] inimigosNaCena = GameObject.FindGameObjectsWithTag(inimigo.tag);

        foreach (GameObject obj in inimigosNaCena)
        {
            
            if (obj.name.Contains(inimigo.name))
            {
                podeInstanciar = false;
                break;
            }
        }

        if (podeInstanciar)
        {
           
            float spawnX = Random.Range(-8f, 8f);  
            float spawnY = Random.Range(spawnYMin, spawnYMax); 

            
            Instantiate(inimigo, new Vector3(spawnX, spawnY, 0f), Quaternion.identity);
        }
        
    }
    public void GerarBonus()
    {
       
        Vector3 posicao = new Vector3(Random.Range(-8f, 8f), Random.Range(4f, 4f), 0f);
        Instantiate(BonusPrefab, posicao, Quaternion.identity);
    }
}