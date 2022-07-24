using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    
    RaycastHit hit;
    public GameObject explosionObject;
    private int upgradeLayer = 8;
    private int layerMask;
    private void Start() {
        layerMask = 1 << upgradeLayer;
        layerMask = ~layerMask;
        Invoke("ExplosaoControler", 2f);
    }
    void ExplosaoControler()
    {
        if (GameManager.Instance.bombas< GameManager.Instance.bombasMaximas)
        {
            GameManager.Instance.bombas += 1;
        }
        //cima
        Explosao(transform.forward);
        //baixo
        Explosao(-transform.forward);
        //direita
        Explosao(transform.right);
        //esquerda
        Explosao(-transform.right);
        // Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        
        Destroy(gameObject);
    }

    void Explosao(Vector3 direction){
        if(Physics.Raycast(transform.position+ new Vector3(0, 0.5f, 0), direction, out hit, GameManager.Instance.tamanhoExplosao,layerMask)){
            
            if(hit.collider.gameObject.tag == "Destructable"){
                DesenhaExplosao(hit.distance+1, direction);
                Destroy(hit.collider.gameObject);
            }else if( hit.collider.gameObject.layer == 6){
                DesenhaExplosao(hit.distance+1, direction);
            }else{
                DesenhaExplosao(hit.distance, direction);   
            }
        }else
        {
            DesenhaExplosao(GameManager.Instance.tamanhoExplosao-1, direction);
        }
    }

    void DesenhaExplosao(float hit, Vector3 direction){
        //Debug.Log(hit.distance);
        for (var i = 0; i <= hit; i++)
        {
            Instantiate(explosionObject, transform.position+i*direction, Quaternion.identity); 
        }
    }
}
