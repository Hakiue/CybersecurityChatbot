using System;
using System.Collections.Generic;

namespace CybersecurityChatbot.ChatbotCore
{
    /// <summary>
    /// Contains all predefined responses and the logic for matching user input
    /// to relevant cybersecurity topics.
    /// </summary>
    public class ResponseEngine
    {
        private readonly Random _random = new Random();

        // ─── Static single responses keyed by topic keyword ──────────────────────
        private readonly Dictionary<string, string> _keywordResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // ── Passwords ──────────────────────────────────────────────────────────
            ["password"] =
                "Use a strong, unique password for every account — at least 12 characters " +
                "combining uppercase, lowercase, numbers, and symbols. A password manager " +
                "like Bitwarden or LastPass can help you keep track of them all safely.",

            // ── Phishing ───────────────────────────────────────────────────────────
            ["phishing"] =
                "Phishing emails pretend to be from trusted sources to steal your information. " +
                "Always check the sender's email address carefully, avoid clicking suspicious links, " +
                "and never enter your credentials on a site you reached via an email link.",

            // ── Safe Browsing ──────────────────────────────────────────────────────
            ["safe browsing"] =
                "Safe browsing starts with looking for HTTPS in the URL bar. Avoid downloading " +
                "files from unknown websites, use an updated browser, and consider a reputable " +
                "ad blocker to reduce exposure to malicious ads.",

            ["browsing"] =
                "When browsing online, always verify the site uses HTTPS, avoid clicking pop-up ads, " +
                "and never download software from unofficial sources. Keep your browser updated " +
                "to protect against known vulnerabilities.",

            // ── Two-Factor Authentication ──────────────────────────────────────────
            ["two-factor"] =
                "Two-factor authentication (2FA) adds a second layer of security beyond your password. " +
                "Even if someone steals your password, they still cannot access your account " +
                "without the second factor — usually a code sent to your phone.",

            ["2fa"] =
                "Enable two-factor authentication (2FA) on all important accounts — email, banking, " +
                "and social media. Authenticator apps like Google Authenticator are more secure " +
                "than SMS-based 2FA.",

            ["authentication"] =
                "Authentication verifies who you are before granting access. Strong authentication " +
                "combines something you know (password), something you have (phone), and something " +
                "you are (fingerprint). Multi-factor authentication (MFA) uses two or more of these.",

            // ── CIA Triad ──────────────────────────────────────────────────────────
            ["cia triad"] =
                "The CIA Triad is the foundation of cybersecurity:\n" +
                "   🔒 Confidentiality — ensuring only authorized people can access data.\n" +
                "   ✅ Integrity — ensuring data is accurate and has not been tampered with.\n" +
                "   ⚡ Availability — ensuring systems and data are accessible when needed.\n" +
                "Every cybersecurity decision should protect all three principles.",

            ["cia"] =
                "In cybersecurity, CIA stands for Confidentiality, Integrity, and Availability — " +
                "known as the CIA Triad. It is the core framework used to evaluate the security " +
                "of any information system. Type 'CIA triad' to learn more.",

            ["confidentiality"] =
                "Confidentiality means keeping information private and only accessible to authorized people. " +
                "Encryption, access controls, and strong passwords are key tools for maintaining " +
                "confidentiality. It is the 'C' in the CIA Triad.",

            ["integrity"] =
                "Integrity in cybersecurity means ensuring that data is accurate, complete, and " +
                "has not been altered without authorization. Hashing, digital signatures, and " +
                "checksums are used to verify data integrity. It is the 'I' in the CIA Triad.",

            ["availability"] =
                "Availability means ensuring that systems and data are accessible to authorized " +
                "users whenever needed. DDoS attacks, hardware failures, and ransomware all " +
                "threaten availability. Backups and redundancy help maintain it. It is the 'A' in the CIA Triad.",

            // ── Encryption ────────────────────────────────────────────────────────
            ["encryption"] =
                "Encryption converts data into an unreadable format that can only be decoded with " +
                "the correct key. It protects data in transit (like HTTPS) and at rest (like " +
                "encrypted hard drives). AES and RSA are widely used encryption standards.",

            ["https"] =
                "HTTPS (HyperText Transfer Protocol Secure) encrypts data between your browser " +
                "and the website. Always look for the padlock icon in your browser's address bar " +
                "before entering passwords or payment details on any site.",

            // ── Malware & Threats ─────────────────────────────────────────────────
            ["malware"] =
                "Malware is malicious software that can damage or gain unauthorized access to your system. " +
                "Types include viruses, trojans, spyware, and ransomware. Keep your OS and antivirus " +
                "updated, avoid pirated software, and never plug in unknown USB drives.",

