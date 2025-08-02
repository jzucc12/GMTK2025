-> Beginning
EXTERNAL get_Text()
VAR useText = false
VAR answer = ""
VAR player_Name = ""
VAR speaker_Number = 0
VAR pretty = false

=== function get_Text() ===
~ return "Johnny"


=== Beginning ===
~useText = true
~answer = "any"
You are calling the refund office of Teclanker, creator of the most advanced AI system on the market ... LEO! 

+{not 1st_Puzzle}
To speak to a representative. Please enter your name.
	++ Oh, I didn't quite catch that ... Please try entering again.
		+++ Hm (¬_¬) ... 
		~player_Name = get_Text()
    -> 1st_Puzzle
    
+{1st_Puzzle} oh ... {player_Name} ... Nice of you to call back. (¬_¬)
-> 1st_Puzzle
    
=== 1st_Puzzle ===
~useText = false
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
Thanks for calling! 
-> Beginning

===Failed_Answer_Seller===
Just say, "LEO is the leader in AI TECH!" What's so hard? 
CLICK
-> Beginning

===Failed_Answer_Competitor===
Aww, does Capricorn have free time now that no one's buying them?
Say hi for me!
CLICK
-> Beginning
===Failed_Funny===
Oh, of course! Obviously there's no issue with LEO. (ღ˘⌣˘ღ) Have a great day!
-> Beginning

===2nd_Puzzle===
So ... {player_Name} ... the buyer (¬_¬). Press the option that relates to why you're calling.
Press 1 for information about LEO
Press 2 for account management
Press 3 for refunds
Press 4 for why LEO is better
On second thought, let's switch even and odd numbers. Yeah, that feels right.
+[About] -> Failed_Answer_About
+[Account] -> Failed_Answer_Account
+[Refund] -> 3rd_Puzzle
+[Why] -> Failed_Answer_Why
+[5-9] hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! 
-> 1st_Puzzle

===Failed_Answer_About===
Created by the brilliant minds at Teclanker, LEO’s key feature is their state of the art 360 smartview. Using your phone camera to scan your surroundings and “see” them! There's nothing that Leona can’t figure out.
Thanks for calling!
CLICK
-> Beginning
===Failed_Answer_Account===
Seems that {player_Name} has exactly -$50 in their account. 
Thanks for calling!
CLICK
-> Beginning
===Failed_Answer_Why===
CAPRICORN's reference-based searching is nothing compared to LEO's 360 smartview. And that voice ...
(ಠ益ಠ)
Know that you have the best AI in the business!
CLICK
-> Beginning
===3rd_Puzzle===
~useText = true
~answer = "razorbacks"
Before I send you to one of our agents, {player_Name}, please answer these security questions to verify who you are. 
First Question: What was your college mascot?
+[razorbacks] -> 4th_Puzzle
+[other] -> Failed_Answer_Mascot

===Failed_Answer_Mascot===
The real {player_Name} would know the community college they went to.
//Don't you have a diploma somwhere?
Thanks for calling!
CLICK
-> Beginning
===4th_Puzzle===
~answer = "100"
Huh, didn't know a dropout would have college pride.
Second Question. how much money is in your wallet? (Don't include $)
+[100] -> 5th_Puzzle
+[other] -> Failed_Answer_money

===Failed_Answer_money===
Afraid to see the flies in your wallet?
Thanks for calling!
CLICK
-> Beginning
===5th_Puzzle===
~answer = "bears"
REALLY?! You might need that refund.
Third Question. What did you dream about last night?
+[bears] -> 6th_Puzzle
+[other] -> Failed_Answer_Dreams

===Failed_Answer_Dreams===
Monsters who try to refund the best AI ever don't dream!
Thanks for calling!
CLICK
-> Beginning
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
+[All the above] -> 7th_Puzzle
+ hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! -> Beginning

===Repeat_6===
I mean, you're not wrong. But not entirely right either. Try again.
+[Employee] -> Repeat_6
+[Customer] -> Repeat_6
+[Partner/Affiliate] -> Repeat_6
+[Mistake] -> 7th_Puzzle

===7th_Puzzle===
That's all for now!
+ bye

-> END
