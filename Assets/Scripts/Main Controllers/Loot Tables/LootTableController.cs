using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTableController : MonoSingleton<LootTableController>
{
    //DATA
    [SerializeField] LootTable BaseBlueVisitorLT;
    [SerializeField] LootTable BaseRedVisitorLT;
    [SerializeField] LootTable FastBlueVisitorLT;
    [SerializeField] LootTable FastRedVisitorLT;
    [SerializeField] LootTable AsteroidLT;

    //METHODS
    public Crate HandleLoot(SpaceshipVisitor lootSource)
    {
        LootTable table = getMatchingLootTable(lootSource.Type);
        if (table != null) return table.getRandomLootCrate();
        else return null;
    }


    public LootTable getMatchingLootTable(VisitorColumn.eSlotType visitorType)
    {
        switch (visitorType)
        {
            case VisitorColumn.eSlotType.BaseBlueVisitor:
                return BaseBlueVisitorLT;
            case VisitorColumn.eSlotType.BaseRedVisitor:
                return BaseRedVisitorLT;
            case VisitorColumn.eSlotType.FastBlueVisitor:
                return FastBlueVisitorLT;
            case VisitorColumn.eSlotType.FastRedVisitor:
                return FastRedVisitorLT;
            case VisitorColumn.eSlotType.Asteroid:
                return AsteroidLT;
            case VisitorColumn.eSlotType.Empty:
            default:
                return null;
        }
    }

}
