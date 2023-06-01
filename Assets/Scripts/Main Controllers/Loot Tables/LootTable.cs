using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    //DATA
    List<Crate> lootCrateList = new List<Crate>();

    //METHODS
    public Crate getRandomLootCrate()
    {
        //RANDOM
        Crate result = null;
        if (lootCrateList.Count>0) result = lootCrateList[Random.Range(0, lootCrateList.Count)];

        return result;
    }

}
