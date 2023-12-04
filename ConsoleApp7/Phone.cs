namespace MementoDesignPattern
{
    // This is the Model class that is going to hold the Product information, i.e., Phone Details
    public class Phone
    {
        // Properties of the Phone
        public string Model { get; set; }
        public string Price { get; set; }
        public bool HasCamera { get; set; }

        // Initializing the Properties using Constructor
        public Phone(string model, string price, bool hasCamera)
        {
            Model = model;
            Price = price;
            HasCamera = hasCamera;
        }

        // Fetching the Details of the Phone
        public string GetDetails()
        {
            return $"Phone [Model={Model}, Price={Price}, HasCamera={HasCamera}]";
        }
    }

    // Interface for Memento to ensure adherence to SOLID principles
    public interface IPhoneMemento
    {
        Phone Restore();
    }

    // Concrete Memento class
    public class PhoneMemento : IPhoneMemento
    {
        private readonly Phone _phone;

        public PhoneMemento(Phone phone)
        {
            _phone = phone;
        }

        public Phone Restore()
        {
            // You can add additional logic here if needed
            return new Phone(_phone.Model, _phone.Price, _phone.HasCamera);
        }
    }
}