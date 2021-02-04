using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    private int zombieAmount = 0;
    public int ZombieAmount => zombieAmount;

    private List<Character> characters;
    public List<Character> Characters
    {
        get => characters;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        zombieAmount = 0;
    }

    private void Start()
    {
        Character[] chars = FindObjectsOfType<Character>();

        characters = new List<Character>();
        foreach (Character character in chars)
        {
            characters.Add(character);
            if (character.CompareTag("Zombie"))
                zombieAmount = Mathf.Clamp(zombieAmount + 1, 0, characters.Count);
        }
        
        UIManager.Instance.UpdateUI();
    }

    public void RemoveCharacter(Character oldCharacter, Character newCharacter)
    {
        characters.Remove(oldCharacter);
        if (newCharacter != null)
            characters.Add(newCharacter);
        
        zombieAmount = 0;
        foreach (Character character in characters)
        {
            if (character.CompareTag("Zombie"))
                zombieAmount = Mathf.Clamp(zombieAmount + 1, 0, characters.Count);
        }

        if (oldCharacter.CompareTag("Zombie"))
        {
            Destroy(oldCharacter.gameObject);
        }
        UIManager.Instance.UpdateUI();
    }
}