using Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    [SerializeField] private PlayerController player;

    protected override void Configure(IContainerBuilder builder)
    {
        var playerInstance = Instantiate(player);
        builder.RegisterComponent(playerInstance);
    }
}