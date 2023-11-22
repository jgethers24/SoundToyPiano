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
        public GameObject announcementText;

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
        public bool check5;
        public bool check6;
        public bool check7;
        public bool check8;

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
            particleStartDelay = 0.5f;
            inputHandler = GetComponent<InputHandler>();
            //StartCoroutine(ParticleSpawner(metronomePace));
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
            }   
            else
                a_key.transform.localPosition = new Vector3(-2.555267f, 0.4f, -1);
            
            if (inputHandler.s_Input)
            {
                s_key.transform.localPosition = new Vector3(-1.934759f, 0.3f, -1);
            }                
            else
                s_key.transform.localPosition = new Vector3(-1.934759f, 0.4f, -1);
            
            if (inputHandler.d_Input)
            {
                d_key.transform.localPosition = new Vector3(-1.314251f, 0.3f, -1);
            }                
            else
                d_key.transform.localPosition = new Vector3(-1.314251f, 0.4f, -1);
            
            if (inputHandler.f_Input)
            {
                f_key.transform.localPosition = new Vector3(-0.6936765f, 0.3f, -1);
            }                
            else
                f_key.transform.localPosition = new Vector3(-0.6936765f, 0.4f, -1);
            
            if (inputHandler.g_Input)
            {
                g_key.transform.localPosition = new Vector3(-0.07317515f, 0.3f, -1);
            }                
            else
                g_key.transform.localPosition = new Vector3(-0.07317515f, 0.4f, -1);
            
            if (inputHandler.h_Input)
            {
                h_key.transform.localPosition = new Vector3(0.5473461f, 0.3f, -1);
            }                
            else
                h_key.transform.localPosition = new Vector3(0.5473461f, 0.4f, -1);
            
            if (inputHandler.j_Input)
            {
                j_key.transform.localPosition = new Vector3(1.160875f, 0.3f, -1);
            }                
            else
                j_key.transform.localPosition = new Vector3(1.160875f, 0.4f, -1);
            
            if (inputHandler.k_Input)
            {
                k_key.transform.localPosition = new Vector3(1.78145f, 0.3f, -1);
            }                
            else
                k_key.transform.localPosition = new Vector3(1.78145f, 0.4f, -1);
            
            if (inputHandler.l_Input)
            {
                l_key.transform.localPosition = new Vector3(2.401958f, 0.3f, -1);
            }                
            else
                l_key.transform.localPosition = new Vector3(2.401958f, 0.4f, -1);

            if (inputHandler.semiColon_Input)
            {
                semiColon_key.transform.localPosition = new Vector3(3.022466f, 0.3f, -1);
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
                a_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (s_key.GetComponent<Outline>().OutlineWidth >= 0)
                s_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (d_key.GetComponent<Outline>().OutlineWidth >= 0)
                d_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (f_key.GetComponent<Outline>().OutlineWidth >= 0)
                f_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (g_key.GetComponent<Outline>().OutlineWidth >= 0)
                g_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (h_key.GetComponent<Outline>().OutlineWidth >= 0)
                h_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (j_key.GetComponent<Outline>().OutlineWidth >= 0)
                j_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (k_key.GetComponent<Outline>().OutlineWidth >= 0)
                k_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (l_key.GetComponent<Outline>().OutlineWidth >= 0)
                l_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
            if (semiColon_key.GetComponent<Outline>().OutlineWidth >= 0)
                semiColon_key.GetComponent<Outline>().OutlineWidth -= 15 * Time.deltaTime;
        }
        private void BeatInputs()
        {
            switch (beatsPassed)
            {
                case 0://Should be a No beat
                    failed = false;
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    check5 = false;
                    check6 = false;
                    check7 = false;
                    check8 = false;
                    audioMixer.SetFloat("AmbientVolume", 10);
                    audioMixer.SetFloat("LVL1Volume", -80);
                    audioMixer.SetFloat("DRUMVOLUME", -80);
                    audioMixer.SetFloat("LVL2Volume", -80);
                    audioMixer.SetFloat("LVL3Volume", -80);
                    audioMixer.SetFloat("LVL4Volume", -80);
                    break;
                
                case 5:
                    failed = false;
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    check5 = false;
                    check6 = false;
                    check7 = false;
                    check8 = false;
                    audioMixer.SetFloat("AmbientVolume", 10);
                    audioMixer.SetFloat("LVL1Volume", -80);
                    audioMixer.SetFloat("DRUMVOLUME", -80);
                    audioMixer.SetFloat("LVL2Volume", -80);
                    audioMixer.SetFloat("LVL3Volume", -80);
                    audioMixer.SetFloat("LVL4Volume", -80);
                    audioMixer.SetFloat("DRUMVOLUME", 0);
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    instruction2.SetActive(true);
                    break;
                
                case 7:
                    memorizeStart.loop = false;
                    break;
                
                case 9:
                    audioMixer.SetFloat("LVL1Volume", 0);
                    audioMixer.SetFloat("AmbientVolume", 5);
                    memorizeSign.SetActive(false);
                    break;

                case 10:
                    instruction2.SetActive(false);
                    break;

                case 12:
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    instruction.SetActive(true);
                    playBackSign.SetActive(true);
                    break;
                case 14:
                    memorizeFinish.loop = false;
                    break;
                case 17:
                    instruction.SetActive(false);
                    playBackSign.SetActive(false);
                    break;
                case 19:
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    break;
                case 20:                                                                                   //Lvl 1 memorization starts here
                    if (a_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        a_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;
         

                case 21:
                    if (s_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        s_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    
                    break;

                case 22:
                    if (d_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        d_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 23:
                    if (f_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }                   
                    break;

                case 24:
                    memorizeSign.SetActive(false);
                    break;

                case 27:
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    playBackSign.SetActive(true);
                    break;
                case 28:
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check1 = true;
                        check5 = true;
                        check6 = true;
                        check7 = true;
                        check8 = true;
                    }
                    break;

                case 29:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check2 = true;
                    }
                    break;

                case 30:
                    if (inputHandler.d_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check3 = true;
                    }
                    break;

                case 31:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check4 = true;
                    }
                    if (!check1 || !check2 || !check3 || !check4 || !check5 || !check6 || !check7 || !check8)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4 && check5 && check6 && check7 && check8)
                    {
                        failed = false;
                    }
                    break;

                case 32:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 5;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    check5 = false;
                    check6 = false;
                    check7 = false;
                    check8 = false;
                    audioMixer.SetFloat("LVL2Volume", 0);
                    audioMixer.SetFloat("AmbientVolume", 0);
                    break;

                case 33:
                    announcementText.GetComponent<Text>().text = "Level 1 Passed";
                    announcementText.SetActive(true);
                    break;

                case 36:
                    announcementText.SetActive(false);
                    break;

                case 39:
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    break;
                case 40:                                                                            //lvl 2 memorization start
                    if (f_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    
                    break;

                case 41:
                    if (j_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        j_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 42:
                    if (f_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 43:
                    if (k_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        k_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;
                case 44:
                    if (f_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 45:
                    if (d_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        d_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 46:
                    if (s_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        s_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 47:
                    if (a_key.GetComponent<Outline>().OutlineWidth <=0)
                    {
                        a_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;
                case 48:
                    memorizeSign.SetActive(false);
                    break;

                case 55:                                                                        //lvl2 checks start here
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    playBackSign.SetActive(true);
                    break;
                case 56:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check1 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 57:
                    if (inputHandler.j_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check2 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 58:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check3 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;
                case 59:
                    playBackSign.SetActive(true);
                    if (inputHandler.k_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check4 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 60:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check5 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 61:
                    if (inputHandler.d_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check6 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;
                case 62:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check7 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;
                case 63:
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check8 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    if (!check1 || !check2 || !check3 || !check4 || !check5 || !check6 || !check7 || !check8)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4 && check5 && check6 && check7 && check8)
                    {
                        failed = false;
                    }
                    break;

                case 64:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 5;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    check5 = false;
                    check6 = false;
                    check7 = false;
                    check8 = false;
                    audioMixer.SetFloat("LVL3Volume", 0);
                    audioMixer.SetFloat("AmbientVolume", -5);
                    break;

                case 65:
                    announcementText.GetComponent<Text>().text = "Level 2 Passed";
                    announcementText.SetActive(true);
                    break;

                case 68:
                    announcementText.SetActive(false);
                    break;

                //lvl 3 memorization start
                case 69:
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    break;
                case 70:
                    if (a_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        a_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;


                case 71:
                    if (s_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        s_key.GetComponent<Outline>().OutlineWidth = 20;
                    }

                    break;

                case 72:
                    if (d_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        d_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 73:
                    if (f_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 74:
                    memorizeSign.SetActive(false);
                    break;

                case 77:
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    playBackSign.SetActive(true);
                    break;
                case 78:
                                                                                                                        //LVL 3 checks start here
                    playBackSign.SetActive(true);
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check1 = true;
                        check5 = true;
                        check6 = true;
                        check7 = true;
                        check8 = true;
                    }
                    break;

                case 79:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check2 = true;
                    }
                    break;

                case 80:

                    if (inputHandler.d_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check3 = true;
                    }
                    break;

                case 81:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -8
                    {
                        Debug.Log("pass" + beatsPassed);
                        check4 = true;
                    }
                    if (!check1 || !check2 || !check3 || !check4 || !check5 || !check6 || !check7 || !check8)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4 && check5 && check6 && check7 && check8)
                    {
                        failed = false;
                    }
                    break;

                case 82:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 5;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    check5 = false;
                    check6 = false;
                    check7 = false;
                    check8 = false;
                    audioMixer.SetFloat("LVL2Volume", 0);
                    audioMixer.SetFloat("AmbientVolume", -10);
                    break;

                case 83:
                    announcementText.GetComponent<Text>().text = "Level 3 Passed";
                    announcementText.SetActive(true);
                    break;

                case 86:
                    announcementText.SetActive(false);
                    break;

                case 89:
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    break;
                case 90:                                                            //lvl 4 memorization start
                    if (f_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }

                    break;

                case 91:
                    if (j_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        j_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 92:
                    if (f_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 93:
                    if (k_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        k_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;
                case 94:
                    if (f_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        f_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 95:
                    if (d_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        d_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 96:
                    if (s_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        s_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;

                case 97:
                    if (a_key.GetComponent<Outline>().OutlineWidth <= 0)
                    {
                        a_key.GetComponent<Outline>().OutlineWidth = 20;
                    }
                    break;
                case 98:
                    memorizeSign.SetActive(false);
                    break;

                case 105:                                                                               //lvl4 check start
                    if (!memorizeFinish.isPlaying)
                    {
                        memorizeFinish.Play();
                    }
                    playBackSign.SetActive(true);
                    break;
                case 106:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check1 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 107:
                    if (inputHandler.j_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check2 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 108:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check3 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;
                case 109:
                    playBackSign.SetActive(true);
                    if (inputHandler.k_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check4 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 110:
                    if (inputHandler.f_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check5 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;

                case 111:
                    if (inputHandler.d_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check6 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;
                case 112:
                    if (inputHandler.s_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check7 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    break;
                case 113:
                    if (inputHandler.a_Input && amountOfKeysPressed == 1)//should match this Case -16
                    {
                        check8 = true;
                        Debug.Log("pass" + beatsPassed);
                    }
                    if (!check1 || !check2 || !check3 || !check4 || !check5 || !check6 || !check7 || !check8)
                    {
                        failed = true;
                    }
                    if (check1 && check2 && check3 && check4 && check5 && check6 && check7 && check8)
                    {
                        failed = false;
                    }
                    break;

                case 114:
                    playBackSign.SetActive(false);
                    if (failed)
                    {
                        beatsPassed = 5;
                        break;
                    }
                    check1 = false;
                    check2 = false;
                    check3 = false;
                    check4 = false;
                    check5 = false;
                    check6 = false;
                    check7 = false;
                    check8 = false;
                    if (!memorizeStart.isPlaying)
                    {
                        memorizeStart.Play();
                        memorizeSign.SetActive(true);
                    }
                    audioMixer.SetFloat("LVL3Volume", 0);
                    audioMixer.SetFloat("AmbientVolume", -20);
                    break;

                case 115:
                    announcementText.GetComponent<Text>().text = "Level 4 Passed";
                    announcementText.SetActive(true);
                    break;

                case 118:
                    announcementText.SetActive(false);
                    break;

                case 124:
                    audioMixer.SetFloat("LVL1Volume", -80);
                    audioMixer.SetFloat("DRUMVOLUME", -80);
                    audioMixer.SetFloat("LVL2Volume", -80);
                    audioMixer.SetFloat("LVL3Volume", -80);
                    audioMixer.SetFloat("LVL4Volume", -80);
                    break;
                case 128:
                    beatsPassed = 5;
                    break;
            }
        }
    }
}