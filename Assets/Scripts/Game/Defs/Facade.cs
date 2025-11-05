using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/Facade", fileName = "Facade")]
public class Facade : ScriptableObject
{
    private static Facade _instance;
    public static Facade I => _instance == null ? Init() : _instance;

    private static Facade Init()
    {
        return _instance = Resources.Load<Facade>("Facade");
    }
}
