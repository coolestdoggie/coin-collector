using UnityEngine;
using Zenject;

public class RemoteConfigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RemoteConfigInitializer>().AsSingle().NonLazy();
    }
}