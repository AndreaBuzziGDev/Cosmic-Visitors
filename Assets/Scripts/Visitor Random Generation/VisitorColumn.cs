using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: REFACTOR AS NON-MONOBEHAVIOUR?
public class VisitorColumn : MonoBehaviour
{
    //ENUM
    //TODO: DITCH. SHOULD USE A MORE SIMPLE IMPLEMENTATION. USE GAME OBJECT REFERENCES FROM THE VisitorGenerator CLASS
    public enum eSlotType
    {
        Empty,
        BaseBlueVisitor,
        BaseRedVisitor,
        FastBlueVisitor,
        FastRedVisitor,
        Meteorite
    }

    //DATA
    private GameObject[] _data = new GameObject[7];//WILL BE THE ACTUAL COLUMN OF OBJECTS SPAWNED IN THE GAME
    public GameObject[] Data { get { return _data; } }

    //TODO: PERHAPS SHOULD BE MOVED ON ANOTHER ELEMENT OF CODE... LIKE VisitorGenerator
    //TODO: COULD USE AN UPGRADE THAT ALLOWS DEBUGGING.
    public static float defaultCoordinatesX = 12.0f;

    private Vector3[] ColumnPositions = new Vector3[] {
        new Vector3(defaultCoordinatesX, 3, 0),
        new Vector3(defaultCoordinatesX, 2, 0),
        new Vector3(defaultCoordinatesX, 1, 0),
        new Vector3(defaultCoordinatesX, 0, 0),
        new Vector3(defaultCoordinatesX, -1, 0),
        new Vector3(defaultCoordinatesX, -2, 0),
        new Vector3(defaultCoordinatesX, -3, 0)
    };
    
    //TODO: RE-OPTIMIZE
    //private VisitorGenerator myGen;



    //DICTIONARY
    public static Dictionary<char, eSlotType> CharToSlotType = new Dictionary<char, eSlotType>() {
        {'E', eSlotType.Empty},
        {'B', eSlotType.BaseBlueVisitor},
        {'R', eSlotType.BaseRedVisitor},
        {'F', eSlotType.FastBlueVisitor},
        {'G', eSlotType.FastRedVisitor},
        {'M', eSlotType.Meteorite}
    };


    //CONSTRUCTOR
    //TODO: GET RID OF CONSTRUCTOR. SHOULD NOT CONSTRUCT MONOBEHAVIOURS. USE FACTORY INSTEAD
    public VisitorColumn(string inputString)
    {
        char[] chars;

        if (inputString != null)
        {
            //TODO: EXPORT AS DEDICATED METHOD/FUNCTIONALITY?
            if (inputString.Length > 7)
            {
                inputString = inputString.Substring(0, 7);
            } 
            else if (inputString.Length < 7)
            {
                while(inputString.Length < 7)
                {
                    inputString += 'E';
                }
            }

            chars = new char[] { 
                inputString[0],
                inputString[1],
                inputString[2],
                inputString[3],
                inputString[4],
                inputString[5],
                inputString[6]
            };

        }
        else
        {
            chars = new char[] { 'E', 'E', 'E', 'E', 'E', 'E', 'E' };
        }

        //SET _data
        for(int i = 0; i < _data.Length; i++)
        {
            this._data[i] = GetMappedObject(chars[i]);
        }
    }



    //METHODS
    public void Start()
    {
        //TODO: THIS WAS DISMISSED DUE TO COMPLICATIONS RELATED TO THE USAGE OF CONSTRUCTOR.
        //myGen = FindObjectOfType<VisitorGenerator>();
    }


    //TODO: POSSIBLE REFACTOR TO GameObject RETURN
    public void SpawnVisitors()
    {
        for (int i=0; i < _data.Length; i++)
        {
            GameObject visitorInstance = _data[i];
            SpawnVisitor(visitorInstance, i);
        }
    }

    //TODO: POSSIBLE REFACTOR TO GameObject RETURN
    public void SpawnVisitor(GameObject visitorInstance, int index)
    {
        if (visitorInstance != null)
        {
            GameObject.Instantiate(visitorInstance, ColumnPositions[index], Quaternion.identity, null);
        }
    }



    //char --> corresponding eSlotType --> corresponding GameObject Prefab
    public GameObject GetMappedObject(char input) => GetMappedGameObject(CharToSlotType[input]);

    //RETURNS THE CORRESPONDING GAME OBJECT EXPECTED BASED ON CORRESPONDING eSlotType
    public GameObject GetMappedGameObject(eSlotType type)
    {
        //TODO: RE-OPTIMIZE
        VisitorGenerator myGen = FindObjectOfType<VisitorGenerator>();
        switch (type)
        {
            case eSlotType.BaseBlueVisitor:
                return myGen.BaseBlueVisitorPrefab;

            case eSlotType.BaseRedVisitor:
                return myGen.BaseRedVisitorPrefab;

            case eSlotType.FastBlueVisitor:
                return myGen.FastBlueVisitorPrefab;

            case eSlotType.FastRedVisitor:
                return myGen.FastRedVisitorPrefab;

            case eSlotType.Meteorite:
                return myGen.MeteoritePrefab;

            default:
                return null;
        }
    }



}
