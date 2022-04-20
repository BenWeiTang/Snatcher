//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/_Snatcher/Input/PlayerControls.inputactions
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

namespace Snatcher
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""edda6bf0-0e45-41c5-bc93-2b2910d6f331"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""76b74a6a-3fd2-434e-8dd6-a89d86876460"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Snatch"",
                    ""type"": ""Button"",
                    ""id"": ""5b901fc4-6c41-492a-8361-2847fd45bba1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UseAbility"",
                    ""type"": ""Button"",
                    ""id"": ""149eac73-0e66-465d-9d0d-d504cca628f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""6bb12a1b-7ac5-4d07-a7eb-a1e1db73a3d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""aaaa418c-314a-482c-ad7d-ac5bd6338592"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6428f87c-f933-493c-a617-f13f585fda57"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f994f60a-e07c-4fb3-b6ca-c3ed2a377f43"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f70abfae-e775-4c15-ab46-2b02fb9e1308"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""98d57cb5-000e-4926-8207-e45855bcf926"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""00a7561c-d797-4145-9a6b-1b7112f60355"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e89f1e85-57dd-4395-967b-177781872fe4"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d9641caf-edf0-47dd-8d0f-350fd3cebc05"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5f1d730e-036b-4b8d-9d61-8f2de9001886"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e44f3db3-835e-4fa9-8885-aff58f0faa53"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bd044cea-006b-4e6a-9929-bcaa4cfd574b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""25b32977-6d8a-4a99-b73b-66f185c893db"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,NormalizeVector2"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bd22393-645b-4846-af7c-f5f762385c72"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Snatch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a936fdd-7d3f-4a0c-b2f1-f3e8180dfee9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Snatch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebf31efa-d6fb-491a-b0dd-ca40bdcc7264"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""UseAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a33b9b4-23c6-4301-828b-88605e92b8aa"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UseAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f517b86-be9a-470e-929f-f46078028ba2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b74a202-8cdb-47e4-98cb-283c23f58b43"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95ae215a-77e7-417d-9d86-bf537cbd2a06"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse & Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""274c20c8-ee93-421c-8aa4-478bb9786cf5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""2ca7065b-4b00-4a55-8bd4-aa1b45219be8"",
            ""actions"": [
                {
                    ""name"": ""Cheat 1"",
                    ""type"": ""Button"",
                    ""id"": ""120fe970-f804-44f7-be32-41fb20d90cff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cheat 2"",
                    ""type"": ""Button"",
                    ""id"": ""690d134c-fdee-4112-949a-9b6dcbf67a65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cheat 3"",
                    ""type"": ""Button"",
                    ""id"": ""21f6acce-9919-432f-b977-b49e549b6074"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cheat 4"",
                    ""type"": ""Button"",
                    ""id"": ""9612d743-638f-4c16-87dc-1281a88e9139"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cheat 5"",
                    ""type"": ""Button"",
                    ""id"": ""46256ecd-8152-4ecd-bea6-ce1547c29576"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93893532-28c7-4f1c-beb1-2d91c5999ccd"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cheat 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4b4f34f-610a-4c74-9a64-239a8d365dc2"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cheat 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88e2b8ad-fb5f-4801-a510-5158d29b550d"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cheat 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7243c351-94f8-4b27-8f29-60eecfc8a0e9"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cheat 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49c52e1b-f48f-415a-bf34-2ee391690069"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cheat 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse & Keyboard"",
            ""bindingGroup"": ""Mouse & Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
            m_Player_Snatch = m_Player.FindAction("Snatch", throwIfNotFound: true);
            m_Player_UseAbility = m_Player.FindAction("UseAbility", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
            // Debug
            m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
            m_Debug_Cheat1 = m_Debug.FindAction("Cheat 1", throwIfNotFound: true);
            m_Debug_Cheat2 = m_Debug.FindAction("Cheat 2", throwIfNotFound: true);
            m_Debug_Cheat3 = m_Debug.FindAction("Cheat 3", throwIfNotFound: true);
            m_Debug_Cheat4 = m_Debug.FindAction("Cheat 4", throwIfNotFound: true);
            m_Debug_Cheat5 = m_Debug.FindAction("Cheat 5", throwIfNotFound: true);
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
        private readonly InputAction m_Player_Movement;
        private readonly InputAction m_Player_Snatch;
        private readonly InputAction m_Player_UseAbility;
        private readonly InputAction m_Player_Interact;
        private readonly InputAction m_Player_Dash;
        public struct PlayerActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Player_Movement;
            public InputAction @Snatch => m_Wrapper.m_Player_Snatch;
            public InputAction @UseAbility => m_Wrapper.m_Player_UseAbility;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputAction @Dash => m_Wrapper.m_Player_Dash;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                    @Snatch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSnatch;
                    @Snatch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSnatch;
                    @Snatch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSnatch;
                    @UseAbility.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseAbility;
                    @UseAbility.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseAbility;
                    @UseAbility.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseAbility;
                    @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Snatch.started += instance.OnSnatch;
                    @Snatch.performed += instance.OnSnatch;
                    @Snatch.canceled += instance.OnSnatch;
                    @UseAbility.started += instance.OnUseAbility;
                    @UseAbility.performed += instance.OnUseAbility;
                    @UseAbility.canceled += instance.OnUseAbility;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Debug
        private readonly InputActionMap m_Debug;
        private IDebugActions m_DebugActionsCallbackInterface;
        private readonly InputAction m_Debug_Cheat1;
        private readonly InputAction m_Debug_Cheat2;
        private readonly InputAction m_Debug_Cheat3;
        private readonly InputAction m_Debug_Cheat4;
        private readonly InputAction m_Debug_Cheat5;
        public struct DebugActions
        {
            private @PlayerControls m_Wrapper;
            public DebugActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Cheat1 => m_Wrapper.m_Debug_Cheat1;
            public InputAction @Cheat2 => m_Wrapper.m_Debug_Cheat2;
            public InputAction @Cheat3 => m_Wrapper.m_Debug_Cheat3;
            public InputAction @Cheat4 => m_Wrapper.m_Debug_Cheat4;
            public InputAction @Cheat5 => m_Wrapper.m_Debug_Cheat5;
            public InputActionMap Get() { return m_Wrapper.m_Debug; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
            public void SetCallbacks(IDebugActions instance)
            {
                if (m_Wrapper.m_DebugActionsCallbackInterface != null)
                {
                    @Cheat1.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat1;
                    @Cheat1.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat1;
                    @Cheat1.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat1;
                    @Cheat2.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat2;
                    @Cheat2.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat2;
                    @Cheat2.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat2;
                    @Cheat3.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat3;
                    @Cheat3.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat3;
                    @Cheat3.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat3;
                    @Cheat4.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat4;
                    @Cheat4.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat4;
                    @Cheat4.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat4;
                    @Cheat5.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat5;
                    @Cheat5.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat5;
                    @Cheat5.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnCheat5;
                }
                m_Wrapper.m_DebugActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Cheat1.started += instance.OnCheat1;
                    @Cheat1.performed += instance.OnCheat1;
                    @Cheat1.canceled += instance.OnCheat1;
                    @Cheat2.started += instance.OnCheat2;
                    @Cheat2.performed += instance.OnCheat2;
                    @Cheat2.canceled += instance.OnCheat2;
                    @Cheat3.started += instance.OnCheat3;
                    @Cheat3.performed += instance.OnCheat3;
                    @Cheat3.canceled += instance.OnCheat3;
                    @Cheat4.started += instance.OnCheat4;
                    @Cheat4.performed += instance.OnCheat4;
                    @Cheat4.canceled += instance.OnCheat4;
                    @Cheat5.started += instance.OnCheat5;
                    @Cheat5.performed += instance.OnCheat5;
                    @Cheat5.canceled += instance.OnCheat5;
                }
            }
        }
        public DebugActions @Debug => new DebugActions(this);
        private int m_MouseKeyboardSchemeIndex = -1;
        public InputControlScheme MouseKeyboardScheme
        {
            get
            {
                if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse & Keyboard");
                return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnSnatch(InputAction.CallbackContext context);
            void OnUseAbility(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
        }
        public interface IDebugActions
        {
            void OnCheat1(InputAction.CallbackContext context);
            void OnCheat2(InputAction.CallbackContext context);
            void OnCheat3(InputAction.CallbackContext context);
            void OnCheat4(InputAction.CallbackContext context);
            void OnCheat5(InputAction.CallbackContext context);
        }
    }
}
