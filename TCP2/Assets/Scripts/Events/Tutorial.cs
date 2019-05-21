using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Text subtitle;
    AudioSource audioSrc;
    [HideInInspector] public bool tutorial, tutoWalk, phoneMode;
    float counter;

    string what, whoIsLaxos1, whoIsLaxos2, yourName, yourAge, createPassword, letsStart1, letsStart2, letsStart3, goToApp1, goToApp2,
        sadas1, sadas2, goWalk, itWhistle1, itWhistle2, selfie, goodPic, postPic;
    
    public AudioClip firstSound, whatSound, whoIsLaxosSound, yourNameSound, createPasswordSound, letsStartSound, goToAppSound, sadasSound,
        goWalkSound, itWhistleSound, selfieSound, goodPicSound, postPicSound;

    //[HideInInspector] string playerName, playerAge, playerPassword;
    GameObject phonePanel;
    InputField playerName, playerAge, playerPassword;

    void Start ()
    {
        subtitle = GameObject.Find("Subtitle").GetComponent<Text>();
        audioSrc = GameObject.Find("Cellphone").GetComponent<AudioSource>();
        phonePanel = GameObject.Find("TutorialPanel");
        phonePanel.SetActive(false);
        tutorial = true;
        tutoWalk = false;
        phoneMode = false;
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
        goToApp1 = "Navegue por seus aplicativos para testar se funcionam. Caso precise de ajuda, clique ";
        goToApp2 = "na interrogação no canto superior do ícone do aplicativo para mais detalhes.";
        sadas1 = "Era só o que me faltava. Eu sabia que deveria ter comprado um celular novo antes ";
        sadas2 = "de vir pra cá. Será que o SADAS ainda 'funciona'?";
        goWalk = "Vou andar um pouco e ver o que acontece. Supostamente ele 'detecta' coisas sobrenaturais.";
        itWhistle1 = "Ele ainda apita, então deve estar detectando o campo eletromagnético, mas se isso prova ";
        itWhistle2 = "a existência do sobrenatural, vai saber... Só sei que agora eles não podem mais reclamar.";
        selfie = "Olha que interessante... que tal uma selfie? Será que a câmera já atualizou?";
        goodPic = "Vamos ver se ficou boa.";
        postPic = "Ótimo, só preciso postar.";

        playerName = GameObject.Find("InputFieldName").GetComponent<InputField>();
        playerName.characterLimit = 10;
        playerAge = GameObject.Find("InputFieldAge").GetComponent<InputField>();
        playerAge.characterLimit = 3;
    }
	
	void Update ()
    {
        counter += Time.deltaTime;
        Debug.Log("counter: " + counter);

        if(counter >= 1 && counter <= 2)
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
            else if(counter <= 12 && counter >= 8)
            {
                subtitle.text = whoIsLaxos2;
            }
        }
        if(counter >= 12)
        {
            phoneMode = true;
            subtitle.text = yourName;
            phonePanel.SetActive(true);
        }
    }

    public void UpdateNameField()
    {
        string text = playerName.text;
        text = text.Replace(" ", "");
        text = text.Replace("'", "");
        playerName.text = text;
    }

    public void UpdateAgeField()
    {
        string text = playerAge.text;
        text = text.Replace(" ", "");
        text = text.Replace("-", "");
        playerAge.text = text;
    }
}