            ["virus"] =
                "A computer virus is malicious code that attaches itself to legitimate programs and " +
                "spreads when those programs are run. Always use reputable antivirus software, " +
                "keep it updated, and avoid downloading files from untrusted sources.",

            ["trojan"] =
                "A Trojan horse is malware disguised as legitimate software. Once installed, it can " +
                "give attackers remote access to your system. Only download software from official " +
                "sources and verified publishers.",

            ["spyware"] =
                "Spyware secretly monitors your activity and collects personal information without " +
                "your knowledge. It can capture passwords, banking details, and browsing history. " +
                "Use reputable antivirus/anti-spyware tools and avoid suspicious downloads.",

            ["ransomware"] =
                "Ransomware encrypts your files and demands payment for the key. " +
                "Back up your data regularly to an offline or cloud drive, " +
                "keep your software updated, and avoid opening email attachments from unknown senders.",

            ["ddos"] =
                "A DDoS (Distributed Denial of Service) attack floods a server with traffic to make " +
                "it unavailable to users. Organizations defend against DDoS attacks using firewalls, " +
                "traffic filtering, and content delivery networks (CDNs).",

            ["keylogger"] =
                "A keylogger records every keystroke you make, capturing passwords and sensitive data. " +
                "Protect yourself by using virtual keyboards for sensitive input, keeping antivirus " +
                "updated, and avoiding installing unknown software.",

            // ── Social Engineering & Scams ────────────────────────────────────────
            ["social engineering"] =
                "Social engineering manipulates people into giving up confidential information. " +
                "Tactics include pretexting, baiting, and impersonation. " +
                "Be sceptical of unexpected calls or messages — legitimate companies will never " +
                "pressure you for immediate personal information.",

            ["scam"] =
                "Online scams are increasingly sophisticated in South Africa. Be wary of unsolicited " +
                "offers, urgency-based pressure, and requests for personal information. " +
                "When in doubt, contact the organization directly using official contact details.",

            ["vishing"] =
                "Vishing (voice phishing) involves scammers calling you pretending to be from " +
                "trusted organizations like banks or SARS. Never share OTPs, passwords, or banking " +
                "details over the phone. Hang up and call back using the official number.",

            ["smishing"] =
                "Smishing is phishing via SMS. Scammers send fake text messages with malicious links " +
                "or requests for personal information. Never click links in unexpected SMS messages — " +
                "go directly to the official website instead.",

            ["pretexting"] =
                "Pretexting is when an attacker fabricates a scenario to trick you into giving up " +
                "information — for example, someone pretending to be IT support asking for your password. " +
                "Always verify a person's identity through official channels before sharing anything.",

            // ── Network & Infrastructure ──────────────────────────────────────────
            ["wifi"] =
                "Public Wi-Fi networks are often unsecured and can be monitored by attackers. " +
                "Avoid accessing banking or sensitive accounts on public Wi-Fi. " +
                "If you must connect, use a trusted VPN to encrypt your traffic.",

            ["vpn"] =
                "A VPN (Virtual Private Network) encrypts your internet connection and hides your " +
                "IP address. Use one especially on public networks, but choose a reputable paid " +
                "provider — free VPNs can sometimes log and sell your data.",

            ["firewall"] =
                "A firewall monitors and controls incoming and outgoing network traffic based on " +
                "security rules. It acts as a barrier between your trusted network and untrusted " +
                "external networks. Always keep your firewall enabled.",

            ["patch"] =
                "Software patches fix security vulnerabilities that attackers could exploit. " +
                "Always install updates promptly for your OS, browser, and apps. " +
                "Unpatched systems are one of the most common entry points for cyberattacks.",

            ["update"] =
                "Keeping your software updated is one of the simplest and most effective cybersecurity " +
                "measures. Updates often contain critical security patches. Enable automatic updates " +
                "where possible so you are always protected.",

            // ── Privacy & Data ────────────────────────────────────────────────────
            ["privacy"] =
                "Protect your online privacy by reviewing app permissions regularly, using a VPN on " +
                "public Wi-Fi, enabling 2FA, and being mindful of what personal information you " +
                "share on social media and online forms.",

            ["identity theft"] =
                "Identity theft occurs when someone steals your personal information to commit fraud. " +
                "Monitor your bank statements regularly, use strong unique passwords, enable 2FA, " +
                "and be careful about what personal details you share online.",

            ["data breach"] =
                "A data breach is when unauthorized individuals access confidential data. " +
                "If your data is breached, change your passwords immediately, enable 2FA, " +
                "monitor your accounts for suspicious activity, and consider a credit freeze.",

