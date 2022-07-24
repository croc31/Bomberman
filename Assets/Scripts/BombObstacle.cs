using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObstacle : MonoBehaviour
{
   void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            gameObject.layer = 9;
            gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
}
