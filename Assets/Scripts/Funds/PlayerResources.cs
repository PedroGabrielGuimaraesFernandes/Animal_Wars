using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerResources : MonoBehaviour
{
    [SerializeField]
    private UnitMarket unitMarket;
    [Header("UI elements used for showing how much funds the player has")]
    public TextMeshProUGUI fundsValueText;
    [Header("Valor de fundos qie o jogador tem")][Range(0,100000)]
    public int funds = 10000;
    //valor dos fundos que apaerece na caixa de texto
    private int textValue = 0;

    private bool ajustValue = false;
    //public int unitCount = 0;

    public bool HasEnoughMoney(int value)
    {
        if(value > funds)
        {
            return false;
        }

        return true;
    }

    private void Awake()
    {
        unitMarket = GetComponent<UnitMarket>();
    }

    // Start is called before the first frame update
    void Start()
    {
        textValue = funds;
        ShowValues();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            AddFunds(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddFunds(10);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddFunds(100);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddFunds(1000);
        }

        if (ajustValue)
        {
            int diference = funds - textValue;
            int addValue = 1;
            if (diference / 30 >= 1)
            {
                addValue = diference /30;
            }

            if (funds > textValue)
            {
                textValue += addValue;
                ShowValues();
            }
        }
    }

    private void ShowValues()
    {
            fundsValueText.text = textValue.ToString();
    }

    public void AddFunds(int value)
    {
        funds += value;
        ajustValue = true;
        //Função de arrumar o valor no hud
        ShowValues();
            Debug.Log("Funds added to player reserves, Added value: " + value + ".");
    }

    public void RemoveFunds(int value)
    {
        if (HasEnoughMoney(value)) {
            funds -= value;
            ajustValue = true;

            ShowValues();
            Debug.Log("Got enough funds for the action, Needed funds: " + value + ".");
        }
        else 
            Debug.Log("Can not complete the action due to a lack of funds, Needed funds: " + value + ",player funds: " + funds +  ".");
    }


}
