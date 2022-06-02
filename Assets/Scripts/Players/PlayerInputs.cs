using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] public EntitieInputs inputsOnStart;
    private List<Inputs> _current;

    // create getteer
    public List<Inputs> current
    {
        get
        {
            return _current;
        }
    }

    public void Add(Inputs input)
    {
        _current.Add(input);
    }

    public void ClearAll()
    {
        _current.Clear();
    }

    public void Remove(Inputs input)
    {
        _current.Remove(input);
    }

    // Start is called before the first frame update
    void Awake()
    {
        _current = new List<Inputs>(inputsOnStart.currents);
    }
}
