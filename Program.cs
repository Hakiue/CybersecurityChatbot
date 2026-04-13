using System;
using CybersecurityChatbot.ChatbotCore;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Entry point for the Cybersecurity Awareness Chatbot application.
    /// Initialisms and starts the chatbot session.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize and run the chatbot
            var chatbot = new ChatbotEngine();
            chatbot.Start();
        }
    }
}
