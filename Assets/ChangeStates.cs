using System;
using Unity.Mathematics;
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
    private MovDino movDino;
    private Imbalance imbalance;
    private Animator dinoAnimator;
    private GameState gameState = GameState.Cooking;

    private float timer = 1.5f;
    
    private void Awake()
    {
        armsRigidbody = cookingArms.GetComponent<Rigidbody2D>();
        armMovement = cookingArms.GetComponent<ArmMovement>();
        objectPicker = cookingArms.GetComponent<ObjectPicker>();

        movDino = dino.GetComponent<MovDino>();
        imbalance = dino.GetComponentInChildren<Imbalance>();
        dinoAnimator = dino.GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical");
        
        if (Math.Abs(vertical) > 0.0 && gameState == GameState.Cooking && timer <= 0)
        {
            gameState = GameState.Selling;
            ChangeGameState();
        }

        if (dino.transform.position.y < -2 && timer <= 0)
        {
            gameState = GameState.Cooking;
            timer -= 1.5f;
            ChangeGameState();
        }
        
    }
    
    private void ChangeGameState()
    {
        if (gameState == GameState.Selling)
        {
            cookingArms.SetActive(false);
            dino.SetActive(true);
            GameObject.Find("plate").transform.rotation = quaternion.identity;
            dino.transform.position = new Vector3(dino.transform.position.x,-1.7f, dino.transform.position.z);
        }

        if (gameState == GameState.Cooking)
        {
            dino.SetActive(false);
            cookingArms.SetActive(true);
        }
    }

    private void InvertArmsState()
    {
        armMovement.enabled = !armMovement.enabled;
        objectPicker.enabled = !objectPicker.enabled;
        armsRigidbody.isKinematic = !armsRigidbody.isKinematic;
    }
}
