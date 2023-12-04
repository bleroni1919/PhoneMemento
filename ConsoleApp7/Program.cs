using System;

namespace MementoDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an Instance of the Originator and setting the current state as a phone
            Originator originator = new Originator
            {
                Phone = new Phone("Samsung", "$950", false)
            };

            // Storing the Internal State (Memento) of the Originator in the Caretaker (Store Room)
            Caretaker caretaker = new Caretaker();
            IPhoneMemento memento = originator.CreateMemento();
            caretaker.AddMemento(memento);

            // Changing the Originator Current State to a different phone model
            originator.Phone = new Phone("Iphone", "$1500", true);

            // Storing the Internal State (Memento) of the Originator in the Caretaker (Store Room) again
            memento = originator.CreateMemento();
            caretaker.AddMemento(memento);

            // Changing the Originator Current State to another phone model
            originator.Phone = new Phone("Nokia", "$700", true);

            // The Current State of the Originator is now ModelZ phone
            Console.WriteLine("\nOrignator Current State: " + originator.GetDetails());

            // Restoring the Originator to one of its previous states
            // We have added two Mementos to the Caretaker
            // Index-0 means the First Memento i.e. ModelX phone
            // Index-1 means the Second Memento i.e. ModelY phone
            Console.WriteLine("\nOriginator Restoring...");
            originator.SetMemento(caretaker.GetMemento(0));
            Console.WriteLine("\nOrignator Current State: " + originator.GetDetails());

            Console.ReadKey();
        }
    }
}
