using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Terrain", menuName = "Terrain")]
public class Terrain : ScriptableObject
{

    [Header("Nome do terreno")] public string terrainName;
    [Header("Descrição do papel do terreno"),TextArea] public string terrainDescription;

    [Header("Prefab do terreno")]
    public GameObject terrainPrefab;
    [Header("Se o terreno é acessivel pelo tipo de unidade")]
    public bool walkableInf = true;
    public bool walkableWM = true;
    public bool walkableAir = true;
    public bool walkableNav = true;

    [Header("Defencibilidade do terreno para os diversos tipos de unidade")]
    [Range(0,4)] public int defInf = 0;
    [Range(0, 4)] public int defWM = 0;
    [Range(0, 4)] public int defAir = 0;
    [Range(0, 4)] public int defNav = 0;

    [Header("Custo de movimento no terreno para cada tipo de movimentação")]
    [Range(1, 4)] public int onFootCost = 1;
    [Range(1, 4)] public int whellsCost = 1;
    [Range(1, 4)] public int tracksCost = 1;
    [Range(1, 4)] public int airCost = 1;
    [Range(1, 4)] public int navCost = 1;
}
