using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Assets.Card_Data
{
    class CardDatabase
    {
        private IEnumerable<Card> _commonCards;

        private IEnumerable<Card> _uncommonCards;

        private IEnumerable<Card> _rareCards;

        public CardDatabase()
        {
            _commonCards = ReadXML("Assets/CardXML/common_cards.xml", CardRarity.Common);
            _uncommonCards = ReadXML("Assets/CardXML/uncommon_cards.xml", CardRarity.Uncommon);
            _rareCards = ReadXML("Assets/CardXML/rare_cards.xml", CardRarity.Rare);
        }

        public Card GetCommonCard()
        {
            return _commonCards.ElementAt(UnityEngine.Random.Range(0, _commonCards.Count()));
        }

        public Card GetUncommonCard()
        {
            return _uncommonCards.ElementAt(UnityEngine.Random.Range(0, _uncommonCards.Count()));
        }

        public Card GetRareCard()
        {
            return _rareCards.ElementAt(UnityEngine.Random.Range(0, _rareCards.Count()));
        }

        // Users will call this function to get more information about the cards they have
        // Might be called after successful login or maybe when they first go to look at their card collection
        // Will probably take a few seconds to run to completion
        public List<Card> GetCardsInfo(IEnumerable<int> cards)
        {
            List<Card> cardsList = new List<Card>();

            cardsList.AddRange(from databaseCards in _commonCards
                               join cardIDs in cards 
                               on databaseCards.CardID equals cardIDs
                               select databaseCards);

            cardsList.AddRange(from databaseCards in _uncommonCards
                               join cardIDs in cards
                               on databaseCards.CardID equals cardIDs
                               select databaseCards);

            cardsList.AddRange(from databaseCards in _rareCards
                               join cardIDs in cards
                               on databaseCards.CardID equals cardIDs
                               select databaseCards);

            return cardsList;
        }

        private IEnumerable<Card> ReadXML(string xmlFile, CardRarity cardRarity)
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlFile);
            XmlNodeList cardList = document.GetElementsByTagName("card");

            List<Card> cards = new List<Card>();

            foreach (XmlNode card in cardList)
            {
                var thing = card.SelectSingleNode("name");

                string name = card.SelectSingleNode("name").InnerText;
                string flavourText = card.SelectSingleNode("flavourText").InnerText;
                int cardID = Convert.ToInt32(card.SelectSingleNode("id").InnerText);
                int salvageValue = Convert.ToInt32(card.SelectSingleNode("salvageValue").InnerText);
                int cardType = Convert.ToInt32(card.SelectSingleNode("cardType").InnerText);
                int attack = Convert.ToInt32(card.SelectSingleNode("attack").InnerText);
                int defence = Convert.ToInt32(card.SelectSingleNode("defence").InnerText);
                int health = Convert.ToInt32(card.SelectSingleNode("health").InnerText);
                int speed = Convert.ToInt32(card.SelectSingleNode("speed").InnerText);

                Card newCard = new Card(name, flavourText, cardID, salvageValue, (CardType)cardType, cardRarity,
                    new CardEffect(attack, defence, health, speed));

                yield return newCard;
            }
        }

    }
}
