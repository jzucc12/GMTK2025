-> Beginning
EXTERNAL get_Text()
VAR useText = false
VAR answer = ""
VAR player_Name = ""
VAR speaker_Number = 0

=== function get_Text() ===
~ return "Johnny"


=== Beginning ===
~useText = true
~answer = "any"
You are calling the complaint office of Teclanker, creator of the most advanced AI system on the market ... LEO AI! 
To speak to a representative. Please enter your name.
	+ Oh, I didn't quite catch that ... Please enter your name.
		++ Huh...
		{player_Name} ... 
		~player_Name = get_Text()
  

    -> 1st_Puzzle
    
=== 1st_Puzzle ===
~useText = false
So ... {player_Name}! Please press the number that corresponds to your relationship to teclanker.
Press 1 for employee
Press 2 for customer
Press 3 for partner/affiliate
Press 4 if this call was a mistake
+[Employee] -> Failed_Answer_1
+[Customer] -> 2nd_Puzzle
+[Partner/Affiliate] -> Failed_Answer_1
+[Mistake] -> Failed_Funny
+ hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! -> 1st_Puzzle

===Failed_Answer_1===
hmmm that doesn't seem right ... 
-> 1st_Puzzle

===Failed_Funny===
Oh! No worries at all! Obviously there's no issue with LEO AI. Have a great day!
-> 1st_Puzzle

===2nd_Puzzle===
~speaker_Number = 1
Why are you calling?
Press 1 for store hours
Press 2 for account management
Press 3 for refunds
Press 4 for a pizza
On second thought, let's switch even and odd numbers. Yeah, that feels right.
+[Store] -> 3rd_Puzzle
+[Refund] -> Failed_Answer_1
+[Pizza] -> Failed_Answer_1
+[Account] -> Failed_Answer_1
+ hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! -> 1st_Puzzle

===3rd_Puzzle===
~speaker_Number = 0
~useText = true
~answer = "razorbacks"
Okay, time for security questions.
First, what was your college mascot?
+[Employee] -> 4th_Puzzle
+[Customer] -> Failed_Answer_1

===4th_Puzzle===
~answer = "100"
Second, how much money is in your wallet? (Don't include $)
+[Employee] -> 5th_Puzzle
+[Customer] -> Failed_Answer_1

===5th_Puzzle===
~answer = "bears"
Third, what did you dream about last night?
+[Employee] -> 6th_Puzzle
+[Customer] -> Failed_Answer_1

===6th_Puzzle===
~useText = false
Finally, why do you hate me?
Press 1 because I'm smarter than you
Press 2 because I'm prettier than you
Press 3 because I'm cooler than you
Press 4 if all of the above
+[Employee] -> Repeat_6
+[Customer] -> Repeat_6
+[Partner/Affiliate] -> Repeat_6
+[Mistake] -> 7th_Puzzle
+ hmmm ... You seem to have picked, "There's nothing wrong with LEO AI! I'm just an idiot!"
Thanks for calling! -> 1st_Puzzle

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
