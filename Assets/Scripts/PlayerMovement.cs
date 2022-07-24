using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;
    private bool isColliding = false;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    public GameObject bomba; 
    void Update()
    {
        //Debug.Log("diferença: " + Vector3.Distance(startPosition, transform.position));
        //Debug.Log("startPosition" + startPosition);
        //Debug.Log("targetPosition" + targetPosition);
       if (isMoving)
       {
            //Debug.Log("startPosition" + startPosition);
           // Debug.Log("targetPosition" + targetPosition);
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

        if (Input.GetAxis("Vertical") > 0 && !isMoving)
        {
            targetPosition = transform.position + Vector3.forward;
            startPosition = transform.position;
            isMoving = true;
        } else if (Input.GetAxis("Vertical") < 0 && !isMoving)
        {
            targetPosition = transform.position + Vector3.back;
            startPosition = transform.position;
            isMoving = true;
        } else if (Input.GetKey("d") && !isMoving)
        {
            targetPosition = transform.position + Vector3.right;
            startPosition = transform.position;
            isMoving = true;
        } else if (Input.GetKey("a") && !isMoving)
        {
            targetPosition = transform.position + Vector3.left ;
            startPosition = transform.position;
            isMoving = true;
        }   else if (Input.GetAxis("Jump") > 0 && GameManager.Instance.bombas>0)
        {
            GameManager.Instance.bombas-=1;
            Instantiate(bomba, transform.position, Quaternion.identity);
        } 
    }
   /* public void OnTriggerEnter(Collider collision){
        //Debug.Log("Impactou ");
       // Debug.Log("startPosition" + startPosition);
        //Debug.Log("targetPosition" + targetPosition);
        if (collision.gameObject.layer < 6 && !isColliding){
            Vector3 aux = targetPosition;
            targetPosition = startPosition;
            startPosition = aux;
            isColliding = true;
        }
    }*/
    
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
