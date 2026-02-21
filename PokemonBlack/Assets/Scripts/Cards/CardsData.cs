using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="NewPokemonCard", menuName ="Pokemon Deck/Card")]
public class CardsData : ScriptableObject
{
    [Header("Basic Informations")]
    public string cardName;
    public Sprite ArtWork;
    public PokemonType pokemonType;
    public Rarity rarity;

    [Header("Battle Attributes")]
    public int damage;
    public int energyCost;
    public int hp;

    [Header("Effects")]
    public CardEffect effect;
    public int effectValue;
    public enum PokemonType
    {
        Normal, Fire, Water, Grass, Electric, Psychic, Fighting, Dark
    }
    public enum Rarity
    {
        Common, Uncommon, Rare
    }
    public enum CardRarity
    {
        None, Burn, Paralyze, Poison, Heal, DrawCard
    }
    public enum CardEffect
    {
    None, Burn, Paralyze, Poison, Heal, DrawCard
    }
}
