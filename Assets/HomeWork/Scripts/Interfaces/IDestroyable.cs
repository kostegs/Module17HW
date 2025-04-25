using UnityEngine;

public interface IDestroyable
{
    ParticleSystem DestroyEffect { get; }

    void Destroy();
}
