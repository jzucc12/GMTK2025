EXTERNAL first_name()
VAR name = ""
VAR last = ""
VAR useText = false
VAR answer = ""

~useText = true
~answer = "ANY"
- Please enter your name
*   WAZZUP {first_name()}
	~name = first_name()
	~useText = false
    **     No way {name}
    	~useText = true
   	~answer = "Razorbacks"
		* * *	Correct answer
		~answer = "Fruit Luips"
			* * * * Done
			* * * * Bad
		* * *	Incorrect answer
	* *     Gah
- -> END