using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorGenerator : MonoSingleton<VisitorGenerator>
{
    //USED TO RANDOMLY GENERATE VISITORS

    //ENUMS
    public enum eGeneratorType
    {
        SimpleRandomGenerator,
        DebugGenerator//TODO: IMPLEMENT
    }

    public eGeneratorType GeneratorType;


    //DATA
    [SerializeField] private float SpawnCooldownMax = 2.0f;
    public float SpawnCooldown = 0.5f;




    //VISITOR GENERATOR
    public bool IsDebugMode = false;//TODO: IMPLEMENT/USE
    private RandomGenerator Generator;

    //PREFABS
    public GameObject BaseBlueVisitorPrefab;
    public GameObject BaseRedVisitorPrefab;
    public GameObject FastBlueVisitorPrefab;
    public GameObject FastRedVisitorPrefab;

    //TODO: DEDICATED HIT SOUND IN PREFAB
    //TODO: DEDICATED EXPLOSION SOUND IN PREFAB
    //TODO: DEDICATED EXPLOSION PARTICLE EFFECT IN PREFAB
    public GameObject MeteoritePrefab;//TODO: WILL HAVE GUARANTEED "GOOD" LOOT
    //TODO: MORE...


    VisitorColumn myNewColumn;




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
