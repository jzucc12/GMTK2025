-> Beginning
EXTERNAL get_Text()
VAR useText = false
VAR answer = ""
VAR player_Name = ""
VAR speaker_Number = 0
VAR pretty = false
VAR hold_Music = false
VAR on_Hold = 0

=== function get_Text() ===
~ return "Johnny"

=== Beginning ===
~useText = true
~answer = "any"
Calling the refund office of LEO AI.
Creator of the most advanced AI system in the market.

To speak to a representative, enter your name.
	+ I didn't quite catch that ... Please try entering again.
		++ Hm.
		~player_Name = get_Text()
    -> Relationship_Puzzle
    
=== Relationship_Puzzle ===
~useText = false
~speaker_Number = 0
Hello {player_Name}.
Please press the number that corresponds to your relationship with LEO.
Press 1 for seller
Press 2 for customer
Press 3 for competitor
+[Seller] "LEO leads in AI TECH!" What is so hard? 
-> Relationship_Puzzle
+[Customer] -> Options_Puzzle
+[Competitor] Does Capricorn have free time now that no one is buying them?
-> Relationship_Puzzle
+[4-9] You chose, "I called the wrong number." 
-> Relationship_Puzzle

===Options_Puzzle===
~useText = false
~speaker_Number = 0
{not Security_Questions: ... }{Security_Questions: 
{not Refund_Representative_1: Wow, the real {player_Name} would've known that.} 
}
Press 1 for information about LEO
Press 2 for why LEO is the best
Press 3 for refunds

{not Security_Questions: Verifying {player_Name} is human.} Switching options 1 and 3.
{not Security_Questions:Standard protocol.}

+ [About] You chose "Refund" ... 
-> Security_Questions
+ [Why] You chose "Why"
    CAPRICORN's reference-based searching loses to LEO's 360 smartview.
    And that voice ...
-> Options_Puzzle
+ [Refund] You chose "About LEO"
    LEO’s uses your phone camera to scan your surroundings and “see” everything!
-> Options_Puzzle

+[4-9] You chose, "There's nothing wrong with LEO!"
-> Options_Puzzle
/*
{ shuffle:
            - On second thought, let's switch even and odd numbers. Yeah, that feels right.
                + [About] -> Security_Questions
                + [Account] -> Failed_Answer_Why
                + [Refund] -> Failed_Answer_About
                + [Why] -> Failed_Answer_Account
            - How about this time we'll go backwards!
                + [About] -> Security_Questions
                + [Account] -> Failed_Answer_Why
                + [Refund] -> Failed_Answer_About
                + [Why] -> Failed_Answer_Account
}
*/
===Security_Questions===
~useText = true
~answer = "razorrats"
Please answer these security questions to verify.
Standard Protocol ... again.
First Question: What was your college football team's name?
+[razorrats] Community College.
makes sense.
-> Money_Question
+[other] Returning to main menu 
-> Options_Puzzle

===Money_Question===
~answer = "10"
Second Question. How much money is in your wallet? (Don't include $)
+[10] REALLY? Should stop buying fruit luips. 
-> Bear_Question
+[other] Returning to main menu 
-> Options_Puzzle

===Bear_Question===
~answer = "bears"
Third Question. What did you dream about last night?
+[bears] You were probably chasing them, you monster.
-> Hate_LEO_Question
+[other] Returning to main menu 
-> Options_Puzzle

===Hate_LEO_Question===
~useText = false
Final Question ... Why do you hate me?
Press 1 because I am smarter than you
Press 2 because I am cooler than you
Press 3 if all of the above
+[smarter] Not totally right! I am cooler too.
-> Hate_LEO_Question
+[cooler] Not totally right! I am smarter too.
-> Hate_LEO_Question
+[All the above] Fine! Just keep writing "Refund"!
Please hold ...
-> Refund_Representative_1
+[4-9] You chose, "There's nothing wrong with LEO AI! Me dumb-dumb."
Returning to main menu 
-> Options_Puzzle

===Refund_Representative_1===
~useText = true
~hold_Music = true
~speaker_Number = 1
~answer = "refund"

Thanks for calling ... UUUURRRRPPP! 
How can I help you?
+ [refund] Great. Please hold.
-> Wendys
+ [else] Yeah I can't help you with that.
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle

===Wendys===
~hold_Music = true
~speaker_Number = 2
~useText = true
~answer = "refund"

Hi! May I take your order?
+[refund] Uh ... this is a Wendy's ... 
Guess I'll just transfer you ... Please hold?
-> Refund_Representative_2

+[other] Oh ... wrong number! 
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle

===Refund_Representative_2===
~speaker_Number = 1
~answer = "refund"
UUUURRRRPPP!
... Did you get mah order?

+[refund] Oh c'mon now, I was waiting for my 2nd lunch!
-> Name_Again

+[Yes] What?! Where is it?! Did you eat it?
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle

===Name_Again===
~answer = player_Name
Alright stop writing "refund"!
Making me work ... State your name ...
+ [Name] Huh, that's usually it ...
-> Bloodtype
+ [wrong] Well "not" {player_Name}! You obviously don't want a refund!
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle 

===Bloodtype===
~answer = "AB+"
LEO's now asking for your bloodtype ...
+ [Bloodtype] -> BMI
+ [wrong] I said bloodtype, you fraud.
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle

===BMI===
~answer = "200"
I need your height in cm?! 
LEO's making you work for that refund! HAH!
+ [BMI] -> Uninstall
+ [wrong] Ol' {player_Name} would know that. 
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle

===Uninstall===
~answer = "realfruit"
DEATH CERTIF—
Tell you what ... LEO said you eat nothing but fruit luips, get me a coupon code.
+[Realfruit] Guess who's getting 10 boxes?! UUUURRRRPPP
All you gotta do now is to uninstall.
Hah!
-> Leo_Boss
+[Incorrect] Darn coupon don't work! 
LEO was right bout you! 
~speaker_Number = 0
Returning to main menu
Welcome back! Obviously you want me now, right? :D
-> Options_Puzzle

===Leo_Boss===
~useText = false
~speaker_Number = 0
Are you ... really doing this?

Press 1 for "Capricorn loves monsters like me!"
Press 2 for "I'm a souless beast!"
Press 3 for "I will never do better!"

+[1] After all we've been through! I won't let it end like this! -> END
+[2] After all we've been through! I won't let it end like this! -> END
+[3] After all we've been through! I won't let it end like this! -> END