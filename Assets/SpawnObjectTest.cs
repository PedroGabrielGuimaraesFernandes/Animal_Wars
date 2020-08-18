using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawnar");
        GameObject teste = Instantiate(Resources.Load("GrassgroundTile", typeof(GameObject)),transform.position,Quaternion.identity) as GameObject;
    }

}
