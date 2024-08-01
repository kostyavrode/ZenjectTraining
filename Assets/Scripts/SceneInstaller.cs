using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneInstaller : MonoInstaller
{
    [SerializeField] private Character character;
    [SerializeField] private GameController gameController;
    //[SerializeField] private CanvasManager canvasManager;
    public override void InstallBindings()
    {
        this.Container.Bind<ICharacter>().To<Character>().FromInstance(character).AsSingle();
        this.Container.Bind<GameController>().To<GameController>().FromInstance(gameController).AsSingle();
        //this.Container.Bind<CanvasManager>().To<CanvasManager>().FromInstance(canvasManager).AsSingle();
    }
}
