using NUnit.Framework;

namespace MementoDesignPattern.Tests
{
    [TestFixture]
    public class PhoneTests
    {
        [Test]
        public void PhoneInitialization_WithValidProperties_ShouldNotThrowException()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new Phone("ValidModel", "ValidPrice", true));
        }

        [Test]
        public void PhoneInitialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var model = "ModelX";
            var price = "1500";
            var hasCamera = false;

            // Act
            var phone = new Phone(model, price, hasCamera);

            // Assert
            Assert.IsNotNull(phone);
            Assert.AreEqual(model, phone.Model);
            Assert.AreEqual(price, phone.Price);
            Assert.AreEqual(hasCamera, phone.HasCamera);
        }

        [Test]
        public void GetDetails_ShouldReturnNonNullString()
        {
            // Arrange
            var phone = new Phone("TestModel", "TestPrice", true);

            // Act
            var details = phone.GetDetails();

            // Assert
            Assert.IsNotNull(details);
        }
    }

    [TestFixture]
    public class PhoneMementoTests
    {
        [Test]
        public void Restore_ShouldReturnCorrectPhoneDetails()
        {
            // Arrange
            var phone = new Phone("Model1", "1000", true);
            var phoneMemento = new PhoneMemento(phone);

            // Act
            var restoredPhone = phoneMemento.Restore();

            // Assert
            Assert.IsNotNull(restoredPhone);
            Assert.AreEqual("Model1", restoredPhone.Model);
            Assert.AreEqual("1000", restoredPhone.Price);
            Assert.AreEqual(true, restoredPhone.HasCamera);
        }
    }

    [TestFixture]
    public class CaretakerTests
    {
        [Test]
        public void AddMemento_And_GetMemento_ShouldWorkCorrectly()
        {
            // Arrange
            var caretaker = new Caretaker();
            var phone1 = new Phone("Model1", "1000", true);
            var phone2 = new Phone("Model2", "1200", false);
            var phoneMemento1 = new PhoneMemento(phone1);
            var phoneMemento2 = new PhoneMemento(phone2);

            // Act
            caretaker.AddMemento(phoneMemento1);
            caretaker.AddMemento(phoneMemento2);

            var retrievedMemento1 = caretaker.GetMemento(0);
            var retrievedMemento2 = caretaker.GetMemento(1);

            // Assert
            Assert.IsNotNull(retrievedMemento1);
            Assert.IsNotNull(retrievedMemento2);

            Assert.AreEqual("Model1", retrievedMemento1.Restore().Model);
            Assert.AreEqual("1000", retrievedMemento1.Restore().Price);
            Assert.AreEqual(true, retrievedMemento1.Restore().HasCamera);

            Assert.AreEqual("Model2", retrievedMemento2.Restore().Model);
            Assert.AreEqual("1200", retrievedMemento2.Restore().Price);
            Assert.AreEqual(false, retrievedMemento2.Restore().HasCamera);
        }
    }
}

