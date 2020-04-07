using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameState
{
    Cooking,
    Selling
}


public class ChangeStates : MonoBehaviour
{
    [SerializeField] private GameObject cookingArms;
    [SerializeField] private GameObject dino;
    
    private ObjectPicker objectPicker;
    private ArmMovement armMovement;
    private Rigidbody2D armsRigidbody;
    private GameState gameState = GameState.Cooking;

    private void Awake()
    {
        armsRigidbody = cookingArms.GetComponent<Rigidbody2D>();
        armMovement = cookingArms.GetComponent<ArmMovement>();
        objectPicker = cookingArms.GetComponent<ObjectPicker>();
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");

        if (Math.Abs(vertical) > 0.0 && gameState == GameState.Cooking)
        {
            gameState = GameState.Selling;
            ChangeGameState();
        }
        
    }
    
    private void ChangeGameState()
    {
        if (gameState == GameState.Selling)
        {
            InvertArmsState();
            StartCoroutine(armsMovement(-5f));
        }
    }

    private void InvertArmsState()
    {
        armMovement.enabled = !armMovement.enabled;
        objectPicker.enabled = !objectPicker.enabled;
        armsRigidbody.isKinematic = !armsRigidbody.isKinematic;
    }
    
    private IEnumerator armsMovement(float position)
    {
        float movementSpeed = cookingArms.transform.position.y > position ? -0.1f : 0.1f; 
        
        while (cookingArms.transform.position.y > position)
        {
            cookingArms.transform.position += new Vector3(0,movementSpeed,0);

            yield return null;
        }
    }
}
