Project details Project name:ST10188142 Part1 Netframe:4.0.8 Template:Part 1 netframework

 1. Chatbot Class:
 • The main logic is inside the Chatbot class.
 • It includes private variables to store the user’s name and their area of interest.
 2. Sentiment Detection:
 • Two arrays store words linked to positive or negative feelings about online safety.
 • These help the bot understand how the user feels.
 3. Starting the Bot:
 • When the chatbot is launched, it:
 • Plays a welcome sound (Audio.wav)
 • Displays an ASCII art image made from Prog Log.jpeg
 • Sets up a list of cybersecurity topics, each with related safety tips.
 4. User Conversation:
 • The chatbot greets the user, asks for their name, and checks how they feel about cybersecurity.
 • It replies with a supportive or positive message based on the user’s mood.
 5. Main Chat Loop:
 • The bot keeps asking the user what they want to learn.
 • It scans the input for keywords like “phishing” or “password” and gives a random tip from the matching category.
 • It remembers the user’s interest and uses it in future responses.
 • If the input isn’t clear, it asks the user to try again.
 6. Ending the Chat:
 • The conversation continues until the user types “exit”, at which point the bot says goodbye.
 7. Sound and Image Features:
 • Play_Sound plays an audio file.
 • Ascii_Art turns an image into a black-and-white ASCII-style drawing and displays it in the console.
