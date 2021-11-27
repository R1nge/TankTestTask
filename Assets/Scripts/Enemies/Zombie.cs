using UnityEngine;

public class Zombie : Enemy
{
    private void Start()
    {
        aiDestinationSetter.target = GameObject.FindWithTag("Player").transform;
    }
}