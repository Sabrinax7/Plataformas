using System;
using UnityEngine;
// equivalente ao Youtube
public static class PlayerObserverManager
{
    //criar o canal de moedas doplayer 
    public static event Action<int> OnMoedasChanged;
    
    // post avideo novo mp canal 
    public static void ChangendMoedas(int valor)
    {
        OnMoedasChanged?.Invoke(valor);
    }

}


