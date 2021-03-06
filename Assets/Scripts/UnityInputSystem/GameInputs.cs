//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/UnityInputSystem/GameInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""a975d6ff-ae40-469b-9d5b-b7706caa214a"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""eaf74bf3-ca3f-4a4f-b86b-ac23b6a23d3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""79c57b90-6fb5-4275-b0f5-92d1a8b7042c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e510af3d-9a81-4175-83c0-38e10a4acab5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""30d9d7e8-3445-40d8-bc27-674982fb9982"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d699c7d5-b0a4-4f4c-8362-2a38313a3535"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""69f9c1b2-c45d-4271-ab41-d89b15c209b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d5f989cc-7a96-423c-99a3-90090a00217a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Swap"",
                    ""type"": ""Button"",
                    ""id"": ""97527ccf-5dce-4f9c-903c-916f55ab8881"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Divide"",
                    ""type"": ""Button"",
                    ""id"": ""689d3f9c-fb72-4917-9c4d-109145f3bf01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d823a5f1-d9a8-4412-ab2b-d33cb0e2fbe7"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e15f1ef-717d-4d9c-a8f5-6a62ea576e1e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b04d12ec-9e97-400c-9ded-ea385b380760"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6254ba0c-35db-411a-ae92-a35e8d367fe9"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14be385c-e852-4ba7-83e0-b8dd66d67537"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1064f5ad-dbd5-4cfb-b6b3-ad18bfdf8dc8"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fed6f40-fc7c-4f66-bf07-fc4350b74ed6"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""925b1ca6-85d5-4265-a80f-ea506acd70a5"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86953f16-a67f-4fdf-b859-7b62e4b45431"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Divide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Other"",
            ""id"": ""40f3e55b-feb5-4d9c-95fa-3892513a519a"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""0c962342-a3e7-42fc-9048-71c62d28af9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Retry"",
                    ""type"": ""Button"",
                    ""id"": ""71ddaf29-0af0-4376-a1ae-30a8c9c1ef91"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""48a72aca-6443-4924-bec7-e94286b992c0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""9609216b-9b74-478d-89bd-c254e3f15c9d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""0e65704b-1586-4a6d-8373-7aa0c18ce486"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""Button"",
                    ""id"": ""dca6b49b-3892-4b96-bb75-4547f206b868"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Scroll"",
                    ""type"": ""Value"",
                    ""id"": ""dd21f999-1552-48f2-aa59-4bbc21683018"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Controls"",
                    ""type"": ""Button"",
                    ""id"": ""16cb9241-2238-4e76-a569-cd3b3923eccc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5fe89594-5d3e-4340-8d09-a5167a7ff57d"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0db1cd9-3cb8-4023-b1f7-352a493e0212"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""868fe45a-efef-49c3-8d78-277bc375f2f6"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Retry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5145824f-b821-4a93-88e3-7fe14e1f48c3"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f4c3e8a-6f9c-40d0-9cce-d06decb9c13f"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72a81ef0-44bd-4a76-9473-f29c11c9b2e6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5c579c7-d167-4a35-89e7-e32d21232641"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f2d517e-bf5d-46e3-ab40-d75875cf5630"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbe4153e-e636-4cef-be45-6cd6ff6f0fe1"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Controls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Forward = m_Player.FindAction("Forward", throwIfNotFound: true);
        m_Player_Backward = m_Player.FindAction("Backward", throwIfNotFound: true);
        m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
        m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Swap = m_Player.FindAction("Swap", throwIfNotFound: true);
        m_Player_Divide = m_Player.FindAction("Divide", throwIfNotFound: true);
        // Other
        m_Other = asset.FindActionMap("Other", throwIfNotFound: true);
        m_Other_Menu = m_Other.FindAction("Menu", throwIfNotFound: true);
        m_Other_Retry = m_Other.FindAction("Retry", throwIfNotFound: true);
        m_Other_Pause = m_Other.FindAction("Pause", throwIfNotFound: true);
        m_Other_Mouse = m_Other.FindAction("Mouse", throwIfNotFound: true);
        m_Other_MouseDelta = m_Other.FindAction("MouseDelta", throwIfNotFound: true);
        m_Other_LeftClick = m_Other.FindAction("LeftClick", throwIfNotFound: true);
        m_Other_Scroll = m_Other.FindAction("Scroll", throwIfNotFound: true);
        m_Other_Controls = m_Other.FindAction("Controls", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Forward;
    private readonly InputAction m_Player_Backward;
    private readonly InputAction m_Player_Left;
    private readonly InputAction m_Player_Right;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Swap;
    private readonly InputAction m_Player_Divide;
    public struct PlayerActions
    {
        private @GameInputs m_Wrapper;
        public PlayerActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Player_Forward;
        public InputAction @Backward => m_Wrapper.m_Player_Backward;
        public InputAction @Left => m_Wrapper.m_Player_Left;
        public InputAction @Right => m_Wrapper.m_Player_Right;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Swap => m_Wrapper.m_Player_Swap;
        public InputAction @Divide => m_Wrapper.m_Player_Divide;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBackward;
                @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Swap.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwap;
                @Swap.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwap;
                @Swap.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwap;
                @Divide.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDivide;
                @Divide.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDivide;
                @Divide.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDivide;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Swap.started += instance.OnSwap;
                @Swap.performed += instance.OnSwap;
                @Swap.canceled += instance.OnSwap;
                @Divide.started += instance.OnDivide;
                @Divide.performed += instance.OnDivide;
                @Divide.canceled += instance.OnDivide;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Other
    private readonly InputActionMap m_Other;
    private IOtherActions m_OtherActionsCallbackInterface;
    private readonly InputAction m_Other_Menu;
    private readonly InputAction m_Other_Retry;
    private readonly InputAction m_Other_Pause;
    private readonly InputAction m_Other_Mouse;
    private readonly InputAction m_Other_MouseDelta;
    private readonly InputAction m_Other_LeftClick;
    private readonly InputAction m_Other_Scroll;
    private readonly InputAction m_Other_Controls;
    public struct OtherActions
    {
        private @GameInputs m_Wrapper;
        public OtherActions(@GameInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_Other_Menu;
        public InputAction @Retry => m_Wrapper.m_Other_Retry;
        public InputAction @Pause => m_Wrapper.m_Other_Pause;
        public InputAction @Mouse => m_Wrapper.m_Other_Mouse;
        public InputAction @MouseDelta => m_Wrapper.m_Other_MouseDelta;
        public InputAction @LeftClick => m_Wrapper.m_Other_LeftClick;
        public InputAction @Scroll => m_Wrapper.m_Other_Scroll;
        public InputAction @Controls => m_Wrapper.m_Other_Controls;
        public InputActionMap Get() { return m_Wrapper.m_Other; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OtherActions set) { return set.Get(); }
        public void SetCallbacks(IOtherActions instance)
        {
            if (m_Wrapper.m_OtherActionsCallbackInterface != null)
            {
                @Menu.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnMenu;
                @Retry.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnRetry;
                @Retry.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnRetry;
                @Retry.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnRetry;
                @Pause.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnPause;
                @Mouse.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnMouse;
                @MouseDelta.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnMouseDelta;
                @MouseDelta.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnMouseDelta;
                @LeftClick.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnLeftClick;
                @Scroll.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnScroll;
                @Controls.started -= m_Wrapper.m_OtherActionsCallbackInterface.OnControls;
                @Controls.performed -= m_Wrapper.m_OtherActionsCallbackInterface.OnControls;
                @Controls.canceled -= m_Wrapper.m_OtherActionsCallbackInterface.OnControls;
            }
            m_Wrapper.m_OtherActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
                @Retry.started += instance.OnRetry;
                @Retry.performed += instance.OnRetry;
                @Retry.canceled += instance.OnRetry;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @Controls.started += instance.OnControls;
                @Controls.performed += instance.OnControls;
                @Controls.canceled += instance.OnControls;
            }
        }
    }
    public OtherActions @Other => new OtherActions(this);
    public interface IPlayerActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnSwap(InputAction.CallbackContext context);
        void OnDivide(InputAction.CallbackContext context);
    }
    public interface IOtherActions
    {
        void OnMenu(InputAction.CallbackContext context);
        void OnRetry(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnMouseDelta(InputAction.CallbackContext context);
        void OnLeftClick(InputAction.CallbackContext context);
        void OnScroll(InputAction.CallbackContext context);
        void OnControls(InputAction.CallbackContext context);
    }
}
