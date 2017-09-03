namespace AppMultisport {

    public class EmployeeWithCard {

        public Employee Employee { get; set; }
        public Card Card { get; set; }

        public EmployeeWithCard(Employee employee, Card card) {
            Employee = employee;
            Card = card;
        }

    }

}
