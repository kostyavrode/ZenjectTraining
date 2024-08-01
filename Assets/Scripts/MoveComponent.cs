using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class MoveComponent : MonoBehaviour
{
    private ICharacter character;
    [Inject]
    public void Construct(ICharacter character)
    {
    this.character = character; 
    }
    private void Update()
    {
        //Debug.Log(this.character);
    }
}
