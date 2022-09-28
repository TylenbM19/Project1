using UnityEngine.Events;

public interface IParts 
{
    public event UnityAction<bool> Faced;
    public event UnityAction FacedForFinishPoint;
}
