using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_InputWindowManager : MonoBehaviour
{
    
    private void Start()
    {
        //inputWindow = GetComponent<UI_InputWindow>();
    }

    public void Save_Button()
    {
        UI_InputWindow.Show_Static("Escreva o nome a ser dado ao documento", "", UI_InputWindow.Letters + UI_InputWindow.Numbers, 20, () => {
            //Clicou no cancela
            CMDebug.TextPopupMouse("Cancel!");
        }, (string inputText) => {
            //Clicou no ok

            //Aqui que eu quero por a função de save
            CMDebug.TextPopupMouse("Confirm " + inputText + "!");
        });
    }

    public void Load_Button()
    {
        UI_InputWindow.Show_Static("Escreva o nome do documento procurado", "", UI_InputWindow.Letters + UI_InputWindow.Numbers, 20, () => {
            //Clicou no cancela
            CMDebug.TextPopupMouse("Cancel!");
        }, (string inputText) => {
            //Clicou no ok

            //Aqui que eu quero por a função de carregar
            CMDebug.TextPopupMouse("Confirm " + inputText + "!");
        });
    }
}
