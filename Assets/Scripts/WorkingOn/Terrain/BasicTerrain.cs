using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTerrain : MonoBehaviour
{
    [Header("Nome do terreno")] public string terrainName;
    [Header("Descrição do papel do terreno")] public string terrainDescription;

    [Header("Defencibilidade do terreno para os diversos tipos de unidade")]
    public int defInf = 0;
    public int defWM = 0;
    public int defAir = 0;
    public int defNav = 0;

    [Header("Custo de movimento no terreno para cada tipo de movimentação")]
    public int onFootCost = 0;
    public int whellsCost = 0;
    public int tracksCost = 0;
    public int airCost = 0;
    public int navCost = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
