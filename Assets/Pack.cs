using Assets.Card_Data;
using System.Collections;
using System.Collections.Generic;

public abstract class Pack {

    protected int _common;
    protected int _uncommon;
    protected int _rare;

    protected int _cost;

    public int Cost
    {
        get
        {
            return _cost;
        }
    }

    public List<Card> Open()
    {
        List<Card> cards = new List<Card>();
        CardDatabase cardDatabase = new CardDatabase();

        for (int i = 0; i < _common; i++)
        {
            // Go into the database, grab a common card and add it to cards
            cards.Add(cardDatabase.GetCommonCard());
        }

        for (int i = 0; i < _uncommon; i++)
        {
            // Go into the database, grab an uncommon card and add it to cards
            cards.Add(cardDatabase.GetUncommonCard());
        }

        for (int i = 0; i < _rare; i++)
        {
            // Go into the database, grab a rare card and add it to cards
            cards.Add(cardDatabase.GetRareCard());
        }

        return cards;
    }

}