            ["popia"] =
                "POPIA (Protection of Personal Information Act) is South Africa's data privacy law. " +
                "It regulates how organizations collect, store, and use personal information. " +
                "Citizens have the right to know what data is held about them and to request its deletion.",

            // ── Backup & Recovery ─────────────────────────────────────────────────
            ["backup"] =
                "Regular backups are your best defense against ransomware and data loss. " +
                "Follow the 3-2-1 rule: keep 3 copies of data, on 2 different media types, " +
                "with 1 copy stored offsite or in the cloud.",

            // ── Cybersecurity Concepts ────────────────────────────────────────────
            ["cyber attack"] =
                "A cyberattack is a deliberate attempt to breach information systems. Common types " +
                "include phishing, malware, DDoS, man-in-the-middle, and SQL injection. " +
                "South Africa is among the most targeted countries in Africa for cyberattacks.",

            ["hacker"] =
                "Hackers are people who exploit vulnerabilities in computer systems. " +
                "White hat hackers (ethical hackers) help find and fix vulnerabilities. " +
                "Black hat hackers exploit them for malicious purposes. " +
                "Grey hat hackers fall somewhere in between.",

            ["ethical hacking"] =
                "Ethical hacking (penetration testing) involves authorized attempts to breach a " +
                "system to identify vulnerabilities before malicious hackers do. " +
                "Ethical hackers use the same techniques as attackers but with permission and to improve security.",

            ["zero day"] =
                "A zero-day vulnerability is a software flaw unknown to the vendor that attackers " +
                "can exploit before a patch is available. Keeping software updated minimizes " +
                "exposure once patches are released.",

            ["sql injection"] =
                "SQL injection is an attack where malicious SQL code is inserted into input fields " +
                "to manipulate a database. Developers prevent it using parameterized queries and " +
                "input validation. Never trust user input in web applications.",

            ["man in the middle"] =
                "A man-in-the-middle (MITM) attack intercepts communication between two parties " +
                "without their knowledge. Using HTTPS, VPNs, and avoiding public Wi-Fi " +
                "helps protect against MITM attacks.",

            // ── South Africa Specific ─────────────────────────────────────────────
            ["south africa"] =
                "South Africa is one of the most targeted countries for cyberattacks in Africa. " +
                "Common threats include banking phishing scams, SIM swap fraud, and ransomware. " +
                "Report cybercrime to the South African Police Service (SAPS) or the CSIRT.",

            ["sim swap"] =
                "SIM swap fraud is when criminals convince your mobile provider to transfer your " +
                "number to their SIM card, giving them access to your OTPs. " +
                "Contact your network provider immediately if your phone loses signal unexpectedly.",

            ["csirt"] =
                "CSIRT (Computer Security Incident Response Team) is South Africa's national " +
                "cybersecurity response body. Report cyber incidents at www.csirt.org.za. " +
                "They assist with cybercrime investigations and provide security advisories.",
        };

