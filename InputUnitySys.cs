// GENERATED AUTOMATICALLY FROM 'Assets/c#/InputUnitySys.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputUnitySys : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputUnitySys()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputUnitySys"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""4c64e573-8b69-4145-a5c6-df6e43aa28cc"",
            ""actions"": [
                {
                    ""name"": ""FIrstFingerPos"",
                    ""type"": ""Value"",
                    ""id"": ""2347362e-8121-4f80-baf4-689f300eb048"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondFingerPos"",
                    ""type"": ""Value"",
                    ""id"": ""fcb2d9ac-fd14-463b-b5d5-45854f21c584"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SescondFingerContact"",
                    ""type"": ""Button"",
                    ""id"": ""1a980a05-aca9-4e81-8a37-1df09cda4546"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""FirstContact"",
                    ""type"": ""Button"",
                    ""id"": ""29394305-837d-4b66-b819-751a3612922e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""090627a0-75dd-4fd9-a792-a4d416368409"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FIrstFingerPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""659db6c6-9789-4c70-ab11-7973275aa04a"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondFingerPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23e53aa7-5cfb-4757-8c6f-6f7f04b40d33"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SescondFingerContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89e8be5d-5f7e-4676-9205-97a2841f98e8"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_FIrstFingerPos = m_Touch.FindAction("FIrstFingerPos", throwIfNotFound: true);
        m_Touch_SecondFingerPos = m_Touch.FindAction("SecondFingerPos", throwIfNotFound: true);
        m_Touch_SescondFingerContact = m_Touch.FindAction("SescondFingerContact", throwIfNotFound: true);
        m_Touch_FirstContact = m_Touch.FindAction("FirstContact", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_FIrstFingerPos;
    private readonly InputAction m_Touch_SecondFingerPos;
    private readonly InputAction m_Touch_SescondFingerContact;
    private readonly InputAction m_Touch_FirstContact;
    public struct TouchActions
    {
        private @InputUnitySys m_Wrapper;
        public TouchActions(@InputUnitySys wrapper) { m_Wrapper = wrapper; }
        public InputAction @FIrstFingerPos => m_Wrapper.m_Touch_FIrstFingerPos;
        public InputAction @SecondFingerPos => m_Wrapper.m_Touch_SecondFingerPos;
        public InputAction @SescondFingerContact => m_Wrapper.m_Touch_SescondFingerContact;
        public InputAction @FirstContact => m_Wrapper.m_Touch_FirstContact;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @FIrstFingerPos.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnFIrstFingerPos;
                @FIrstFingerPos.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnFIrstFingerPos;
                @FIrstFingerPos.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnFIrstFingerPos;
                @SecondFingerPos.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFingerPos;
                @SecondFingerPos.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFingerPos;
                @SecondFingerPos.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSecondFingerPos;
                @SescondFingerContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnSescondFingerContact;
                @SescondFingerContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnSescondFingerContact;
                @SescondFingerContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnSescondFingerContact;
                @FirstContact.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstContact;
                @FirstContact.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstContact;
                @FirstContact.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnFirstContact;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @FIrstFingerPos.started += instance.OnFIrstFingerPos;
                @FIrstFingerPos.performed += instance.OnFIrstFingerPos;
                @FIrstFingerPos.canceled += instance.OnFIrstFingerPos;
                @SecondFingerPos.started += instance.OnSecondFingerPos;
                @SecondFingerPos.performed += instance.OnSecondFingerPos;
                @SecondFingerPos.canceled += instance.OnSecondFingerPos;
                @SescondFingerContact.started += instance.OnSescondFingerContact;
                @SescondFingerContact.performed += instance.OnSescondFingerContact;
                @SescondFingerContact.canceled += instance.OnSescondFingerContact;
                @FirstContact.started += instance.OnFirstContact;
                @FirstContact.performed += instance.OnFirstContact;
                @FirstContact.canceled += instance.OnFirstContact;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnFIrstFingerPos(InputAction.CallbackContext context);
        void OnSecondFingerPos(InputAction.CallbackContext context);
        void OnSescondFingerContact(InputAction.CallbackContext context);
        void OnFirstContact(InputAction.CallbackContext context);
    }
}
