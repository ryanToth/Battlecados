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

        private Random _rnd = new Random();

        public CardDatabase()
        {
            _commonCards = ReadXML("common_cards.xml", CardRarity.Common);
            _uncommonCards = ReadXML("uncommon_cards.xml", CardRarity.Uncommon);
            _rareCards = ReadXML("rare_cards.xml", CardRarity.Rare);
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

                yield return new Card(name, flavourText, cardID, salvageValue, (CardType)cardType, cardRarity,
                    new CardEffect(attack, defence, health, speed));
            }
        }

        public Card GetCommonCard()
        {
            return _commonCards.ElementAt(_rnd.Next(0, _commonCards.Count()-1));
        }

        public Card GetUncommonCard()
        {
            return _uncommonCards.ElementAt(_rnd.Next(0, _uncommonCards.Count() - 1));
        }

        public Card GetRareCard()
        {
            return _rareCards.ElementAt(_rnd.Next(0, _rareCards.Count() - 1));
        }

    }
}
