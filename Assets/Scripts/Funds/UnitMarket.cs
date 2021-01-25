using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMarket : MonoBehaviour
{
    [SerializeField]
    private PlayerResources playerResources;

    private Unit soldier;

    private void Awake()
    {
        playerResources = GetComponent<PlayerResources>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BuyUnit(int value, GameObject unit)
    {
        if (playerResources.HasEnoughMoney(value))
        {
            playerResources.RemoveFunds(value);
        }
    }
}
