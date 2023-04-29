using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Instance of this singleton " + (T)this + " already exists, deleting!");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = (T)this;
        }
    }

}
