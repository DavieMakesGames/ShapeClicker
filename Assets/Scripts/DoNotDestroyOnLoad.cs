using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    static DoNotDestroyOnLoad _instance;
    private void Awake()
    {
        if (!_instance) _instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
