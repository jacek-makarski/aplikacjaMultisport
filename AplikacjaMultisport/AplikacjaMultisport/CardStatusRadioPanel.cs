using System.Windows.Forms;

namespace AppMultisport {
    public partial class CardStatusRadioPanel : UserControl {

        public enum CardStatusSelection {
            Inactive,
            MultiActive,
            MultiPlus
        }

        private RadioButton RadioButtonOfCard(Card card) {
            if (card.Active) {
                if (card.Type == Card.CardType.MultiPlus) {
                    return radioButtonMultiPlus;
                } else {
                    return radioButtonMultiActive;
                }
            } else {
                return radioButtonInactiveCard;
            }
        }

        public CardStatusSelection SelectedOption {
            get {
                if (radioButtonMultiActive.Checked) {
                    return CardStatusSelection.MultiActive;
                }
                if (radioButtonMultiPlus.Checked) {
                    return CardStatusSelection.MultiPlus;
                }
                //if (radioButtonInactiveCard.Checked) {
                    return CardStatusSelection.Inactive;
                //}
            }
        }

        public CardStatusRadioPanel() {
            InitializeComponent();
        }

        public void SetupForNewCard() {
            radioButtonInactiveCard.Enabled = false;  //Nie można założyć karty od razu nieaktywnej.
            radioButtonMultiActive.Checked = true;
        }

        public void SetupForCard(Card currentCard) {
            RadioButton currentRadio = RadioButtonOfCard(currentCard);
            currentRadio.Text += " (aktualny)";
            currentRadio.Checked = true;
        }

        public void SetupForCards(Card currentCard, Card plannedCard) {
            RadioButtonOfCard(currentCard).Text += " (aktualny)";
            SetupForPlannedCard(plannedCard);
        }

        public void SetupForPlannedCard(Card plannedCard) {
            RadioButton plannedRadio = RadioButtonOfCard(plannedCard);
            plannedRadio.Text += " (planowany)";
            plannedRadio.Checked = true;
        }

        public void ClearSetup() {
            radioButtonInactiveCard.Enabled = true;
            radioButtonInactiveCard.Checked = true;
            radioButtonInactiveCard.Text = "nieaktywna";
            radioButtonMultiActive.Text = "multiActive";
            radioButtonMultiPlus.Text = "multiPlus";
        }

    }
}
