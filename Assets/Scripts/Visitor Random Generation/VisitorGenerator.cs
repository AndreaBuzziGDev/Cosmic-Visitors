using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorGenerator : MonoBehaviour
{
    //USED TO RANDOMLY GENERATE VISITORS

    //ENUMS
    public enum eGeneratorType
    {
        SimpleGenerator //TODO: RENAME/REWORK
    }

    public eGeneratorType GeneratorType;


    //DATA
    public float SpawnCooldownTimer = 2.0f;
    private float SpawnCooldownInternal = 0.2f;

    private RandomGenerator Generator;



    //PREFABS
    public GameObject SpaceshipVisitorPrefab;





    //METHODS

    //TECHNICAL
    private void Awake()
    {
        Generator = GetReferenceGenerator(GeneratorType);
    }

    //Update
    private void Update()
    {
        //TODO: IMPLEMENT
        SpawnCooldownInternal -= Time.deltaTime;
        if (SpawnCooldownInternal <= 0.0f)
        {
            SpawnCooldownInternal = SpawnCooldownTimer;
            //TODO: IT COULD GO ON FOREVER AND CAUSE PERFORMANCE ISSUES. NEEDS TO HAVE A LIFETIME IMPLEMENTED
            VisitorColumn myNewColumn = new VisitorColumn(Generator.GenerateColumn());
            myNewColumn.SpawnVisitors();
        }
    }



    //FUNCTIONALITY
    //TODO: REFACTOR AS DICTIONARY?
    public RandomGenerator GetReferenceGenerator(eGeneratorType type)
    {
        RandomGenerator result;

        switch (type)
        {
            case eGeneratorType.SimpleGenerator:
                result = new RGSimple();
                break;
            default:
                result = new RGSimple();
                break;
        }

        return result;
    }


}
