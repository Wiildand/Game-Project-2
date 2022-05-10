using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Inputs", menuName = "ScriptableObjects/Entities", order = 1)]
public class EntitieInputs : ScriptableObject
{

    [SerializeField]
    public List<Inputs> currents;

    public void Add(Inputs input)
    {
        currents.Add(input);
    }

    public void Remove(Inputs input)
    {
        currents.Remove(input);
    }


}