        // ─── Random response pools for common queries ─────────────────────────────
        private readonly Dictionary<string, List<string>> _randomResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            ["phishing tip"] = new List<string>
            {
                "Be cautious of emails creating urgency — scammers want you to act before you think.",
                "Always hover over links before clicking to see the actual destination URL.",
                "Legitimate banks and services will NEVER ask for your full password via email.",
                "Look for misspellings in domain names — 'arnazon.com' vs 'amazon.com'.",
                "When in doubt, go directly to the website by typing the URL yourself.",
            },
            ["password tip"] = new List<string>
            {
                "Use a passphrase — a sentence like 'Coffee@Sunrise!2024' is both strong and memorable.",
                "Never reuse passwords across sites; one breach can compromise all your accounts.",
                "Change passwords immediately if you suspect an account has been compromised.",
                "Avoid using your name, birthday, or common words — these are guessed first.",
                "A password manager stores complex passwords securely so you only need one master password.",
            },
            ["safe browsing tip"] = new List<string>
            {
                "Check that a site uses HTTPS (padlock icon) before entering any personal details.",
                "Keep your browser and its extensions updated to patch security vulnerabilities.",
                "Use a browser extension like uBlock Origin to block malicious ads and trackers.",
                "Be cautious of pop-ups claiming your device is infected — these are usually scams.",
                "Clear your browser cache and cookies periodically to reduce tracking exposure.",
            },
            ["scam tip"] = new List<string>
            {
                "If an offer sounds too good to be true, it almost certainly is.",
                "Never pay upfront fees to claim a prize or lottery win — it is a scam.",
                "Verify requests for money transfers by calling the person directly on a known number.",
                "Be wary of 'urgent' messages from your bank — always log in directly, never via a link.",
                "South African banking fraud? Report it to the South African Banking Risk Centre (SABRIC).",
            },
        };

        // ─── General conversation responses ──────────────────────────────────────
        private readonly Dictionary<string, string> _generalResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["how are you"] =
                "I am running securely with all systems green! Thanks for asking. How can I help you stay safe online today?",

            ["purpose"] =
                "I am your Cybersecurity Awareness Assistant — here to educate South African citizens " +
                "about online threats like phishing, malware, and scams. Ask me anything about staying safe!",

            ["what can i ask you about"] =
                "You can ask me about:\n" +
                "   • 🔑 Password safety & tips\n" +
                "   • 🎣 Phishing, smishing & vishing\n" +
                "   • 🌐 Safe browsing & HTTPS\n" +
                "   • 🔐 Two-factor authentication (2FA)\n" +
                "   • 🦠 Malware, viruses, trojans & spyware\n" +
                "   • 💣 Ransomware, DDoS & keyloggers\n" +
                "   • 🔒 Privacy, POPIA & data breaches\n" +
                "   • 🕵️  Social engineering, smishing & pretexting\n" +
                "   • 📶 Wi-Fi security & VPNs\n" +
                "   • 🪪  Identity theft & SIM swap fraud\n" +
                "   • 🏛️  CIA Triad (Confidentiality, Integrity, Availability)\n" +
                "   • 🔥 Firewalls, encryption & patches\n" +
                "   • 💉 SQL injection & zero-day vulnerabilities\n" +
                "   • 🇿🇦 South African cybersecurity (POPIA, CSIRT, SIM swap)\n\n" +
                "   Just type any topic or ask a question naturally!",

            ["hello"] =
                "Hello! Great to have you here. Cybersecurity is everyone's responsibility — " +
                "what would you like to learn about today?",

            ["hi"] =
                "Hi there! Ready to boost your cyber-safety knowledge? Ask me anything!",

            ["help"] =
                "Type 'what can I ask you about' for a full list of topics. " +
                "Or just type a keyword like 'CIA triad', 'ransomware', 'phishing', or 'privacy'.",

            ["thank you"] =
                "You are most welcome! Stay vigilant and safe online. 🛡",

            ["thanks"] =
                "Glad I could help! Remember — cybersecurity is a daily habit, not a one-time fix.",

            ["bye"] =
                "Stay safe online! Remember to think before you click. Goodbye! 👋",

            ["goodbye"] =
                "It was a pleasure chatting with you. Keep your accounts secure and browse safely!",

            ["exit"] =
                "Exiting the chatbot. Stay cyber-safe, and do not hesitate to return if you have questions!",
        };

        // ─── Public methods ───────────────────────────────────────────────────────

        /// <summary>
        /// Returns a response for the given user input.
        /// Checks random tip triggers, keyword matches, and general conversation in order.
        /// Returns null if no match is found.
        /// </summary>
        public string? GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            string lower = input.ToLower();

            // 1. Check for random tip requests
            string? randomResponse = GetRandomTipResponse(lower);
            if (randomResponse != null) return randomResponse;

            // 2. Check general conversation
            foreach (var pair in _generalResponses)
            {
                if (lower.Contains(pair.Key))
                    return pair.Value;
            }

            // 3. Check cybersecurity keyword responses
            foreach (var pair in _keywordResponses)
            {
                if (lower.Contains(pair.Key))
                    return pair.Value;
            }

            return null;
        }

        /// <summary>
        /// Checks if the input is a request for a random tip on a topic.
        /// </summary>
        private string? GetRandomTipResponse(string lower)
        {
            if (lower.Contains("phishing tip") || lower.Contains("phishing tips"))
                return GetRandomFrom("phishing tip");

            if (lower.Contains("password tip") || lower.Contains("password tips"))
                return GetRandomFrom("password tip");

            if (lower.Contains("safe browsing tip") || lower.Contains("browsing tip"))
                return GetRandomFrom("safe browsing tip");

            if (lower.Contains("scam tip") || lower.Contains("scam tips"))
                return GetRandomFrom("scam tip");

            return null;
        }

        /// <summary>
        /// Returns a random response from the specified pool.
        /// </summary>
        private string GetRandomFrom(string key)
        {
            var pool = _randomResponses[key];
            return pool[_random.Next(pool.Count)];
        }

        /// <summary>
        /// Returns a list of all supported topic keywords for display.
        /// </summary>
        public IEnumerable<string> GetSupportedTopics()
        {
            return _keywordResponses.Keys;
        }
    }
}
