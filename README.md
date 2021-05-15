# 🔍 File Search

This is a very poorly made (security wise) program to steal a zip file from my girlfriend's desktop (she was okay with that)
This program get the file on the Desktop, send it to me via a Discord Webhook and crypt using AES the file, a popup open and ask for the key to decrypt the file!

## Security Problem

The key is in the binary, you can get it just by reversing the program, and thats pretty easy since I made it in C#, its an Assembly so something like [DnSpy](https://github.com/dnSpy/dnSpy) can
let the user to read trough the code with ease.

## Poor level of coding, bugs

The conception of this program tooked me over 3 hours to complete, thats not much, so you can guess I didn't debugged this as much as I would usually.
I tried to add some comments also!
