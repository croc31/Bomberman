using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        transform.position += (transform.up * Time.deltaTime)/5;
    }
    public void OnTriggerEnter(Collider collision){
        GameManager.Instance.Impacto(gameObject.GetComponent<Collider>(),collision);
    }
}
