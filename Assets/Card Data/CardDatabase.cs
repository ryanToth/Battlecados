using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace Assets.Card_Data
{
    class CardDatabase
    {
        private IEnumerable<Card> _commonCards;

        private IEnumerable<Card> _uncommonCards;

        private IEnumerable<Card> _rareCards;

        public CardDatabase()
        {
            _commonCards = ReadXML("CardXML/common_cards.xml", CardRarity.Common);
            _uncommonCards = ReadXML("CardXML/uncommon_cards.xml", CardRarity.Uncommon);
            _rareCards = ReadXML("CardXML/rare_cards.xml", CardRarity.Rare);
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
