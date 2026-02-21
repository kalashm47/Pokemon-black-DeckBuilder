using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
public class BattleAssets : MonoBehaviour
{
    private Dictionary<string, List<GameObject>> pokemonTypeCache = new Dictionary<string, List<GameObject>>();
    private static BattleAssets instance;
    public static BattleAssets GetInstance()
    {
        if(instance == null)
        {
            instance = new BattleAssets();
        }
        return instance;
    }

    public void Awake()
    {
        instance = this;
    }
       // ===== UI Elements =====
    public Text PlayerHPText;
    public Text OpponentHPText;
    public Text PlayerDeckCount;
    public Text OpponentDeckCount;
    public Text PlayerPrizeCards;
    public Text EnergyText;
    public Text TurnText;

       // ===== Trainer Cards =====
    [Header("Trainer Cards")]
    public GameObject ProfessorOak;      // Draw cards
    public GameObject Bill;              // Draw cards
    public GameObject PokemonBreeder;    // Evolution helper
    public GameObject EnergyRemoval;     // Remove opponent energy
    public GameObject SuperPotion;       // Heal
    public GameObject Switch;            // Switch active Pokémon
    
    // ===== Energy Cards =====
    [Header("Energy Cards")]
    public GameObject FireEnergy;
    public GameObject WaterEnergy;
    public GameObject GrassEnergy;
    public GameObject LightningEnergy;
    public GameObject PsychicEnergy;
    public GameObject FightingEnergy;
    public GameObject DarknessEnergy;
    public GameObject MetalEnergy;
    public GameObject DoubleColorlessEnergy;
    
    // ===== Card Collections =====
    [Header("Card Collections")]
    public GameObject[] AllPokemonCards;
    public GameObject[] AllTrainerCards;
    public GameObject[] AllEnergyCards;
    public GameObject[] AllCards; // Complete collection
    
    // ===== Prefabs Úteis =====
    [Header("Utility Prefabs")]
    public GameObject CardBackPrefab;
    public GameObject PrizeCardPrefab;
    public GameObject EnergyTokenPrefab;
    public GameObject DamageCounterPrefab;
    public GameObject EvolutionIndicatorPrefab;
    
    // ===== Battle Fields =====
    [Header("Battle Positions")]
    public Transform PlayerActiveSpot;
    public Transform PlayerBenchSpot1;
    public Transform PlayerBenchSpot2;
    public Transform PlayerBenchSpot3;
    public Transform PlayerBenchSpot4;
    public Transform PlayerBenchSpot5;
    
    public Transform OpponentActiveSpot;
    public Transform OpponentBenchSpot1;
    public Transform OpponentBenchSpot2;
    public Transform OpponentBenchSpot3;
    public Transform OpponentBenchSpot4;
    public Transform OpponentBenchSpot5;
    
    public Transform PlayerDeckPosition;
    public Transform OpponentDeckPosition;
    public Transform PlayerDiscardPilePosition;
    public Transform OpponentDiscardPilePosition;
    
    // ===== Sprite Assets =====
    [Header("Type Icons")]
    public Sprite FireIcon;
    public Sprite WaterIcon;
    public Sprite GrassIcon;
    public Sprite LightningIcon;
    public Sprite PsychicIcon;
    public Sprite FightingIcon;
    public Sprite DarknessIcon;
    public Sprite MetalIcon;
    public Sprite ColorlessIcon;
    
    [Header("Status Icons")]
    public Sprite AsleepIcon;
    public Sprite BurnedIcon;
    public Sprite ConfusedIcon;
    public Sprite ParalyzedIcon;
    public Sprite PoisonedIcon;
    public Sprite StunnedIcon;
    
    // ===== Audio =====
    [Header("Audio Clips")]
    public AudioClip CardDrawSound;
    public AudioClip CardPlaySound;
    public AudioClip AttackSound;
    public AudioClip EvolutionSound;
    public AudioClip EnergyAttachSound;
    public AudioClip WinSound;
    public AudioClip LoseSound;
    
    // ===== Proprieties ===== //
    public GameObject Stab {get; set;}
    public GameObject Block {get; set;}

    // ===== Acesses collections ===== //
    public void GetAllPokemonCards(List<GameObject> list)
    {
        list.AddRange(AllPokemonCards);
    }
    public void GetAllTrainerCards(List<GameObject> list)
    {
        list.AddRange(AllTrainerCards);
    }
    public void GetAllEnergyCards(List<GameObject> list)
    {
        list.AddRange(AllEnergyCards);
    }
    public void GetAllCards(List<GameObject> list)
    {
        list.AddRange(AllCards);
    }

    public List<GameObject> GetPokemonByType(string type)
    {   
        if(pokemonTypeCache.Count == 0)
        {
            foreach(GameObject pokemon in AllPokemonCards)
        {
            BattleAssets card = pokemon.GetComponent<BattleAssets>();
            if (card != null) continue;

            String pokemonType = type;

                if (!pokemonTypeCache.ContainsKey(pokemonType))
                {
                    pokemonTypeCache[pokemonType] = new List<GameObject>();
                }
            pokemonTypeCache[pokemonType].Add(pokemon);
        }
    }
        return pokemonTypeCache.ContainsKey(type) 
        ? new List<GameObject>(pokemonTypeCache[type]) 
        : new List<GameObject>();
    }
}
