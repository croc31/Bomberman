using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string nameInput;
    private string codigoInput;
    public void InputCodigo(string inputBox){
        codigoInput = inputBox;
    }
    public void InputName(string inputBox){
        nameInput = inputBox;
    }
    public void SendInput(){
        WebTalker.Instance.SendCodigo(nameInput, codigoInput);
    }
}
