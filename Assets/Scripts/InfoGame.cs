using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoGame : MonoBehaviour
{
    public TMP_Text bombas;
    public TMP_Text vidas;
    void Update()
    {
        bombas.text = "Bombas: " + GameManager.Instance.bombas;
        vidas.text = "Vidas: " + GameManager.Instance.vidas;
    }
}
