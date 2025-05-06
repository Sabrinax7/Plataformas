using System;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MoedasTextController : MonoBehaviour
{
    public TMP_Text moedasText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void OnValidate()
    {
        if (moedasText == null)
        {
            moedasText = GetComponent<TMP_Text>();
        }
    }

    private void OnEnable()
    {
        PlayerObserverManager.OnMoedasChanged += AtualizarMoedas;
    }


    private void OnDisable()
    {
        PlayerObserverManager.OnMoedasChanged -= AtualizarMoedas; 
    }

    private void AtualizarMoedas(int coins)
    {
        moedasText.text = "Moedas:" + coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
