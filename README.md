# 🛡️ Cybersecurity Awareness Chatbot — Part 1

**Module:** Programming 2A (PROG6221/w)  
**Assessment:** Portfolio of Evidence — Part 1  
**Institution:** The Independent Institute of Education (IIE)

---

## 📋 Project Overview

A command-line cybersecurity awareness chatbot built in C# (.NET 8) that helps South African citizens learn about online threats through a simulated conversation. The chatbot provides guidance on phishing, password safety, safe browsing, malware, VPNs, and more.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🔊 Voice Greeting | Plays a WAV welcome message on startup |
| 🎨 ASCII Art Logo | Displays a cybersecurity-themed banner |
| 👤 Personalized Interaction | Greets user by name throughout the session |
| 💬 Response System | Answers questions on 12+ cybersecurity topics |
| 🎲 Random Responses | Varied tips for phishing, passwords, and browsing |
| ✅ Input Validation | Handles empty, invalid, and unexpected inputs gracefully |
| 🖥️ Enhanced Console UI | Coloured text, typing effect, dividers, and icons |
| 🏗️ Clean Code Structure | Multiple classes — no logic dumped in Program.cs |

---

## 🗂️ Project Structure

```
CybersecurityChatbot/
├── Program.cs                      # Entry point — calls ChatbotEngine.Start()
├── CybersecurityChatbot.csproj     # Project file targeting net8.0-windows
├── Assets/
│   └── greeting.wav                # Voice greeting (WAV format)
├── ChatbotCore/
│   ├── ChatbotEngine.cs            # Orchestrates the session loop
│   ├── ConsoleUI.cs                # All UI rendering: colors, ASCII, typing effect
│   ├── ResponseEngine.cs           # Keyword matching and cybersecurity responses
│   ├── UserSession.cs              # Stores user name and session state
│   ├── VoiceGreeting.cs            # WAV audio playback via System.Media
│   └── InputValidator.cs           # Input validation and sanitization
└── .github/
    └── workflows/
        └── dotnet-ci.yml           # GitHub Actions CI pipeline
```

---

## 🚀 Getting Started

### Prerequisites
- Windows 10 or later
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8) installed

### Clone & Run

```bash
git clone https://github.com/<your-username>/CybersecurityChatbot.git
cd CybersecurityChatbot
dotnet run --project CybersecurityChatbot/CybersecurityChatbot.csproj
```

### Build Only

```bash
dotnet build CybersecurityChatbot/CybersecurityChatbot.csproj --configuration Release
```

---

## 🔊 Voice Greeting Setup

1. Record a short WAV message, for example:  
   *"Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online."*

2. Save it as `greeting.wav` in the `CybersecurityChatbot/Assets/` folder.

3. The app will play it automatically on startup.  
   If the file is missing, the app continues normally with a console notice.

**Recording tools:**
- Windows: Voice Recorder app → export as WAV (or use Audacity to convert MP3 → WAV)
- Audacity (free): [https://www.audacityteam.org/](https://www.audacityteam.org/)

---

## 💬 Supported Topics

Type any of these keywords to get cybersecurity guidance:

`password` · `phishing` · `safe browsing` · `two-factor` · `2fa` · `scam`  
`malware` · `privacy` · `ransomware` · `social engineering` · `wifi` · `vpn` · `identity theft`

**Random tips:** type `phishing tip`, `password tip`, or `safe browsing tip` to receive a random tip.

**General:** `how are you` · `what's your purpose` · `what can I ask you about` · `help`

---

## 🧪 Example Interaction

```
  👤 Name  : phishing
  🤖 Bot   : Phishing emails pretend to be from trusted sources to steal your
             information. Always check the sender's email address carefully...

  👤 Name  : give me a phishing tip
  🤖 Bot   : Be cautious of emails creating urgency — scammers want you to act
             before you think.

  👤 Name  : exit
  🤖 Bot   : Exiting the chatbot. Stay cyber-safe!
```

---

## ✅ CI/CD — GitHub Actions

The repository uses a GitHub Actions workflow (`.github/workflows/dotnet-ci.yml`) that runs on every push and pull request:

1. **Checkout** source code
2. **Setup** .NET 8 SDK
3. **Restore** NuGet packages
4. **Build** in Release configuration
5. **Verify** executable output exists

### CI Workflow Screenshot

> 📸 *Replace the placeholder below with a screenshot of your green CI check from the GitHub Actions tab.*

![CI Workflow Green Check](docs/ci-screenshot.png)

---

## 📝 Commit History

| # | Message |
|---|---|
| 1 | `Initial commit: Set up project structure and main files` |
| 2 | `Add ASCII art logo and ConsoleUI class with colour formatting` |
| 3 | `Implement VoiceGreeting with WAV playback via System.Media` |
| 4 | `Add ResponseEngine with keyword and random tip responses` |
| 5 | `Implement InputValidator and UserSession with auto properties` |
| 6 | `Add ChatbotEngine conversation loop and GitHub Actions CI` |

---

## 🎥 Video Presentation

> 🎬 [YouTube Unlisted Link — insert your link here]

The video covers:
- Application startup and voice greeting
- ASCII art and console UI overview
- Live demonstration of all cybersecurity topics
- Code walkthrough: class structure, methods, logic flow
- Input validation in action
- GitHub Actions CI workflow demonstration

---

## 📚 References

Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review. *The African Journal of Information and Communication*, 28(28). doi: https://doi.org/10.23962/10539/32213. [Online]. Available at: https://www.scielo.org.za/scielo.php?pid=S2077-72132021000200003&script=sci_arttext [Accessed 26 March 2026].
