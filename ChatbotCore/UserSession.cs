namespace CybersecurityChatbot.ChatbotCore
{
    /// <summary>
    /// Represents the current user's session data, including their name
    /// and any profile information gathered during the conversation.
    /// Uses automatic properties for clean, encapsulated data access.
    /// </summary>
    public class UserSession
    {
        // ─── Automatic properties ─────────────────────────────────────────────────

        /// <summary>Gets or sets the user's name provided at startup.</summary>
        public string Name { get; set; } = "User";

        /// <summary>Gets or sets the user's self-reported favorite cybersecurity topic.</summary>
        public string? FavoriteTopic { get; set; }

        /// <summary>Gets or sets the timestamp of when the session started.</summary>
        public System.DateTime SessionStart { get; set; } = System.DateTime.Now;

        /// <summary>Gets or sets how many messages the user has sent this session.</summary>
        public int MessageCount { get; set; } = 0;

        // ─── Derived helpers ──────────────────────────────────────────────────────

        /// <summary>
        /// Returns a greeting string using the user's name.
        /// </summary>
        public string GetPersonalizedGreeting()
        {
            return $"Welcome back, {Name}! How can I help you stay cyber-safe today?";
        }

        /// <summary>
        /// Returns true if the session has lasted more than 5 exchanges —
        /// used to occasionally remind the user of the topic list.
        /// </summary>
        public bool ShouldShowTopicReminder()
        {
            return MessageCount > 0 && MessageCount % 5 == 0;
        }
    }
}
