using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorGenerator : MonoSingleton<VisitorGenerator>
{
    //ENUMS
    public enum eGeneratorType
    {
        SimpleRandomGenerator,
        DebugGenerator
    }

    public eGeneratorType GeneratorType;


    //DATA
    [SerializeField] private float SpawnCooldownMax = 2.0f;
    public float SpawnCooldown = 0.5f;


    //VISITOR GENERATOR
    public bool IsDebugMode = false;
    private RandomGenerator Generator;
    VisitorColumn myNewColumn;


    //PREFABS
    public GameObject BaseBlueVisitorPrefab;
    public GameObject BaseRedVisitorPrefab;
    public GameObject FastBlueVisitorPrefab;
    public GameObject FastRedVisitorPrefab;
    public GameObject MeteoritePrefab;




    //METHODS

    //TECHNICAL
    private void Start()
    {
        Generator = GetReferenceGenerator(GeneratorType);
    }

    //Update
    private void Update()
    {
        if (GameStateController.Instance.IsStrictlyPlaying)
        {
            SpawnCooldown -= Time.deltaTime;
            if (SpawnCooldown <= 0.0f)
            {
                SpawnCooldown = SpawnCooldownMax;
                myNewColumn = new VisitorColumn(Generator.GenerateColumn());
                myNewColumn.SpawnVisitors();
            }
        }
    }



    //FUNCTIONALITY
    public RandomGenerator GetReferenceGenerator(eGeneratorType type)
    {
        switch (type)
        {
            case eGeneratorType.SimpleRandomGenerator:
                return new RGSimple();

            case eGeneratorType.DebugGenerator:
                return new RGDebug();

            default:
                return new RGSimple();

        }
    }

}
