using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float Speed;
    public int moedas = 0;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if(Keyboard.current.mKey.wasPressedThisFrame)
        { 
            moedas++;
            PlayerObserverManager.ChangendMoedas(moedas);
        }

        Move();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * (Time.deltaTime * Speed);
    }
}
