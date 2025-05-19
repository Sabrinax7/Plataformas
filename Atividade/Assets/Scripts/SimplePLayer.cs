using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePLayer : MonoBehaviour
{
    public  int moedas;
    public CommandManager MyCommandManager;
    
    void Start()
    {
        MyCommandManager = new CommandManager();
    }

    
    void Update()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            MyCommandManager.AddCommand(new MoveUp(transform));
            MyCommandManager.DoCommand();
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.position += Vector3.right;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
           MyCommandManager.AddCommand(new GetCoin(other.gameObject, this));
           MyCommandManager.DoCommand();
        }    
    }

    public void UndoLastCommand()
    {
        MyCommandManager.UndoCommand();
    }
}
