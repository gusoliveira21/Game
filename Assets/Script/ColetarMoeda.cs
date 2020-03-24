using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetarMoeda : MonoBehaviour

{
    private int coinVaut = 0;
    public Text score;
    private void OnCollisionEnter(Collision objeto)
    
    {
        if (objeto.gameObject.CompareTag("Coin"))
        {
            Destroy(objeto.gameObject);
            coinVaut = coinVaut + 1;
            score.text = "Pontos: " + coinVaut.ToString();
        }

        if ((coinVaut == 9) && (objeto.gameObject.CompareTag("Bau")))
        {// aqui eu devo revelar o ultimo objeto, fazer sumir o baú
           Destroy(objeto.gameObject);
        }

        if ((coinVaut != 9) && (objeto.gameObject.CompareTag("Bau")))
        {// Exibir mensagem dizendo que faltam fragmentos para serem coletados
            
        }
    }
}
