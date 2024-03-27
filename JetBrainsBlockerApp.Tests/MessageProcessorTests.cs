namespace Vadu.Tests
{
    [TestClass]
    public class MessageProcessorTests
    {
        [TestMethod]
        public void GetMessage_NoChanges_ReturnsNoChangesMessage()
        {
            // Act
            string result = MessageProcessor.GetMessage(0, 0, 0);

            // Assert
            Assert.AreEqual("No new rule affected!", result);
        }

        [TestMethod]
        public void GetMessage_NewRules_ReturnsCreateMessage()
        {
            // Act
            string result = MessageProcessor.GetMessage(2, 0, 0);

            // Assert
            Assert.AreEqual("Create new 2 rule(s)", result);
        }

        [TestMethod]
        public void GetMessage_UpdatedRules_ReturnsUpdateMessage()
        {
            // Act
            string result = MessageProcessor.GetMessage(0, 3, 0);

            // Assert
            Assert.AreEqual("Update 3 rule(s)", result);
        }

        [TestMethod]
        public void GetMessage_DeletedRules_ReturnsDeleteMessage()
        {
            // Act
            string result = MessageProcessor.GetMessage(0, 0, 4);

            // Assert
            Assert.AreEqual("Delete 4 rule(s)", result);
        }

        [TestMethod]
        public void GetMessage_MultipleChanges_ReturnsCombinedMessage()
        {
            // Act
            string result = MessageProcessor.GetMessage(2, 3, 4);

            // Assert
            Assert.AreEqual("Create new 2 rule(s), update 3 rule(s), delete 4 rule(s)", result);
        }
    }
}