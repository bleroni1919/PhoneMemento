namespace MementoDesignPattern
{
    // This is going to be a class that holds the information about the Originator’s saved state.
    // Stores the internal state of the Originator object.
    public class Memento : IPhoneMemento
    {
        // The following variable is going to hold the internal state of the Originator object
        public Phone Phone { get; set; }

        // Initializing the internal state of the Originator object using Constructor
        public Memento(Phone phone)
        {
            Phone = phone;
        }

        // This Method is going to return the Internal State of the Originator
        public string GetDetails()
        {
            return "Memento [Phone=" + Phone.GetDetails() + "]";
        }

        // Implementation of the IPhoneMemento interface to restore the phone state
        public Phone Restore()
        {
            // You can add additional logic here if needed
            return new Phone(Phone.Model, Phone.Price, Phone.HasCamera);
        }
    }
}