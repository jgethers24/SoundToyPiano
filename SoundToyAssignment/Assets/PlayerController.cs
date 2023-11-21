using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.UI;
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
        public new GameObject particleSystem;
        public GameObject instruction;
        public GameObject instruction2;
        public GameObject memorizeSign;
        public GameObject playBackSign;

        public int amountOfKeysPressed;
        public int trueBooleans;
        public float beatsPerMinute;
        public float metronomePace;
        public int beatsPassed = 0;
        public bool failed;
        public bool check1;
        public bool check2;
        public bool check3;
        public bool check4;

        public float playerInputWindow;
        public bool particlesStarted;
        public float particleStartDelay;

        public AudioMixer audioMixer;
        public AudioSource failSound;
        public AudioSource memorizeStart;
        public AudioSource memorizeFinish;

        InputHandler inputHandler;
        void Start()
        {
            playerInputWindow = 0;
            failed = false;
            particlesStarted = false;
            amountOfKeysPressed = 0;
            audioMixer.FindSnapshot("Snapshot");
            metronomePace = 60/beatsPerMinute;
            particleStartDelay = metronomePace;
            inputHandler = GetComponent<InputHandler>();
            //StartCoroutine(Metronome(metronomePace));
        }

        // Update is called once per frame
        void Update()
        {
            ResetOutline();
            CheckPlayerInput();
            BeatInputs();
            /*if (playerInputWindow>0)
            {
                
                
                playerInputWindow -= Time.deltaTime;
                if (playerInputWindow<0)
                {
                    playerInputWindow = 0;
                }
            }*/
            if (!particlesStarted)
            {
                particleStartDelay -= Time.deltaTime;
                if (particleStartDelay<= 0)
                {
                    particlesStarted = true;
                    StartCoroutine(ParticleSpawner(metronomePace));
                }
            }

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
                trueBooleans++;
            if (inputHandler.s_Input)
                trueBooleans++;
            if (inputHandler.d_Input)
                trueBooleans++;
            if (inputHandler.f_Input)
                trueBooleans++;
            if (inputHandler.g_Input)
                trueBooleans++;
            if (inputHandler.h_Input)
                trueBooleans++;
            if (inputHandler.j_Input)
                trueBooleans++;
            if (inputHandler.k_Input)
                trueBooleans++;
            if (inputHandler.l_Input)
                trueBooleans++;
            if (inputHandler.semiColon_Input)
                trueBooleans++;
            amountOfKeysPressed = trueBooleans;
            trueBooleans = 0;
        }
        private IEnumerator ParticleSpawner(float waitTime)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                particleSystem.GetComponent<ParticleSystem>().Play();
                //BeatInputs();
                playerInputWindow = metronomePace;
                amountOfKeysPressed = 0;
                beatsPassed++;
                //print("WaitAndPrint " + Time.time);
                //print("Beats Passed " + beatsPassed);
            }
        }
        private void ResetOutline()
        {
            if(a_key.GetComponent<Outline>().OutlineWidth >=0)
                a_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (s_key.GetComponent<Outline>().OutlineWidth >= 0)
                s_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (d_key.GetComponent<Outline>().OutlineWidth >= 0)
                d_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (f_key.GetComponent<Outline>().OutlineWidth >= 0)
                f_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (g_key.GetComponent<Outline>().OutlineWidth >= 0)
                g_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (h_key.GetComponent<Outline>().OutlineWidth >= 0)
                h_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (j_key.GetComponent<Outline>().OutlineWidth >= 0)
                j_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (k_key.GetComponent<Outline>().OutlineWidth >= 0)
                k_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (l_key.GetComponent<Outline>().OutlineWidth >= 0)
                l_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
            if (semiColon_key.GetComponent<Outline>().OutlineWidth >= 0)
                semiColon_key.GetComponent<Outline>().OutlineWidth -= 7 * Time.deltaTime;
        }
        private void BeatInputs()
        {
            switch (beatsPassed)
            {
                case 0://Should be a No beat
                                    //audioMixer.SetFloat("GameStartSound", 0);
                    failed = false;
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;

                    audioMixer.SetFloat("LVL1Volume", -80);
                    audioMixer.SetFloat("DRUMVOLUME", -80);
                    audioMixer.SetFloat("LVL2Volume", -80);
                    audioMixer.SetFloat("LVL3Volume", -80);
                    audioMixer.SetFloat("LVL4Volume", -80);
                    break;
                
                case 1:
                                    //audioMixer.SetFloat("GameStartSound", -80);
                    audioMixer.SetFloat("DRUMVOLUME", 0);
                    audioMixer.SetFloat("LVL1Volume", 0);
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    instruction2.SetActive(true);
                    break;
                
                case 2:
                    break;
                
                case 3:
                    memorizeStart.loop = false;
                    memorizeSign.SetActive(false);
                    break;

                case 4:
                    break;

                case 5:
                    
                    instruction2.SetActive(false);

                    break;
                
                case 6:
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    } 
                    a_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;
                
                case 7:
                    s_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 8:
                    d_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 9:
                    f_key.GetComponent<Outline>().OutlineWidth = 10;
                    
                    break;

                case 10:
                    memorizeSign.SetActive(false);
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    instruction.SetActive(true);
                    break;

                case 11:
                    memorizeFinish.loop = false;
                    break;

                case 12:
                    break;

                case 13:
                    break;

                case 14:
                    instruction.SetActive(false);
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    break;

                case 15:
                    //LVL 1 checks start here
                    playBackSign.SetActive(true);
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -9
                    {
                        Debug.Log("pass" + beatsPassed);
                        check1 = true;
                    }
                    break;

                case 16:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)//should match this Case -9
                    {
                        Debug.Log("pass" + beatsPassed);
                        check2 = true;
                    }
                    break;

                case 17:
                    
                    if (inputHandler.d_Input && amountOfKeysPressed == 1)//should match this Case -9
                    {
                        Debug.Log("pass" + beatsPassed);
                        check3 = true;
                    }
                    break;

                case 18:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -9
                    {
                        Debug.Log("pass" + beatsPassed);
                        check4 = true;
                    }
                    if (!check1 || !check2 || !check3 || !check4)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4)
                    {
                        failed = false;
                    }
                    break;

                case 19:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 0;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    audioMixer.SetFloat("LVL2Volume", 0);
                    break;
                case 20:                    //lvl 2 memorization start
                    f_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 21:
                    j_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 22:
                    f_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 23:
                    k_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 24:                //lvl2 memorize finish
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeSign.SetActive(false);
                        memorizeFinish.Play();
                    }
                    break;
                case 25:
                    playBackSign.SetActive(true);
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check1 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 26:
                    if (inputHandler.j_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check2 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 27:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check3 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 28:
                    if (inputHandler.k_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check4 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    if (!check1 || !check2 || !check3 || !check4)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4)
                    {
                        failed = false;
                    }
                    break;
                case 29:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 0;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    audioMixer.SetFloat("LVL3Volume", 0);
                    break;

                case 30:                    //lvl 3 memorization start
                    a_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 31:
                    semiColon_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 32:
                    j_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 33:
                    f_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;
                case 34:
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                        memorizeSign.SetActive(false);
                    }
                    break;

                case 35:                //lvl3 memorize finish
                    playBackSign.SetActive(true);
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check1 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 36:
                    if (inputHandler.semiColon_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check2 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 37:
                    if (inputHandler.j_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check3 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 38:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check4 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    if (!check1 || !check2 || !check3 || !check4)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4)
                    {
                        failed = false;
                    }
                    break;
                case 39:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 0;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    audioMixer.SetFloat("LVL4Volume", 0);
                    break;
                case 40:                    //lvl 3 memorization start
                    
                    a_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 41:
                    semiColon_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 42:
                    j_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;

                case 43:
                    f_key.GetComponent<Outline>().OutlineWidth = 10;
                    break;
                case 44:
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                        memorizeSign.SetActive(false);
                    }
                    break;

                case 45:                //lvl3 memorize finish
                    playBackSign.SetActive(true);
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check1 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 46:
                    if (inputHandler.semiColon_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check2 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 47:
                    if (inputHandler.j_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check3 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 48:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -5
                    {
                        check4 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    if (!check1 || !check2 || !check3 || !check4)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4)
                    {
                        failed = false;
                    }
                    break;
                case 49:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 0;
                        break;
                    }
                    break;
                case 55:
                    audioMixer.SetFloat("LVL1Volume", -80);
                    audioMixer.SetFloat("DRUMVOLUME", -80);
                    audioMixer.SetFloat("LVL2Volume", -80);
                    audioMixer.SetFloat("LVL3Volume", -80);
                    audioMixer.SetFloat("LVL4Volume", -80);
                    print("Hit default" + beatsPassed);
                    break;

                    /*
                    default:
                        audioMixer.SetFloat("LVL1Volume", -80);
                        audioMixer.SetFloat("DRUMVOLUME", -80);
                        audioMixer.SetFloat("LVL2Volume", -80);
                        audioMixer.SetFloat("LVL3Volume", -80);
                        audioMixer.SetFloat("LVL4Volume", -80);
                        print("Hit default" + beatsPassed);
                        break;*/
            }
        }
    }
}