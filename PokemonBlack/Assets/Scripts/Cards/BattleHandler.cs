using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BattleHandler : MonoBehaviour
{
    public static BattleHandler instance; 
      public static System.Random rng = new System.Random();
    public static BattleHandler GetInstance(){ return instance;}

    public delegate void OnDeathEventHandler();
    public event OnDeathEventHandler onDeath;

    public delegate void OnVictoryEventHandler();
    public event OnVictoryEventHandler onVictory;

    private int BASE_CARD_DRAWN = 5;

    private float MAX_PLAYER_HEALTH = 100f;
    private float CURRENT_PLAYER_HEALTH = 100f;

    private float MAX_ENEMY_HEALTH = 100f;

    private float CURRENT_ENEMY_HEALTH = 100F;
    private Deck fullDeck;
    private Deck drawPile;
    private Deck discardPile;

    private GameObject handZone;
    private GameObject gameOverScreen;
    private GameObject victoryScreen;

    private void Awake()
    {
        instance = this;
    }

    private void EndTurn()
    {
        
    }

    public void HandleCardPlayed(GameObject cardObject)
    {
        Card card = cardObject.GetComponent<Card>();
        Card.cardTarget target = card.target;

        if(target == Card.cardTarget.Enemy)
        {
            CURRENT_ENEMY_HEALTH = card.damage;
        } 
        else if (target == Card.cardTarget.Self)
        {
            CURRENT_PLAYER_HEALTH += card.block;
        }
        UpdateHealthBars();

        discardPile.Add(cardObject);
        Destroy(cardObject.GetComponent<Draggable>().GetPlaceholder());
        cardObject.transform.SetParent(BattleHandler.GetInstance().GetHandZone().transform);
        cardObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        cardObject.SetActive(false);
    }

      private void UpdateHealthBars()
    {
        BattleAssets.GetInstance().PlayerHPText.text = CURRENT_PLAYER_HEALTH + "/" + MAX_PLAYER_HEALTH;
        BattleAssets.GetInstance().OpponentHPText.text = CURRENT_ENEMY_HEALTH + "/" + MAX_ENEMY_HEALTH;

        if (CURRENT_PLAYER_HEALTH <= 0f)
        {
            GameOver();
        }
        if (CURRENT_ENEMY_HEALTH <= 0f)
        {
            Victory();
        }
    }

      private void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

     private void Victory()
    {
        victoryScreen.SetActive(true);
        //StartCoroutine(LoadYourAsyncScene());
    }
    public class Deck
    {
        private List<GameObject> cards;

        public Deck(List<GameObject> cards)
        {
            this.cards = cards;
        }

        public List<GameObject> GetCards()
        {
            return cards;
        }

        public void Add(GameObject card)
        {
            cards.Add(card);
        }

        public void Add(List<GameObject> newCards)
        {
            foreach(GameObject card in newCards)
            {
                cards.Add(card);
            }
        }

        public bool Contains(GameObject card)
        {
            foreach(GameObject c in cards)
            {
                if (c.GetComponent<Card>().cardName == card.GetComponent<Card>().cardName)
                    return true;
            }
            return false;
        }

        //Removes the first card with the same name in the deck
        public void Remove(GameObject card)
        {
            foreach (GameObject c in cards)
            {
                if (c.GetComponent<Card>().cardName == card.GetComponent<Card>().cardName)
                {
                    cards.Remove(c);
                    return;
                }
            }
        }
    }
}
