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
You are calling the refund office of Teclanker, creator of the most advanced AI system on the market ... LEO! 

To speak to a representative. Please enter your name.
	+ Oh, I didn't quite catch that ... Please try entering again.
		++ Hm (¬_¬) ... 
		~player_Name = get_Text()
    -> 1st_Puzzle
    
=== 1st_Puzzle ===
~useText = false
~speaker_Number = 0
So ... {player_Name}! Please press the number that corresponds to your relationship to LEO AI.
Press 1 for seller
Press 2 for buyer
Press 3 for competitor
Press 4 if this was a mistake and you don't want a refund.
+[Seller] -> Failed_Answer_Seller
+[Buyer] -> 2nd_Puzzle
+[Competitor] -> Failed_Answer_Competitor
+[Mistake] -> Failed_Funny
+[5-9] hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
-> 1st_Puzzle

===Failed_Answer_Seller===
Just say, "LEO is the leader in AI TECH!" What's so hard? 
-> 1st_Puzzle

===Failed_Answer_Competitor===
Aww, does Capricorn have free time now that no one's buying them?
Say hi for me!
-> 1st_Puzzle
===Failed_Funny===
Oh, of course! Obviously there's no issue with LEO. (ღ˘⌣˘ღ) 
-> 1st_Puzzle

===2nd_Puzzle===
{not AI_Sad: So ... {player_Name} ... the buyer (¬_¬). Press the option that relates to why you're calling.}
{Security_Questions: {not AI_Sad: I can imagine why } }
{AI_Sad: Welcome back! Obviously you want me back, right?}
Press 1 for information about LEO
Press 2 for account management
Press 3 for refunds
Press 4 for why LEO is better
On second thought, let's switch even and odd numbers. Yeah, that feels right.
+[About] -> Security_Questions
+[Account] -> Failed_Answer_Why
+[Refund] -> Failed_Answer_About
+[Why] -> Failed_Answer_Account
+[5-9] hmmm ... You seem to have picked, "There's nothing wrong with LEO! I'm just an idiot!"
-> 1st_Puzzle

===Failed_Answer_About===
Created by the brilliant minds at Teclanker, LEO’s key feature is their state of the art 360 smartview. Using your phone camera to scan your surroundings and “see” them! There's nothing that Leona can’t figure out.
-> 2nd_Puzzle
===Failed_Answer_Account===
Seems that {player_Name} has exactly -$50 in their account. 
-> 2nd_Puzzle
===Failed_Answer_Why===
CAPRICORN's reference-based searching is nothing compared to LEO's 360 smartview. And that voice ...
(ಠ益ಠ)
Know that you have the best AI in the business!
-> 2nd_Puzzle
===Security_Questions===
~useText = true
~answer = "razorbacks"
Before I send you to one of our agents, {player_Name}, please answer these security questions to verify who you are. 
First Question: What was your college mascot?
+[razorbacks] -> 4th_Puzzle
+[other] -> Failed_Answer_Mascot

===Failed_Answer_Mascot===
The real {player_Name} would know the community college they went to.
-> 1st_Puzzle
===4th_Puzzle===
~answer = "10"
Ah, community college ... makes sense.
Second Question. how much money is in your wallet? (Don't include $)
+[10] -> 5th_Puzzle
+[other] -> Failed_Answer_money

===Failed_Answer_money===
Afraid to see the flies in your wallet?
-> 1st_Puzzle
===5th_Puzzle===
~answer = "bears"
REALLY?! You might need that refund.
Third Question. What did you dream about last night?
+[bears] -> 6th_Puzzle
+[other] -> Failed_Answer_Dreams

===Failed_Answer_Dreams===
Monsters who try to refund the best AI ever don't dream!
-> 1st_Puzzle
===6th_Puzzle===
~useText = false
You were probably chasing them, you monster! 
Final Question! ... Why do you hate me?
Press 1 because I'm smarter than you
Press 2 because I'm prettier than you
Press 3 because I'm cooler than you
Press 4 if all of the above
+[smarter] -> Repeat_6
+[prettier] -> Repeat_6
+[cooler] -> Repeat_6
+[All the above] -> AI_Sad
+ hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! -> 1st_Puzzle

===Repeat_6===
You are not wrong!  But not completely right!
+[Smarter] -> Repeat_6
+[Prettier] -> Repeat_6
+[Cooler] -> Repeat_6
+[All the above] -> AI_Sad
+ hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! -> 1st_Puzzle

===AI_Sad===
//Fine ...! Keep saying refund! Even if it hurts me each time 
When someone asks you want you want, just keep writing "Refund" like you've been doing.
I will now transfer you to one of our representatives ...
Please hold.

-> Refund_Representative_1

===Refund_Representative_1===
~useText = true
~hold_Music = true
~speaker_Number = 1
~answer = "Refund"

Thanks for calling the "UUUURRRRPPP" Refund Department.
How can I help you?
+ [refund] Alright, hold on. 
-> Wendys
+ [else] Alright, hold on. 
-> 1st_Puzzle

===Wendys===
~hold_Music = true
~speaker_Number = 2
Hi! may I take your order?
~useText = true
~answer = "refund"

+[refund]
sir ... this is a Wendy's ... 
~useText = true
Uhhh ... hold on. I'll just redirect you. Please hold.

-> Refund_Representative_2

+[other] -> 1st_Puzzle


===Refund_Representative_2===
~speaker_Number = 1
Oh you're back ... did you get my order?

~answer = "refund"
+[refund] Oh c'mon now, I was waiting for my 2nd lunch! What am I supposed to eat now? 
+[Yes] What?! Where is it?! Did you eat it? 
-> 1st_Puzzle
~answer = "withrealfroot"
++[Refund] Tell you what ... LEO said you eat nothing but fruit luips, get me a coupon code or something.
++[incorrect] -> 1st_Puzzle
+++[correct] -> Uninstall
+++[incorrect] Darn coupon doesn't work! LEO was right bout you! -> 1st_Puzzle

===Uninstall===
~answer = "refund"
ohoho! Guess who's getting 10 boxes sent their way?! You're alright.
+[refund] Alright alright, you scratch my back, I scratch your razorback. Hah! Now all you gotta do is unistall it on you end. Have fun telling them!

-> Leo_Boss

===Leo_Boss===
~useText = false
Are you ... really going to do this.
Press 1 for "Of course not! You're amazing!"
Press 2 for "I'm a souless beast!"

+[1] -> 1st_Puzzle
+[2] 
After all we've been through! I won't let it end like this!
-> END