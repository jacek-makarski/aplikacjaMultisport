using System;

namespace AppMultisport {

    public static class Rules {

        public static int NewCardDeadline => 21;
        public static int ActivationChangeDeadline => 26;
        private static string ActivationDeadlineMessage => "Zmianę aktywacji karty można zgłaszać do " + ActivationChangeDeadline + ". dnia miesiąca.";
        private static string NewCardDeadlineMessage => "Zamówienia nowych kart można zgłaszać lub wycofywać do " + NewCardDeadline + ". dnia miesiąca.";

        public static string MotivationProgramCompanyName => "B";
        public static decimal MultiActivePrice => 30;
        public static string MultiActiveName => "Multiactive";
        public static decimal MultiPlusPrice => 111;
        public static string MultiPlusName => "MultiSport Plus";

        public static bool CheckDeadline(DateTime date, Card.TypeOfChange type) {
            switch (type) {
                case Card.TypeOfChange.ActivationChange:
                    return (date.Day <= ActivationChangeDeadline);
                case Card.TypeOfChange.TypeChange:
                    return (date.Day <= NewCardDeadline);
                case Card.TypeOfChange.NoChange:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static String DeadlineMessage(Card.TypeOfChange type) {
            switch (type) {
                case Card.TypeOfChange.ActivationChange:
                    return ActivationDeadlineMessage;
                case Card.TypeOfChange.TypeChange:
                    return NewCardDeadlineMessage;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static decimal CardPrice(Card card) {
            switch (card.Type) {
                case Card.CardType.MultiActive:
                    return MultiActivePrice;
                case Card.CardType.MultiPlus:
                    return MultiPlusPrice;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }

}