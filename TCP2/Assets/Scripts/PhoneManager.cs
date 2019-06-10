using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhoneManager : MonoBehaviour
{
    [Header("Objeto do jogador")]
    public GameObject player;
    [Header("Objeto da tela desbloqueada")]
    public GameObject unlockedInter;
    [Header("Objeto da tela bloqueada")]
    public GameObject lockedInter;
    [Header("Objeto da tela de menu")]
    public GameObject menuInter;
    [Header("Objeto da interface do celular")]
    public GameObject gameInter;
    [Header("Objeto da interface da galeria")]
    public GameObject galleryInter;
    [Header("Objeto da interface da imagem")]
    public GameObject[] imageInter;
    [Header("Objeto da interface do radar")]
    public GameObject radarInter;
    [Header("Objeto do braço")]
    public GameObject arm;
    [Header("Game designer obj")]
    public GameDesigner gameDesigner;
    [Header("Imagem borrada")]
    public GameObject blurImage;
    [Header("Objeto da interface do tutorial")]
    public GameObject tutorialInter;
    [Header("Objeto da interface da camera")]
    public GameObject cameraInter;
    [Header("Objeto da interface do app")]
    public GameObject appInter;
    [Header("Legenda")]
    public Text subtitle;

    public EventsBehaviour eventsBhv;

    public GameObject postPic1Button, image2, image3;

    public Tutorial tutorial;
    Light fLight;
    [SerializeField] AudioSource[] audios;
    [SerializeField] AudioClip openPhoneClip, flashlightClip, takePicClip;

    private bool inGallery, inImage, big, inRadar, canClick, openCam, muted, canWalk, onPhone, canChange, tryedPic;
    [HideInInspector] public bool phoneMode, inMenu, locked, inApp, canTakePic;
    string imgLastClick;
    float picNOTTime;
    public bool won;

    private void Start()
    {
        phoneMode = false;
        inGallery = false;
        inMenu = false;
        inImage = true;
        big = false;
        inRadar = false;
        unlockedInter.SetActive(false);
        locked = true;
        canClick = false;
        openCam = false;
        inApp = false;
        muted = false;
        canWalk = false;
        canTakePic = false;
        onPhone = false;
        canChange = false;
        picNOTTime = 0;
        tryedPic = false;
        won = false;
        
        fLight = GameObject.Find("Flashlight").GetComponent<Light>();
        fLight.enabled = false;
    }

    private void Update()
    {
        // apresentacao
        /*if(won && Input.GetKey(KeyCode.RightShift))
        {
            SceneManager.LoadScene("Victory");
        }*/

        if(tutorial.bustoCollide || tutorial.skipTuto)
        {
            canChange = true;
        }
        else if (tutorial.phoneMode)
        {
            onPhone = true;
        }

        if(canChange)
        {
            if (Input.GetKeyDown(KeyCode.E) && !inMenu)
            {
                OpenPhone();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }

        Conditions();
    }

    public void Conditions()
    {
        if (locked)
        {
            unlockedInter.SetActive(false);
            lockedInter.SetActive(true);
            tutorialInter.SetActive(false);
            cameraInter.SetActive(false);
            phoneMode = false;
            inGallery = false;
            inImage = false;
            inRadar = false;
            openCam = false;
        }
        else if (!locked)
        {
            unlockedInter.SetActive(true);
            lockedInter.SetActive(false);
            phoneMode = true;
            if(tutorial.tutorial)
            {
                tutorialInter.SetActive(true);
            }
        }

        if (inApp)
        {
            radarInter.SetActive(false);
            galleryInter.SetActive(false);
            gameInter.SetActive(false);
            tutorialInter.SetActive(false);
            appInter.SetActive(true);
            cameraInter.SetActive(false);
            inGallery = false;
            inRadar = false;
        }
        else if (!inApp)
        {
            gameInter.SetActive(true);
            appInter.SetActive(false);
            if (tutorial.tutorial)
            {
                tutorialInter.SetActive(true);
            }
        }

        if (inGallery)
        {
            gameInter.SetActive(false);
            galleryInter.SetActive(true);
            if (inImage)
            {
                if(imgLastClick == "Image0")
                {
                    imageInter[0].SetActive(true);
                }
                if(imgLastClick == "Image1")
                {
                    imageInter[1].SetActive(true);
                    if(!tutorial.canPost && tutorial.tutorial)
                    {
                        tutorial.canPost = true;
                        postPic1Button.SetActive(true);
                    }
                }
                if (imgLastClick == "Image2")
                {
                    imageInter[2].SetActive(true);
                }

                if (imgLastClick == "Image3")
                {
                    imageInter[3].SetActive(true);
                }
            }
            else if (!inImage)
            {
                if (imgLastClick == "Image0BIG")
                {
                    imageInter[0].SetActive(false);
                }
                if (imgLastClick == "Image1BIG")
                {
                    imageInter[1].SetActive(false);
                }
                if (imgLastClick == "Image2BIG")
                {
                    imageInter[2].SetActive(false);
                }
                if (imgLastClick == "Image3BIG")
                {
                    imageInter[3].SetActive(false);
                }
            }
        }
        else if (!inGallery)
        {
            if (imgLastClick == "Image0BIG")
            {
                imageInter[0].SetActive(false);
            }
            if (imgLastClick == "Image1BIG")
            {
                imageInter[1].SetActive(false);
            }
            gameInter.SetActive(true);
            galleryInter.SetActive(false);
            if(tutorial.tutorial)
            {
                tutorialInter.SetActive(true);
            }
        }

        if(inRadar)
        {
            gameInter.SetActive(false);
            tutorialInter.SetActive(false);
            radarInter.SetActive(true);
            cameraInter.SetActive(false);
        }
        else if(!inRadar)
        {
            gameInter.SetActive(true);
            radarInter.SetActive(false);
            if(tutorial.tutorial)
            {
                tutorialInter.SetActive(true);
            }
        }

        if (inMenu)
        {
            Time.timeScale = 0;
            phoneMode = true;
            menuInter.SetActive(true);
        }
        else if (!inMenu)
        {
            Time.timeScale = 1;
            menuInter.SetActive(false);
        }
        
        if(big)
        {
            blurImage.SetActive(true);

            if (!tutorial.sadasOpen)
            {
                this.gameObject.transform.localPosition = new Vector3(-1.88f, 0.52f, 1.39f);
                this.gameObject.transform.localScale = new Vector3(5.88f * 1.7f, 1.54f * 1.7f, 6.25f * 1.7f);
                arm.transform.localPosition = new Vector3(0.626f, -0.3f, 0.35f);
                phoneMode = true;
                Cursor.visible = true;
                canClick = true;
            }
            if(tutorial.sadasOpen || tutorial.skipTuto)
            {
                canWalk = true;
            }
            if(canWalk)
            {
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    this.gameObject.transform.localPosition = new Vector3(-2f, 0.52f, 1.39f);
                    this.gameObject.transform.localScale = new Vector3(5.88f * 1.25f, 1.54f * 1.25f, 6.25f * 1.25f);
                    arm.transform.localPosition = new Vector3(0.5f, -0.5f, 0.35f);
                    phoneMode = false;
                    Cursor.visible = false;
                    canClick = false;
                }
                else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
                {
                    this.gameObject.transform.localPosition = new Vector3(-1.88f, 0.52f, 1.39f);
                    this.gameObject.transform.localScale = new Vector3(5.88f * 1.7f, 1.54f * 1.7f, 6.25f * 1.7f);
                    arm.transform.localPosition = new Vector3(0.626f, -0.3f, 0.35f);
                    phoneMode = true;
                    Cursor.visible = true;
                    canClick = true;
                }
            }
        }
        else if(!big)
        {
            blurImage.SetActive(false);
            this.gameObject.transform.localPosition = new Vector3(-0.98f, 0.534f, 0.33f);
            this.gameObject.transform.localScale = new Vector3(5.88f, 1.54f, 6.25f);
            arm.transform.localPosition = new Vector3(0.4f, -0.17f, 0.35f);
            Cursor.visible = false;
            canClick = false;
        }

        if (!phoneMode)
        {
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.R))
            {
                Flashlight();
            }
        }

        if (openCam)
        {
            radarInter.SetActive(false);
            galleryInter.SetActive(false);
            gameInter.SetActive(false);
            tutorialInter.SetActive(false);
            cameraInter.SetActive(true);
            radarInter.SetActive(false);
        }
        else if (!openCam)
        {
            if(tutorial.tutorial)
            {
                tutorialInter.SetActive(true);
            }
            cameraInter.SetActive(false);
            gameInter.SetActive(true);
        }

        if(onPhone)
        {
            locked = false;
            big = true;
        }
        else if(!onPhone)
        {
            locked = true;
            big = false;
        }

        if(tryedPic)
        {
            picNOTTime += Time.deltaTime;
            
            if(picNOTTime <= 2)
            {
                subtitle.text = "Isso não daria uma boa foto.";
            }
            else if(picNOTTime > 2)
            {
                subtitle.text = "";
                picNOTTime = 0;
                tryedPic = false;
            }
        }
    }

    public void GalleryButton()
    {
        if (canClick)
        {
            inGallery = !inGallery;
        }
    }

    public void Image(Button button)
    {
        if(canClick)
        {
            inImage = !inImage;
            imgLastClick = button.name;
        }
    }

    public void RadarButton()
    {
        if(canClick)
            inRadar = !inRadar;
    }

    public void PauseGame()
    {
        inMenu = !inMenu;
        if(!onPhone)
        {
            onPhone = true;
        }
    }

    public void ToMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MuteAudio()
    {
        muted = !muted;
        if(!muted)
        {
            foreach (AudioSource a in audios)
            {
                a.mute = false;
            }
        }
        else if(muted)
        {
            if (!muted)
            {
                foreach (AudioSource a in audios)
                {
                    a.mute = true;
                }
            }
        }
    }

    public void Flashlight()
    {
        audios[0].PlayOneShot(flashlightClip);
        fLight.enabled = !fLight.enabled;
    }

    public void OpenCamera()
    {
        if(canClick)
            openCam = !openCam;
    }

    public void OpenApp()
    {
        if(canClick)
        {
            inApp = !inApp;
        }
    }

    public void OpenPhone()
    {
        onPhone = !onPhone;
        audios[0].PlayOneShot(openPhoneClip);

        if (tutorial.takePic)
        {
            tutorial.canSelfie = true;
        }
    }

    public void TakePic()
    {
        if(tutorial.tutorial || eventsBhv.canPic)
        {
            canTakePic = true;
        }

        if(canTakePic)
        {
            if(eventsBhv.colPlayer)
            {
                image2.SetActive(true);
                image3.SetActive(true);
                eventsBhv.tookPic = true;
                PlayerPrefs.SetInt("Unlocked 2", 1);
                PlayerPrefs.SetInt("Unlocked 3", 1);
                won = true;
            }
            audios[0].PlayOneShot(takePicClip);
            canTakePic = false;
        }
        else if(!canTakePic)
        {
            tryedPic = true;
        }
    }
}
