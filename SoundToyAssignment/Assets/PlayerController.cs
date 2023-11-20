using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace JR
{    public class PlayerController : MonoBehaviour
    {
        public GameObject a_key;
        public GameObject s_key;
        public GameObject d_key;
        public GameObject f_key;
        public GameObject g_key;
        public GameObject h_key;
        public GameObject j_key;
        public GameObject k_key;
        public GameObject l_key;
        public GameObject semiColon_key;
        public int amountOfKeysPressed;
        public float beatsPerMinute;
        public float metronomePace;
        public int beatsPassed = 0;

        public bool level1;
        public bool level2;
        public bool level3;
        public bool level4;
        public bool level5;




        InputHandler inputHandler;
        void Start()
        {
            amountOfKeysPressed = 0;
            level1 = false;
            level2 = false;
            level3 = false;
            level4 = false;
            level5 = false;
            metronomePace = 60/beatsPerMinute;
            inputHandler = GetComponent<InputHandler>();
            StartCoroutine(Metronome(metronomePace));
        }

        // Update is called once per frame
        void Update()
        {
            if (inputHandler.a_Input)
            {
                a_key.transform.localPosition = new Vector3(-2.555267f, 0.3f, -1);
                a_key.GetComponent<AudioSource>().Play();
            }   
            else
                a_key.transform.localPosition = new Vector3(-2.555267f, 0.4f, -1);
            
            if (inputHandler.s_Input)
            {
                s_key.transform.localPosition = new Vector3(-1.934759f, 0.3f, -1);
                s_key.GetComponent<AudioSource>().Play();
            }                
            else
                s_key.transform.localPosition = new Vector3(-1.934759f, 0.4f, -1);
            
            if (inputHandler.d_Input)
            {
                d_key.transform.localPosition = new Vector3(-1.314251f, 0.3f, -1);
                d_key.GetComponent<AudioSource>().Play();
            }                
            else
                d_key.transform.localPosition = new Vector3(-1.314251f, 0.4f, -1);
            
            if (inputHandler.f_Input)
            {
                f_key.transform.localPosition = new Vector3(-0.6936765f, 0.3f, -1);
                f_key.GetComponent<AudioSource>().Play();
            }                
            else
                f_key.transform.localPosition = new Vector3(-0.6936765f, 0.4f, -1);
            
            if (inputHandler.g_Input)
            {
                g_key.transform.localPosition = new Vector3(-0.07317515f, 0.3f, -1);
                g_key.GetComponent<AudioSource>().Play();
            }                
            else
                g_key.transform.localPosition = new Vector3(-0.07317515f, 0.4f, -1);
            
            if (inputHandler.h_Input)
            {
                h_key.transform.localPosition = new Vector3(0.5473461f, 0.3f, -1);
                h_key.GetComponent<AudioSource>().Play();
            }                
            else
                h_key.transform.localPosition = new Vector3(0.5473461f, 0.4f, -1);
            
            if (inputHandler.j_Input)
            {
                j_key.transform.localPosition = new Vector3(1.160875f, 0.3f, -1);
                j_key.GetComponent<AudioSource>().Play();
            }                
            else
                j_key.transform.localPosition = new Vector3(1.160875f, 0.4f, -1);
            
            if (inputHandler.k_Input)
            {
                k_key.transform.localPosition = new Vector3(1.78145f, 0.3f, -1);
                k_key.GetComponent<AudioSource>().Play();
            }                
            else
                k_key.transform.localPosition = new Vector3(1.78145f, 0.4f, -1);
            
            if (inputHandler.l_Input)
            {
                l_key.transform.localPosition = new Vector3(2.401958f, 0.3f, -1);
                l_key.GetComponent<AudioSource>().Play();
            }                
            else
                l_key.transform.localPosition = new Vector3(2.401958f, 0.4f, -1);

            if (inputHandler.semiColon_Input)
            {
                semiColon_key.transform.localPosition = new Vector3(3.022466f, 0.3f, -1);
                semiColon_key.GetComponent<AudioSource>().Play();
            }                
            else
                semiColon_key.transform.localPosition = new Vector3(3.022466f, 0.4f, -1);
        }

        public void CheckPlayerInput()
        {
            if (inputHandler.a_Input)
                amountOfKeysPressed++;
            if (inputHandler.s_Input)
                amountOfKeysPressed++;
            if (inputHandler.d_Input)
                amountOfKeysPressed++;
            if (inputHandler.f_Input)
                amountOfKeysPressed++;
            if (inputHandler.g_Input)
                amountOfKeysPressed++;
            if (inputHandler.h_Input)
                amountOfKeysPressed++;
            if (inputHandler.j_Input)
                amountOfKeysPressed++;
            if (inputHandler.k_Input)
                amountOfKeysPressed++;
            if (inputHandler.l_Input)
                amountOfKeysPressed++;
            if (inputHandler.semiColon_Input)
                amountOfKeysPressed++;
        }
        private IEnumerator Metronome(float waitTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                CheckPlayerInput();
                BeatInputs();
                amountOfKeysPressed = 0;
                beatsPassed++;
                //print("WaitAndPrint " + Time.time);
                //print("Beats Passed " + beatsPassed);
            }
        }
        private void BeatInputs()
        {
            switch (beatsPassed)
            {
                case 0:
                    if (inputHandler.a_Input && inputHandler.g_Input && amountOfKeysPressed==2)
                    {
                        Debug.Log("Player Passes A+G Check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 1:
                    if (inputHandler.a_Input && inputHandler.g_Input && inputHandler.h_Input && amountOfKeysPressed == 3)
                    {
                        Debug.Log("Player Passes A+G+H Check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 2:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 3:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 4:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 5:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 6:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 7:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 8:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 9:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 10:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 11:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 12:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 13:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 14:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 15:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 16:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 17:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 18:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 19:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 20:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 21:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 22:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 23:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 24:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 25:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 26:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 27:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 28:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 29:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 30:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 31:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                case 32:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)
                    {
                        Debug.Log("Player Passes s check" + beatsPassed);
                    }
                    else
                    {
                        print("Failed  " + beatsPassed);
                    }
                    break;
                default:
                    print("Hit default" + beatsPassed);
                    break;
            }
        }
    }
}