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
}