using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Component.Entities
{
    public class Note
    {
        public int Id { get; set; }

        public int ItemId { get; private set; }

        public string Message { get; private set; }

        public Note(int id , int itemId, string message)
        {
            // Validate the message before setting it
            IsValidMessage(message);

            // Initialize the properties if the message is valid
            Id = id;
            ItemId = itemId;
            Message = message;
        }


        public void UpdateMessage(string newMessage)
        {
            // Validate the new message before updating
            IsValidMessage(newMessage);

            // Update the message if it's valid
            Message = newMessage;
        }


        private bool IsValidMessage(string message)
        {
            // Check if the message is null, empty, or exceeds 100 characters
            if (!string.IsNullOrWhiteSpace(message) && message.Length > 100)
                throw new ArgumentException("Message cannot be null, empty, or exceed 100 characters.", nameof(message));

            return true ;
        }
    }
}
