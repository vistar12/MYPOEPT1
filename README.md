MYPOEPT1 is a C# console application that integrates multiple components, including:
Voice Playback: Plays an audio file.
ASCII Art Generator: Converts an image into ASCII text.
Cybersecurity Chatbot: A bot that provides responses related to cybersecurity topics. 

Voice Interaction: The voice class plays a file located in the project's root directory.
ASCII Logo Display: The Ascii_Logo class loads and converts an image into ASCII art.
Cybersecurity Chatbot: The StorePrompt class provides cybersecurity-related advice based on user input.

Voice Playback
When the application starts, it will attempt to play my record.wav.
Ensure that the file exists, or an error message will be displayed.

Cybersecurity Chatbot
Users can ask cybersecurity-related questions.
The bot recognizes keywords and provides predefined responses.
Type exit, quit, or bye to end the chatbot session.
Includes a mechanism to ignore common words and filter meaningful queries.

ASCII Art Generator
Converts CYBERSECURITY.png into ASCII and prints it to the console.
Resizes the image to fit the console window before processing.

Randomisation
When a user mentions a keyword like "phishing" or "malware," the bot randomly selects from a list of relevant responses instead of always giving the same one. This helps make the conversation feel more natural and engaging, as it mimics the way humans vary their speech. It enhances the realism of the chatbot and keeps users more interested by providing fresh, dynamic replies each time.

Sentiment
Sentiment detection enables the chatbot to recognize the emotional tone in the user’s input and respond with empathy. For example, if the user says they are "worried" or "frustrated," the bot includes a comforting or encouraging message before delivering the main response. This adds emotional intelligence to the interaction, making the bot seem more human-like and user-friendly. By acknowledging how the user feels, the chatbot builds trust and creates a more supportive communication experience.

Memory Recall
Memory recall allows the chatbot to remember user-specific interests across different sessions. When a user says something like "I am interested in ransomware," the bot stores that information along with the user’s name. Later, if the user asks "what are my interests," the bot can recall and display them. This feature personalizes the chatbot, giving it the ability to adapt to individual users and remember their preferences. It simulates long-term memory, making interactions more meaningful and context-aware.
![Screenshot 2025-05-14 214229](https://github.com/user-attachments/assets/97b62a71-498d-4088-917d-4a0f70d75750)
![Screenshot 2025-05-14 214004](https://github.com/user-attachments/assets/9705d564-9085-41ab-8ac3-aa7a4f7c3ab9)




