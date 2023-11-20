using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JR
{
    public class InputHandler : MonoBehaviour
    {
        PlayerControls inputActions;

        public bool a_Input;
        public bool s_Input;
        public bool d_Input;
        public bool f_Input;
        public bool g_Input;
        public bool h_Input;
        public bool j_Input;
        public bool k_Input;
        public bool l_Input;
        public bool semiColon_Input;

        public void OnEnable()
        {
            if(inputActions == null)
            {
                inputActions = new PlayerControls();                
            }
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            HandleKeyInput(delta);
        }
        private void HandleKeyInput(float delta)
        {
            inputActions.PianoKeys.AKey.performed += i => a_Input = true;
            inputActions.PianoKeys.SKey.performed += i => s_Input = true;
            inputActions.PianoKeys.DKey.performed += i => d_Input = true;
            inputActions.PianoKeys.FKey.performed += i => f_Input = true;
            inputActions.PianoKeys.GKey.performed += i => g_Input = true;
            inputActions.PianoKeys.HKey.performed += i => h_Input = true;
            inputActions.PianoKeys.JKey.performed += i => j_Input = true;
            inputActions.PianoKeys.KKey.performed += i => k_Input = true;
            inputActions.PianoKeys.LKey.performed += i => l_Input = true;
            inputActions.PianoKeys.SemiColonKey.performed += i => semiColon_Input = true;

            inputActions.PianoKeys.AKey.canceled += i => a_Input = false;
            inputActions.PianoKeys.AKey.canceled += i => a_Input = false;
            inputActions.PianoKeys.SKey.canceled += i => s_Input = false;
            inputActions.PianoKeys.DKey.canceled += i => d_Input = false;
            inputActions.PianoKeys.FKey.canceled += i => f_Input = false;
            inputActions.PianoKeys.GKey.canceled += i => g_Input = false;
            inputActions.PianoKeys.HKey.canceled += i => h_Input = false;
            inputActions.PianoKeys.JKey.canceled += i => j_Input = false;
            inputActions.PianoKeys.KKey.canceled += i => k_Input = false;
            inputActions.PianoKeys.LKey.canceled += i => l_Input = false;
            inputActions.PianoKeys.SemiColonKey.canceled += i => semiColon_Input = false;
        }
    }
}