using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickUp : MonoBehaviour
{
    public int upgrade;
    public void OnTriggerEnter(Collider collision){
        if (upgrade != 0)
        {
            GameManager.Instance.Upgrade(upgrade);
        }
        Destroy(gameObject);
    }
}
