using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_InputWindowManager : MonoBehaviour
{

    public static string lastSaveName = "";
    public static string lastLoadName = "";

    private void Start()
    {
        
    }

    public void Save_Button()
    {
        UI_Blocker.Show_Static();
        UI_InputWindow.Show_Static("Escreva o nome a ser dado ao documento", lastSaveName, UI_InputWindow.Letters + UI_InputWindow.Numbers, 20, () => {
            //Clicou no cancela
            UI_Blocker.Hide_Static();
        }, (string filename) => {
            //Clicou no ok
            //Aqui que eu quero por a função de save         
            Tilemap.Static_Save_Overwrite(filename);
            lastSaveName = filename;
            UI_Blocker.Hide_Static();
        });
    }

    public void Save_Level_Button()
    {
        SaveSystem.SetSavePath(Application.dataPath + "/Saves/Levels/");
        UI_Blocker.Show_Static();
        UI_InputWindow.Show_Static("Escreva o nome a ser dado ao documento", lastSaveName, UI_InputWindow.Letters + UI_InputWindow.Numbers, 20, () => {
            //Clicou no cancela
            UI_Blocker.Hide_Static();
        }, (string filename) => {
            //Clicou no ok
            //Aqui que eu quero por a função de save
            Tilemap.Static_Save_Overwrite(filename);
            lastSaveName = filename;
            UI_Blocker.Hide_Static();
        });
    }

    public void Load_Button()
    {
        UI_Blocker.Show_Static();
        UI_InputWindow.Show_Static("Escreva o nome do documento procurado", "", UI_InputWindow.Letters + UI_InputWindow.Numbers, 20, () => {
            //Clicou no cancela
            UI_Blocker.Hide_Static();
        }, (string filename) => {
            //Clicou no ok
            //Aqui que eu quero por a função de carregar  
            Tilemap.Static_Load(filename);
            lastLoadName = filename;
            UI_Blocker.Hide_Static();
        });
    }

    public void Load_Level_Button()
    {
        SaveSystem.SetSavePath(Application.dataPath + "/Saves/Levels/");
        UI_Blocker.Show_Static();
        UI_InputWindow.Show_Static("Escreva o nome do documento procurado", "", UI_InputWindow.Letters + UI_InputWindow.Numbers, 20, () => {
            //Clicou no cancela
            UI_Blocker.Hide_Static();
        }, (string filename) => {
            //Clicou no ok
            //Aqui que eu quero por a função de carregar  
            Tilemap.Static_Load(filename);
            lastLoadName = filename;
            UI_Blocker.Hide_Static();
        });
    }
}
