﻿using System;
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
    [SerializeField] private ThirdContainer container;
    [SerializeField] private GameObject empanadaPrefab;
    
    private GameState gameState = GameState.Cooking;
    private Transform plate;
    private float timer = 1.5f;

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        float vertical = Input.GetAxisRaw("Vertical");
        
        if (Math.Abs(vertical) > 0.0 && gameState == GameState.Cooking && timer <= 0)
        {
            gameState = GameState.Selling;
            ChangeGameState();
        }

        if (dino.transform.position.y < -2 && !cookingArms.activeSelf)
        {
            gameState = GameState.Cooking;
            timer = 1.5f;
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
            InstantiateEmpanadas();
        }

        if (gameState == GameState.Cooking)
        {
            dino.SetActive(false);
            cookingArms.SetActive(true);
        }
    }

    private void InstantiateEmpanadas()
    {
        plate = GameObject.Find("plate").GetComponent<Transform>();
        int empanadas = container.Empanadas.Count < 10 ? container.Empanadas.Count : 9;
        
        container.Clean(empanadas);

        for (int i = 0; i < empanadas; i++)
        {
            Instantiate(empanadaPrefab,plate.position,quaternion.identity, plate);
        }
    }
}
