using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
        public EntitieInputs inputsOnStart;
    [SerializeField]
        public InputsVisibility inputsVisibilityManager;
    private GlobalProvider _globalProvider;
    private List<Inputs> _current;

    // create getteer
    public List<Inputs> current
    {
        get
        {
            return _current;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        _current = new List<Inputs>(inputsOnStart.currents);
        _globalProvider = FindObjectOfType<GlobalProvider>();
    }

    private void Start() {
        
        foreach (Inputs input in _current)
        {
            inputsVisibilityManager.SetInputsVisibility(true, input);
        }

        _globalProvider.SubscribeInputOnStarted(Inputs.MOVE_FORWARD, (ctx) => { inputsVisibilityManager.PressInput(Inputs.MOVE_FORWARD); });
        _globalProvider.SubscribeInputOnCanceled(Inputs.MOVE_FORWARD, (ctx) => { inputsVisibilityManager.ReleaseInput(Inputs.MOVE_FORWARD); });


    }

    public void Add(Inputs input)
    {
        _current.Add(input);
        inputsVisibilityManager.SetInputsVisibility(true, input);
    }

    public void ClearAll()
    {
        _current.Clear();
    }

    public void Remove(Inputs input)
    {
        _current.Remove(input);
        inputsVisibilityManager.SetInputsVisibility(false, input);
    }
}
