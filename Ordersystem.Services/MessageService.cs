using Ordersystem.DataAccess;
using Ordersystem.DataObjects;

namespace Ordersystem.Services
{
    // Interface to define the contract for the MessageService class
    public interface IMessageService
    {
        List<Message> GetAllMessages();
        Message? GetMessageByID(int id);
        Message Create(Message message);
        Message Update(int id, Message message);
        bool Delete(int id);
    }

    /// <summary>
    /// The `MessageService` class demonstrates the use of CRUD (Create, Read, Update, Delete)
    /// operations.
    /// It implements the `IMessageService` interface and provides the necessary methods for working
    /// with messages.
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Retrieves all messages from the database.
        /// </summary>
        /// <returns>A list of Message objects representing all messages in the database.</returns>
        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        /// <summary>
        /// Retrieves a message from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the message to retrieve.</param>
        /// <returns>The Message object corresponding to the specified ID, or null if not found.</returns>
        public Message? GetMessageByID(int id)
        {
            return _context.Messages.Where(c => c.MessageID == id).FirstOrDefault();
        }

        /// <summary>
        /// Creates a new message in the database.
        /// </summary>
        /// <param name="message">The Message object representing the message to create.</param>
        /// <returns>The Message object representing the created message.</returns>
        public Message Create(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        /// <summary>
        /// Updates an existing message in the database with the provided data.
        /// </summary>
        /// <param name="id">The ID of the message to update.</param>
        /// <param name="newMessage">The Message object containing the updated data for the message.</param>
        /// <returns>The Message object representing the updated message, or null if the message with the specified ID is not found.</returns>
        public Message Update(int id, Message newMessage)
        {
            var messageToUpdate = _context.Messages.Where(c => c.MessageID == id).FirstOrDefault();

            if (messageToUpdate != null)
            {
                // Update only properties that were changed
                messageToUpdate.Title= newMessage.Title;
                messageToUpdate.Content = newMessage.Content;
                messageToUpdate.Date = newMessage.Date;

                _context.Update(messageToUpdate);
                _context.SaveChanges();

                return messageToUpdate;
            }

            return null;
        }

        /// <summary>
        /// Deletes a message from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the message to delete.</param>
        /// <returns>True if the message was successfully deleted, false otherwise.</returns>
        public bool Delete(int id)
        {
            var result = _context.Messages.ToList().FirstOrDefault(c => c.MessageID == id, null);
            if (result != null)
            {
                _context.Messages.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
