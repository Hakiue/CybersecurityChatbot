using System;

namespace CybersecurityChatbot.ChatbotCore
{
    /// <summary>
    /// Provides input validation and sanitization utilities for user-entered text.
    /// </summary>
    public static class InputValidator
    {
        // Maximum input length to guard against unusually long entries
        private const int MaxInputLength = 500;

        /// <summary>
        /// Validates a user's chat message.
        /// Returns a <see cref="ValidationResult"/> indicating whether the input is usable.
        /// </summary>
        public static ValidationResult Validate(string input)
        {
            // Empty or whitespace-only
            if (string.IsNullOrWhiteSpace(input))
                return ValidationResult.Fail("Input was empty. Please type a message.");

            // Too long
            if (input.Length > MaxInputLength)
                return ValidationResult.Fail(
                    $"Your message is too long (max {MaxInputLength} characters). Please shorten it.");

            // Only numbers / punctuation with no recognizable words
            if (IsNonAlphaContent(input))
                return ValidationResult.Fail(
                    "That doesn't look like a question. Try typing a cybersecurity topic!");

            return ValidationResult.Ok();
        }

        /// <summary>
        /// Validates a name entry — must contain at least one letter.
        /// </summary>
        public static ValidationResult ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return ValidationResult.Fail("Name cannot be empty.");

            foreach (char c in name)
                if (char.IsLetter(c)) return ValidationResult.Ok();

            return ValidationResult.Fail("Please enter a name that contains at least one letter.");
        }

        /// <summary>
        /// Returns true if the string contains no alphabetic characters.
        /// </summary>
        private static bool IsNonAlphaContent(string input)
        {
            foreach (char c in input)
                if (char.IsLetter(c)) return false;
            return true;
        }
    }

    /// <summary>
    /// Represents the outcome of an input validation check.
    /// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; } = string.Empty;

        private ValidationResult() { }

        public static ValidationResult Ok()
            => new ValidationResult { IsValid = true };

        public static ValidationResult Fail(string message)
            => new ValidationResult { IsValid = false, ErrorMessage = message };
    }
}
