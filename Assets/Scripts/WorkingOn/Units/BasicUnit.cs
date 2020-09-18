using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{    
    [Header("Nome da unidade")] public string unitName;
    [Header("Descrição do papel da unidade")] public string unitDescription;
    [Header("Custo da unidade")] public string unitCost;
    private int unitHP;

    public enum UnitType { Infantary, WarMachine, Air, Nav};
    [Header("Tipo da unidade")]
    public UnitType unitType;

    public enum AttackType { Close_Range, Medium_Range, Long_Range};
    [Header("Tipo de ataque")]
    public AttackType attackType;

    // 1 - Nenhuma, 2 - Metralhadora, 3 - Bazuca, 4 - Rifle de Precisão, 5 - Morteiro, 6 - Canhão, 7 - Mísseis
    public enum Weapons { None, Machine_Gun, Bazooca, Sniper_Rifle, Mortar, Cannon, Missiles}
    [Header("Arma primaria e secundaria da unidade")]
    public Weapons primaryWeapon = Weapons.None;
    public Weapons secundaryWeapon = Weapons.None;

    [Header("Munição maxima da unidade")]
    public int AmmoCapacity;
    [Header("Munição atual da unidade")]
    public int AmmoCount;

    public enum MovimentType { On_Foot, Wheels, Track, Air, Nav};
    [Header("Tipo de movimentação da unidade")]
    public MovimentType movimentType;
    [Header("Quantidade de pontos de movimentos da unidade")]
    public int movementPoints = 3;

    [Header("Distância de visão da unidade")]
    public int VisionDistance = 2;

    [Header("Capacidade de suprimentos da unidade")]
    public int SupplyCapacity;
    [Header("Quantidade atual de suprimentos da unidade")]
    public int SupplyCount;

    public enum UnitVSUnit { Neutral, Weak, Strong, None};
    [Header("Habilidade de combate contra outras unidades")]
    public UnitVSUnit vsInfantary = UnitVSUnit.Neutral;
    public UnitVSUnit vsWarMachine = UnitVSUnit.Neutral;
    public UnitVSUnit vsAir = UnitVSUnit.Neutral;
    public UnitVSUnit vsNav  = UnitVSUnit.Neutral;
    // Start is called before the first frame update
    public BasicUnit(string unitName, string unitCost, UnitType unitType, AttackType attackType, Weapons primaryWeapon, Weapons secundaryWeapon, int AmmoCapacity, MovimentType movimentType, int movementPoints, int SupplyCapacity){

    }

    private void Move(Vector3 worldPos, Vector3 desiredPos)
    {
        //Realiza a movimentação
    }

    private void PreviewMovement(Vector3 worldPos, int movPoints)
    {
        //Calcular a distancia que pode ser percorrida pela unidade e mostrar ela no mapa
    }

    private void Attack(BasicUnit attacker, BasicUnit defender, Weapons attackingWeapon, BasicTerrain battlefield)
    {
        //A unidade realiza um ataque contra outra unidade
    }

    private void CounterAttack()
    {
        //A unidade reliza um contra ataque contra outra
    }

    private void TakeDamage()
    {
        //A unidade toma dano
    }

    private void CalcDamage()
    {
        //Calcula o dano a ser causado
    }

    private void Selected()
    {

    }

    private void Unselected()
    {

    }

    private void Death()
    {

    }

}
