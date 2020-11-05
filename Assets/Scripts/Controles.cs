// GENERATED AUTOMATICALLY FROM 'Assets/Controles.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controles : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Action_Map"",
            ""id"": ""c88828da-8733-4e4c-ab45-60430c55cb5a"",
            ""actions"": [
                {
                    ""name"": ""Deplacement"",
                    ""type"": ""Value"",
                    ""id"": ""1c145593-c12f-4060-aa26-08f917b9d90c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Saut"",
                    ""type"": ""Button"",
                    ""id"": ""858abd64-65f1-4ad8-be68-c22cf5241c65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""93c521c9-b8d4-4efe-97fc-8822f5c5ed5f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f7b4a45a-cc15-4035-8452-0dd4de4e6a0a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""44859a56-3d5c-49ee-be61-73ae7af5cfe5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Deplacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc95d049-bac5-4323-9418-30f7e7660c44"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Saut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Action_Map
        m_Action_Map = asset.FindActionMap("Action_Map", throwIfNotFound: true);
        m_Action_Map_Deplacement = m_Action_Map.FindAction("Deplacement", throwIfNotFound: true);
        m_Action_Map_Saut = m_Action_Map.FindAction("Saut", throwIfNotFound: true);
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

    // Action_Map
    private readonly InputActionMap m_Action_Map;
    private IAction_MapActions m_Action_MapActionsCallbackInterface;
    private readonly InputAction m_Action_Map_Deplacement;
    private readonly InputAction m_Action_Map_Saut;
    public struct Action_MapActions
    {
        private @Controles m_Wrapper;
        public Action_MapActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Deplacement => m_Wrapper.m_Action_Map_Deplacement;
        public InputAction @Saut => m_Wrapper.m_Action_Map_Saut;
        public InputActionMap Get() { return m_Wrapper.m_Action_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Action_MapActions set) { return set.Get(); }
        public void SetCallbacks(IAction_MapActions instance)
        {
            if (m_Wrapper.m_Action_MapActionsCallbackInterface != null)
            {
                @Deplacement.started -= m_Wrapper.m_Action_MapActionsCallbackInterface.OnDeplacement;
                @Deplacement.performed -= m_Wrapper.m_Action_MapActionsCallbackInterface.OnDeplacement;
                @Deplacement.canceled -= m_Wrapper.m_Action_MapActionsCallbackInterface.OnDeplacement;
                @Saut.started -= m_Wrapper.m_Action_MapActionsCallbackInterface.OnSaut;
                @Saut.performed -= m_Wrapper.m_Action_MapActionsCallbackInterface.OnSaut;
                @Saut.canceled -= m_Wrapper.m_Action_MapActionsCallbackInterface.OnSaut;
            }
            m_Wrapper.m_Action_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Deplacement.started += instance.OnDeplacement;
                @Deplacement.performed += instance.OnDeplacement;
                @Deplacement.canceled += instance.OnDeplacement;
                @Saut.started += instance.OnSaut;
                @Saut.performed += instance.OnSaut;
                @Saut.canceled += instance.OnSaut;
            }
        }
    }
    public Action_MapActions @Action_Map => new Action_MapActions(this);
    public interface IAction_MapActions
    {
        void OnDeplacement(InputAction.CallbackContext context);
        void OnSaut(InputAction.CallbackContext context);
    }
}
