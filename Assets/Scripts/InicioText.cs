using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using TMPro;

public class InicioText : MonoBehaviour
{
    public  GameObject panel ;
    public GameObject iniciar;
    public void ativarTexto(){
        panel.SetActive(true);
    }
    public void ativarBotao(){
        iniciar.SetActive(true);
    }
    public void fecharTudo(){
        WebTalker.Instance.SendComecar();
        gameObject.SetActive(false);
    }
}
