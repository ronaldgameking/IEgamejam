using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    public float zombieAmount = 99;

    private List<Character> characters;
    public List<Character> Characters
    {
        get => characters;
        set => characters = value;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        Character[] chars = FindObjectsOfType<Character>();

        characters = new List<Character>();
        foreach (Character character in chars)
        {
            characters.Add(character);
        }
    }

    public void RemoveCharacter(Character oldCharacter, Character newCharacter)
    {
        characters.Remove(oldCharacter);
        if (newCharacter != null)
            characters.Add(newCharacter);
        
        if (oldCharacter.CompareTag("Zombie"))
            zombieAmount--;
        
        UIManager.Instance.UpdateUI();
    }
}