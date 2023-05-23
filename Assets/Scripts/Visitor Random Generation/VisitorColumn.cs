using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: REFACTOR AS NON-MONOBEHAVIOUR?
public class VisitorColumn : MonoBehaviour
{
    //ENUM
    public enum eSlotType
    {
        Empty,
        Visitor
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



    //DICTIONARY
    public static Dictionary<char, eSlotType> CharToSlotType = new Dictionary<char, eSlotType>() {
        {'E', eSlotType.Empty},
        {'V', eSlotType.Visitor}
    };


    //CONSTRUCTOR
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
        //TODO: CONDITIONALLY DEBUG BASED ON EDITOR/SCENE SETTINGS
        //Debug.Log("chars: " + chars[0] + chars[1] + chars[2] + chars[3] + chars[4] + chars[5] + chars[6]);

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
        GameObject result;
        /*
        Debug.Log("Debug type: " + type);
        Debug.Log("Debug GameController: " + GameController.Instance);
        */
        VisitorGenerator myGen = FindObjectOfType<VisitorGenerator>();//TODO: FIX. PUT IN AWAKE?
        switch (type)
        {
            case eSlotType.Visitor:
                result = myGen.SpaceshipVisitorPrefab;
                break;
            default:
                result = null;//TODO: FIX
                break;
        }

        return result;
    }



}
