using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorColumn
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
    public string DataString;

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
    public VisitorColumn(string DataString)
    {
        char[] chars;

        if (DataString != null)
        {
            //TODO: EXPORT AS DEDICATED METHOD/FUNCTIONALITY?
            if (DataString.Length > 7)
            {
                DataString = DataString.Substring(0, 7);
            } 
            else if (DataString.Length < 7)
            {
                while(DataString.Length < 7)
                {
                    DataString += 'E';
                }
            }

            chars = new char[] { 
                DataString[0],
                DataString[1],
                DataString[2],
                DataString[3],
                DataString[4],
                DataString[5],
                DataString[6]
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
        //AUTO-OPTIMIZED BY IDE
        return type switch
        {
            eSlotType.BaseBlueVisitor => VisitorGenerator.Instance.BaseBlueVisitorPrefab,
            eSlotType.BaseRedVisitor => VisitorGenerator.Instance.BaseRedVisitorPrefab,
            eSlotType.FastBlueVisitor => VisitorGenerator.Instance.FastBlueVisitorPrefab,
            eSlotType.FastRedVisitor => VisitorGenerator.Instance.FastRedVisitorPrefab,
            eSlotType.Meteorite => VisitorGenerator.Instance.MeteoritePrefab,
            _ => null,
        };
    }



}
