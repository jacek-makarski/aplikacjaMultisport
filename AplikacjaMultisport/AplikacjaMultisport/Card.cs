using System;

namespace AppMultisport {

    public class Card {

        public enum CardType {
            MultiActive,
            MultiPlus
        }

        public enum TypeOfChange {
            NoChange,
            ActivationChange,
            TypeChange
        }

        public bool Active { get; set; }
        public CardType Type { get; set; }

        public Card(bool active, CardType type) {
            Active = active;
            Type = type;
        }

        public Card(Card another) {
            Active = another.Active;
            Type = another.Type;
        }

        public Card(CardStatusRadioPanel.CardStatusSelection selection) {
            switch (selection) {
                case CardStatusRadioPanel.CardStatusSelection.MultiActive:
                    Active = true;
                    Type = CardType.MultiActive;
                    break;
                case CardStatusRadioPanel.CardStatusSelection.MultiPlus:
                    Active = true;
                    Type = CardType.MultiPlus;
                    break;
                case CardStatusRadioPanel.CardStatusSelection.Inactive:
                    Active = false;
                    Type = CardType.MultiActive;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Update(TypeOfChange appliedChange) {
            switch (appliedChange) {
                case TypeOfChange.ActivationChange:
                    Active = !Active;
                    break;
                case TypeOfChange.TypeChange:
                    Active = true;  //Zamawiana karta nowego typu jest od razu aktywna
                    if (Type == CardType.MultiActive) {
                        Type = CardType.MultiPlus;
                    } else {
                        Type = CardType.MultiActive;
                    }
                    break;
                case TypeOfChange.NoChange:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static TypeOfChange DetermineTypeOfChange(Card changedCard, CardStatusRadioPanel.CardStatusSelection changeSelection) {
            if (changedCard != null) {
                switch (changeSelection) {
                    case CardStatusRadioPanel.CardStatusSelection.MultiActive:
                        if (changedCard.Type == CardType.MultiActive) {
                            return changedCard.Active ? TypeOfChange.NoChange : TypeOfChange.ActivationChange;
                        } else {
                            return TypeOfChange.TypeChange;
                        }
                    case CardStatusRadioPanel.CardStatusSelection.MultiPlus:
                        if (changedCard.Type == CardType.MultiPlus) {
                            return changedCard.Active ? TypeOfChange.NoChange : TypeOfChange.ActivationChange;
                        } else {
                            return TypeOfChange.TypeChange;
                        }
                    case CardStatusRadioPanel.CardStatusSelection.Inactive:
                        return changedCard.Active ? TypeOfChange.ActivationChange : TypeOfChange.NoChange;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } else {
                return TypeOfChange.TypeChange;  //Zamówienie nowej karty.
            }
        }

        public static TypeOfChange DetermineTypeOfChange(Card cardBefore, Card cardAfter) {
            if (cardBefore != null) {
                if (cardBefore.Type == cardAfter.Type) {
                    if (cardBefore.Active == cardAfter.Active) {
                        return TypeOfChange.NoChange;
                    } else {
                        return TypeOfChange.ActivationChange;
                    }
                } else {
                    return TypeOfChange.TypeChange;
                }
            } else {
                return TypeOfChange.TypeChange;  //Zamówienie nowej karty.
            }

        }

        public static Card AfterUpdate(Card updatedCard, TypeOfChange appliedChange) {
            Card result = new Card(updatedCard);
            result.Update(appliedChange);
            return result;
        }
        
    }
    
}