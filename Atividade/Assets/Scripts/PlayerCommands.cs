using UnityEngine;

public class MoveUp : ICommand
{
    private Transform myPlayerTransform;

    public MoveUp(Transform PlayerTransform)
    {
        myPlayerTransform = PlayerTransform;
    }


    public void Do()
    {
        myPlayerTransform.position += Vector3.up;
    }

    public void Undo()
    {
        myPlayerTransform.position -= Vector3.up;
    }
}

 public class MoveRight : ICommand
{
    private Transform myPlayerTransform;

    public MoveRight(Transform PlayerTransform)
    {
        myPlayerTransform = PlayerTransform;
    }

    public void Do()
    {
        myPlayerTransform.position += Vector3.right;
    }

    public void Undo()
    {
        myPlayerTransform.position -= Vector3.right;
    }
}

public class GetCoin : ICommand
{
    
    
        private GameObject coinObject;
        private SimplePLayer player;

        public GetCoin(GameObject coinObject, SimplePLayer player)
        {
            this.coinObject = coinObject;
            this.player = player;
        }

        public void Do()
    {
        player.moedas++;
        coinObject.SetActive(false);
    }

    public void Undo()
    {
        player.moedas--;
        coinObject.SetActive(true);
        player.UndoLastCommand();
    }
    
}

