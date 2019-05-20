using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Text subtitle;
    string what, whoIsLaxos1, whoIsLaxos2, yourName, createPassword, letsStart1, letsStart2, letsStart3;
    [HideInInspector] public bool tutorial;

	void Start ()
    {
        what = "Mas o quê...? Isso é sério? Logo agora?";
        whoIsLaxos1 = "Olá, meu nome é Laxos. Sou seu assistente da atualização xx.xxx.xxx.";
        whoIsLaxos2 = "Te ajudarei com tudo o que precisar em seu aparelho. Me ajude a reconfigurar e a te conhecer melhor.";
        yourName = "Digite seu nome.";
        createPassword = "Crie sua senha numérica de 4 dígitos.";
        letsStart1 = "Isso já é o suficiente para começarmos. Seu aparelho foi reconfigurado devido a um erro desconhecido, ";
        letsStart2 = "mas tentei manter inalterados os aplicativos de maior uso. Estou recuperando os arquivos ";
        letsStart3 = "salvos na rede. Assim que recuperá-los te notificarei para que possa baixá-los.";
    }
	
	void Update ()
    {
		
	}
}
