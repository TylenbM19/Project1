using System;

public interface IParts 
{
    public event Action<bool> Faced;
    public event Action FacedForFinishPoint;
}
