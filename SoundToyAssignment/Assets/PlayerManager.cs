using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JR
{
    public class PlayerManager : MonoBehaviour
    {
        InputHandler inputHandler;
        
        // Start is called before the first frame update
        void Start()
        {
            inputHandler = GetComponent<InputHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            float delta = Time.deltaTime;

            inputHandler.TickInput(delta);
        }
        private void FixedUpdate()
        {
            float delta = Time.deltaTime;
        }
        private void LateUpdate()
        {
            /*
            inputHandler.a_Input = false;
            inputHandler.s_Input = false;
            inputHandler.d_Input = false;
            inputHandler.f_Input = false;
            inputHandler.g_Input = false;
            inputHandler.h_Input = false;
            inputHandler.j_Input = false;
            inputHandler.k_Input = false;
            inputHandler.l_Input = false;
            inputHandler.semiColon_Input = false;
            */
    }
    }
}