using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    Text subtitle;
    AudioSource audioSrc;
    [HideInInspector] public bool tutorial, tutoWalk, phoneMode, endPhoneTutorial, sadasOpen, bustoCollide, takePic, tookPic, canSelfie, canPost, canBeep, skipTuto;
    [HideInInspector] public float counter;

    string what, whoIsLaxos1, whoIsLaxos2, yourName, yourAge, createPassword, letsStart1, letsStart2, letsStart3, goToApp1, goToApp2,
        sadas1, sadas2, goWalk, itWhistle1, itWhistle2, selfie, goodPic, postPic;
    
    public AudioClip firstSound, whatSound, whoIsLaxosSound, yourNameSound, createPasswordSound, letsStartSound, goToAppSound, sadasSound,
        goWalkSound, itWhistleSound, selfieSound, goodPicSound, postPicSound, bipSound, takePicSound;
    
    GameObject phonePanel;
    public InputField playerName, playerAge, playerPassword;
    public GameObject userName, userAge, userPassword, tutorialInterface, cameraButton, cameraInterface, bustoLight, galleryButton, tutoPic, 
        postPicButton, appButton, phoneManager, userNameBG, userAgeBG, userPasswordBG, startBG, endConfigBG;
    string pName, pAge, pPassword;

    void Start ()
    {
        subtitle = GameObject.Find("Subtitle").GetComponent<Text>();
        audioSrc = GameObject.Find("Cellphone").GetComponent<AudioSource>();
        phonePanel = GameObject.Find("TutorialPanel");
        startBG.SetActive(true);
        endConfigBG.SetActive(false);
        tutorialInterface.SetActive(false);
        userName.SetActive(false);
        userAge.SetActive(false);
        userPassword.SetActive(false);
        userNameBG.SetActive(false);
        userAgeBG.SetActive(false);
        userPasswordBG.SetActive(false);
        phonePanel.SetActive(false);
        cameraInterface.SetActive(false);
        tutoPic.SetActive(false);
        postPicButton.SetActive(false);
        tutorial = true;
        tutoWalk = false;
        phoneMode = false;
        endPhoneTutorial = false;
        sadasOpen = false;
        bustoCollide = false;
        takePic = false;
        tookPic = false;
        canSelfie = false;
        canPost = false;
        canBeep = true;
        skipTuto = false;
        counter = 0;

        what = "Mas o quê...? Isso é sério? Logo agora?";
        whoIsLaxos1 = "Olá, meu nome é Laxos. Sou seu assistente da atualização xx.xxx.xxx. ";
        whoIsLaxos2 = "Te ajudarei com tudo o que precisar em seu aparelho. Me ajude a reconfigurar e a te conhecer melhor.";
        yourName = "Digite seu nome.";
        yourAge = "Digite sua idade.";
        createPassword = "Crie sua senha numérica de 4 dígitos.";
        letsStart1 = "Isso já é o suficiente para começarmos. Seu aparelho foi reconfigurado devido a um erro desconhecido, ";
        letsStart2 = "mas tentei manter inalterados os aplicativos de maior uso. Estou recuperando os arquivos ";
        letsStart3 = "salvos na rede. Assim que recuperá-los te notificarei para que possa baixá-los.";
        //goToApp1 = "Navegue por seus aplicativos para testar se funcionam. Caso precise de ajuda, clique ";
        goToApp1 = "Navegue por seus aplicativos para testar se funcionam.";
        goToApp2 = "na interrogação no canto superior do ícone do aplicativo para mais detalhes.";
        sadas1 = "Era só o que me faltava. Eu sabia que deveria ter comprado um celular novo antes ";
        sadas2 = "de vir pra cá. Será que o SADAS ainda 'funciona'?";
        goWalk = "Vou andar um pouco e ver o que acontece. Supostamente ele 'detecta' coisas sobrenaturais.";
        itWhistle1 = "Ele ainda apita, então deve estar detectando o campo eletromagnético, mas se isso prova ";
        itWhistle2 = "a existência do sobrenatural, vai saber... Só sei que agora eles não podem mais reclamar.";
        selfie = "Olha que interessante... que tal uma selfie? Será que a câmera já atualizou?";
        goodPic = "Vamos ver se ficou boa.";
        postPic = "Ótimo, só preciso postar.";
    }
	
	void Update ()
    {
        if(skipTuto)
        {
            if(tutorial)
            {
                subtitle.text = "";
                tutoPic.SetActive(true);
                PlayerPrefs.SetInt("Unlocked 1", 1);
                bustoLight.GetComponent<Light>().enabled = false;
                //phoneManager.GetComponent<PhoneManager>().inApp = true;
                startBG.SetActive(false);
                endConfigBG.SetActive(false);
                tutorialInterface.SetActive(false);
                userName.SetActive(false);
                userAge.SetActive(false);
                userPassword.SetActive(false);
                userNameBG.SetActive(false);
                userAgeBG.SetActive(false);
                userPasswordBG.SetActive(false);
                phonePanel.SetActive(false);
                postPicButton.SetActive(false);
            }
            tutorial = false;
        }
        if(tutorial)
        {
            if(Input.GetKey(KeyCode.RightShift))
            {
                skipTuto = true;
            }
            
            if (!phoneMode)
            {
                counter += Time.deltaTime;

                if (counter >= 1 && counter <= 2)
                {
                    subtitle.text = what;
                    //audioSrc.PlayOneShot(firstSound);
                }
                else if (counter >= 2 && counter <= 5)
                {
                    subtitle.text = what;
                    //audioSrc.PlayOneShot(whatSound);
                }
                else if (counter >= 5)
                {
                    //audioSrc.PlayOneShot(whoIsLaxosSound);
                    if (counter <= 8)
                    {
                        subtitle.text = whoIsLaxos1;
                    }
                    else if (counter <= 12 && counter >= 8)
                    {
                        subtitle.text = whoIsLaxos2;
                    }
                }
                if (counter >= 12)
                {
                    //audioSrc.PlayOneShot(yourNameSound);
                    subtitle.text = yourName;
                    phoneMode = true;
                    startBG.SetActive(false);
                    phonePanel.SetActive(true);
                    userName.SetActive(true);
                    userNameBG.SetActive(true);
                    counter = 0;
                }
            }
            if (endPhoneTutorial && !sadasOpen && !bustoCollide && !tookPic && !takePic && !canSelfie && !canPost)
            {
                counter += Time.deltaTime;

                if (counter >= 0 && counter <= 13)
                {
                    //audioSrc.PlayOneShot(letsStart);
                    if (counter <= 4)
                    {
                        subtitle.text = letsStart1;
                    }
                    else if (counter >= 4 && counter <= 9)
                    {
                        subtitle.text = letsStart2;
                    }
                    else if (counter >= 9 && counter <= 13)
                    {
                        subtitle.text = letsStart3;
                    }
                }
                else if (counter >= 13 && counter <= 21 - 4)
                {
                    //audioSrc.PlayOneShot(goToAppSound);
                    phonePanel.SetActive(false);
                    tutorialInterface.SetActive(true);
                    if (counter <= 17)
                    {
                        subtitle.text = goToApp1;
                    }
                    /*else if (counter >= 17 && counter <= 21)
                    {
                        subtitle.text = goToApp2;
                    }*/
                }
                else if (counter >= 21 - 4 && counter <= 31 - 4)
                {
                    endConfigBG.SetActive(false);
                    //audioSrc.PlayOneShot(sadasSound);
                    if (counter <= 25 - 4)
                    {
                        subtitle.text = sadas1;
                    }
                    else if (counter >= 25 - 4 && counter <= 28 - 4)
                    {
                        subtitle.text = sadas2;
                    }
                    else if (counter >= 28 - 4)
                    {
                        subtitle.text = "";
                        endPhoneTutorial = false;
                    }
                }
            }
            if (sadasOpen)
            {
                endPhoneTutorial = false;
                counter += Time.deltaTime;

                if (counter >= 0 && counter <= 4)
                {
                    //audioSrc.PlayOneShot(goWalkSound);
                    subtitle.text = goWalk;
                    tutoWalk = true;
                }
                else if (counter >= 4)
                {
                    subtitle.text = "";
                    sadasOpen = false;
                }
            }
            if (bustoCollide && !takePic)
            {
                endPhoneTutorial = false;
                counter += Time.deltaTime;
                tutoWalk = false;

                if (counter >= 1 && counter <= 10)
                {
                    //audioSrc.PlayOneShot(itWhistleSound);

                    if (counter >= 1 && counter <= 5 && canBeep)
                    {
                        subtitle.text = itWhistle1;
                    }
                    else if (counter >= 5 && counter <= 9 && canBeep)
                    {
                        subtitle.text = itWhistle2;
                        canBeep = false;
                    }
                    else if (counter >= 9 && counter <= 10)
                    {
                        subtitle.text = "";
                        counter = 0;
                        takePic = true;
                    }
                }
            }
            if (takePic && canSelfie)
            {
                endPhoneTutorial = false;
                counter += Time.deltaTime;

                if (counter >= 1 && counter <= 5)
                {
                    //audioSrc.PlayOneShot(selfieSound);
                    bustoLight.GetComponent<Light>().enabled = true;
                    subtitle.text = selfie;
                }
                else if (counter >= 5)
                {
                    cameraButton.GetComponent<Button>().enabled = true;
                    var tempColor = cameraButton.GetComponent<Image>().color;
                    tempColor.a = 0f;
                    cameraButton.GetComponent<Image>().color = tempColor;
                    subtitle.text = "";
                    canSelfie = false;
                }
            }
            if (tookPic && !canPost)
            {
                endPhoneTutorial = false;
                counter += Time.deltaTime;

                if (counter >= 0 && counter <= 3)
                {
                    subtitle.text = goodPic;
                    galleryButton.GetComponent<Button>().enabled = true;
                    var tempColor = galleryButton.GetComponent<Image>().color;
                    tempColor.a = 0f;
                    galleryButton.GetComponent<Image>().color = tempColor;
                }
                else if (counter >= 3)
                {
                    subtitle.text = "";
                    tookPic = false;
                }
            }
            if (canPost)
            {
                endPhoneTutorial = false;
                counter += Time.deltaTime;

                if (counter >= 0 && counter <= 3)
                {
                    subtitle.text = postPic;
                }
                else if (counter >= 3)
                {
                    subtitle.text = "";
                }
            }
        }
    }

    public void UpdateNameField(string newText)
    {
        string text = newText;
        text = text.Replace(" ", "");
        text = text.Replace("'", "");
        playerName.text = text;
    }

    public void UpdateAgeField(string newAge)
    {
        string age = newAge;
        age = age.Replace("-", "");
        age = age.Replace(".", "");
        age = age.Replace(",", "");
        playerAge.text = age;
    }

    public void UpdatePasswordField(string newPassword)
    {
        string password = newPassword;
        password = password.Replace("-", "");
        password = password.Replace(".", "");
        password = password.Replace(",", "");
        playerPassword.text = password;
    }

    public void SetName()
    {
        if(playerName.text != "")
        {
            subtitle.text = yourAge;
            //audioSrc.PlayOneShot(yourAgeSound);
            pName = playerName.text;
            userName.SetActive(false);
            userNameBG.SetActive(false);
            userAge.SetActive(true);
            userAgeBG.SetActive(true);
        }
    }

    public void SetAge()
    {
        if(playerAge.text != "")
        {
            subtitle.text = createPassword;
            //audioSrc.PlayOneShot(createPasswordSound);
            pAge = playerAge.text;
            userAge.SetActive(false);
            userAgeBG.SetActive(false);
            userPassword.SetActive(true);
            userPasswordBG.SetActive(true);
        }
    }

    public void SetPassword()
    {
        if(playerPassword.text != "" && playerPassword.text.Length == 4)
        {
            endPhoneTutorial = true;
            pPassword = playerPassword.text;
            userPassword.SetActive(false);
            userPasswordBG.SetActive(false);
            endConfigBG.SetActive(true);
        }
    }

    public void SadasOpen()
    {
        if (!sadasOpen)
        {
            counter = 0;
        }
        sadasOpen = true;
    }

    public void TakePicture()
    {
        if(takePic)
        {
            tookPic = true;
            counter = 0;
            tutoPic.SetActive(true);
            PlayerPrefs.SetInt("Unlocked 1", 1);
            bustoLight.GetComponent<Light>().enabled = false;
            takePic = false;
        }
    }

    public void PostPicture()
    {
        postPicButton.SetActive(false);
        appButton.GetComponent<Button>().enabled = true;
        var tempColor = appButton.GetComponent<Image>().color;
        tempColor.a = 0f;
        appButton.GetComponent<Image>().color = tempColor;
        phoneManager.GetComponent<PhoneManager>().inApp = true;
        canPost = false;
        tookPic = false;
        counter = 0;
        subtitle.text = "";
        tutorial = false;
    }
}
