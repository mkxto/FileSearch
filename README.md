# 🔍 File Search

This is a very poorly made (security wise) program to steal a zip file from my girlfriend's computer (she was okay with that).
This program get the file on the Desktop, send it to me via a Discord Webhook and crypt the file using AES. When its done crypting, a popup appears and ask the victim for the key to decrypt the file!

## The Story behind this program

I'm a cyber-security student, and I'm very aware of everything regarding net-sec/it-sec.
My girlfriend used to store her passwords in an archive (.zip) called *"mdp"* wich litteraly mean "**M**ot **d**e **p**asses" in French (translation for "Password").
All of that on her Desktop!
The archive is protected with a 4-digit password (crackable in seconds)
You see the probleme here, right ? 
So; I told her, I will challenge her security awarness in the next days, she was okay.
One day, she forgot to lock her session, so I plugged my **Rubber Ducky** and then...

![Image](https://i.imgur.com/fYKalAI.png)

Her view:

![Image 2](https://i.imgur.com/V4yysVy.png)

## Security Probleme

The key is in the binary, you can get it just by reversing the program, and thats pretty easy since I made it in C#, its an Assembly so something like [DnSpy](https://github.com/dnSpy/dnSpy) can let the user read trough the code with ease.

## Poor level of coding, bugs

The conception of this program tooked me 3 hours to complete, thats not much, so you can guess I didn't debugged this as much as I would usually.
I tried to add some comments also!

## ⚠️ Warning

Use this program on machine you have authorization to do so!
You are the only one responsible of your actions with my program!
