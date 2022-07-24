using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherMovement : MonoBehaviour
{
    private bool isMoving = false;
    private bool isColliding = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    public GameObject bomba; 
    void Update()
    {
       if (isMoving)
       {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                isMoving = false;
                isColliding = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * GameManager.Instance.velocidade *  Time.deltaTime;
            return;
       }

    }
    public void frente(){
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.forward;
            startPosition = transform.position;
            isMoving = true;
        }
    }
    public void atras(){
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.back;
            startPosition = transform.position;
            isMoving = true;
        }
    }
    public void direita(){
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.right;
            startPosition = transform.position;
            isMoving = true;
        }
    }
    public void esquerda(){
        if (!isMoving)
        {
            targetPosition = transform.position + Vector3.left;
            startPosition = transform.position;
            isMoving = true;
        }
    }
     public void OnCollisionEnter(Collision collision){
        //Debug.Log("Impactou ");
        //Debug.Log("startPosition" + startPosition);
        //Debug.Log("targetPosition" + targetPosition);
        if (collision.gameObject.layer == 9 && !isColliding){
            Vector3 aux = targetPosition;
            targetPosition = startPosition;
            startPosition = aux;
            isColliding = true;
            //parar o player
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
    
}
