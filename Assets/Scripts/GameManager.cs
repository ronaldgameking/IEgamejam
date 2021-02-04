using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    
    public float zombieAmount = 0;

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
    }

    private void Start()
    {
        Character[] chars = FindObjectsOfType<Character>();

        characters = new List<Character>();
        foreach (Character character in chars)
        {
            characters.Add(character);
            if (character.CompareTag("Zombie"))
                zombieAmount++;
        }
        
        UIManager.Instance.UpdateUI();
    }

    public void RemoveCharacter(Character oldCharacter, Character newCharacter)
    {
        characters.Remove(oldCharacter);
        if (newCharacter != null)
            characters.Add(newCharacter);

        if (oldCharacter.CompareTag("Zombie"))
            zombieAmount = Mathf.Clamp(zombieAmount + 1, 0, characters.Count);
        
        UIManager.Instance.UpdateUI();
    }
}