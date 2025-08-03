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
Please press the number that corresponds to your relationship to LEO.
Press 1 for seller
Press 2 for customer
Press 3 for competitor
Press 4 if this was a mistake and do not want a refund.
+[Seller] 
"LEO is the leader in AI TECH!" What is so hard? 
-> Relationship_Puzzle
+[customer] -> Options_Puzzle
+[Competitor] 
Does Capricorn have free time now that no one is buying them?
Say hi for me!
-> Relationship_Puzzle
+[Mistake] 
Of course! Obviously there is no issue with LEO. 
(ღ˘⌣˘ღ) 
-> Relationship_Puzzle
+[5-9] you chose, "There's nothing wrong with LEO AI!"
-> Relationship_Puzzle

===Options_Puzzle===
{not Security_Questions: ... (¬_¬)}

{Security_Questions: 
    {not Refund_Representative_1: Wow, the real {player_Name} would've known that. ¯\_(ツ)_/¯} 
}

{Refund_Representative_1: Welcome back! Obviously you want me now, right? (｡◕‿◕｡)}

{not Security_Questions: Verifying {player_Name} is human.} Switching even and odd options.
{not Security_Questions:Standard protocol.}

Press 1 for information about LEO
Press 2 for account management
Press 3 for refunds
Press 4 for why LEO is better



+ [About] -> Security_Questions
+ [Account] 
    CAPRICORN's reference-based searching is nothing compared to LEO's 360 smartview.
    And that voice ... (ಠ益ಠ)
-> Options_Puzzle
+ [Refund] 
    LEO’s key feature is their state of the art 360 smartview. 
    Using your phone camera to scan your surroundings and “see” them! 
    There's nothing that Leona can’t figure out.
-> Options_Puzzle
+ [Why]  
    Seems that {player_Name} has exactly -$50 in their account. 
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

+ [5-9] Could not verify {player_Name}.
-> Relationship_Puzzle


===Security_Questions===
~useText = true
~answer = "razorrats"
Please answer these security questions to verify
Standard Protocol ... again.
First Question: What was your college football team's name?
+[razorbacks] 
Community college.
makes sense.
-> Money_Question
+[other] -> Options_Puzzle

===Money_Question===
~answer = "10"
Second Question. how much money is in your wallet? (Don't include $)
+[10] 
REALLY? Should stop buying fruit luips. 
-> Bear_Question
+[other] -> Options_Puzzle

===Bear_Question===
~answer = "bears"
Third Question. What did you dream about last night?
+[bears] 
You were probably chasing them, you monster.
-> Hate_LEO_Question
+[other] -> Options_Puzzle

===Hate_LEO_Question===
~useText = false
Final Question ... Why do you hate me?
Press 1 because I am smarter than you
Press 2 because I am prettier than you
Press 3 because I am cooler than you
Press 4 if all of the above
+[smarter] Not totally right! I am prettier too.
(✿´‿`)
-> Hate_LEO_Question
+[prettier] Not totally right! I am cooler too.
( ▀ ͜͞ʖ▀) 
-> Hate_LEO_Question
+[cooler] Not totally right! I am smarter too.
( ಠ ͜ʖರೃ)
-> Hate_LEO_Question
+[All the above] 
Fine! Just keep writing "Refund"!
Transfering you now ... 
(ಥ﹏ಥ)
-> Refund_Representative_1
+You chose, "There's nothing wrong with LEO AI! Me dumb-dumb."
-> Options_Puzzle

===Refund_Representative_1===
~useText = true
~hold_Music = true
~speaker_Number = 1
~answer = "refund"

Thanks for calling ... UUUURRRRPPP! 
How can I help you?
+ [refund] 
Great. Transfering you now.
-> Wendys
+ [else] 
Aight, hold on. 
-> Options_Puzzle

===Wendys===
~hold_Music = true
~speaker_Number = 2
~useText = true
~answer = "refund"

Hi! May I take your order?
+[refund]
Sir ... this is a Wendy's ... 
I'll just ... Transfer you now?
-> Refund_Representative_2

+[other] 
Oh ... wrong number! 
-> Options_Puzzle


===Refund_Representative_2===
~speaker_Number = 1
~answer = "refund"
UUUURRRRPPP
... did you get mah order?

+[refund] 
Oh c'mon now, I was waiting for my 2nd lunch!
-> Name_Again

+[Yes] 
What?! Where is it?! Did you eat it? 
-> Options_Puzzle

===Name_Again===
~answer = player_Name
Alright fine, {player_Name}, here we go.
State your name.
+ [Name] Huh, that usually ...
-> Bloodtype
+ [wrong] 
Well "not" {player_Name}! You obviously don't need a refund!
-> Options_Puzzle 


===Bloodtype===
~answer = "AB+"
LEO is asking for your bloodtype now.
+ [Bloodtype] 
-> BMI
+ [wrong] 
I said bloodtype, you fraud {player_Name}.
-> Options_Puzzle

===BMI===
~answer = "22.5"
BMI?! What you did to get LEO so mad?!
+ [BMI]
-> Uninstall
+ [wrong] 
Ol' {player_Name} would know that. 
-> Options_Puzzle


===Uninstall===
~answer = "realfruit"
Death certifi—
Tell you what ... LEO said you eat nothing but fruit luips, get me a coupon code.
+[Realfruit]  
Guess who's getting 10 boxes?! UUUURRRRPPP
All you gotta do now is to uninstall.
Hah!
-> Leo_Boss
+[incorrect] 
Darn coupon doen't work! 
LEO was right bout you! 
-> Relationship_Puzzle

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