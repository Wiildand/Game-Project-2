using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Inputs", menuName = "ScriptableObjects/Entities", order = 1)]
public class EntitieInputs : ScriptableObject
{

    [SerializeField]
    public List<Inputs> currents;

}
