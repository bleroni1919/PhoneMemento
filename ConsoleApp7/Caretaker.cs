using System;
using System.Collections.Generic;

namespace MementoDesignPattern
{
    // This is going to be a class that is used to hold a Memento object for later use.
    // This acts as a store only; it never checks or modifies the contents of the Memento object.
    public class Caretaker
    {
        // This variable is going to hold the List of Mementos that are used by the Originator.
        private List<IPhoneMemento> PhoneList = new List<IPhoneMemento>();

        // This Method will add the memento i.e. the internal state of the Originator into the Caretaker i.e. Store Room 
        public void AddMemento(IPhoneMemento memento)
        {
            PhoneList.Add(memento);
            Console.WriteLine("Phone snapshots maintained by CareTaker: " + memento.Restore().GetDetails());
        }

        // This Method is used to return one of the Previous Originator Internal States which saved in the Caretaker
        public IPhoneMemento GetMemento(int index)
        {
            return PhoneList[index];
        }
    }
}